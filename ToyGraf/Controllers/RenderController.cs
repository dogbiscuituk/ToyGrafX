namespace ToyGraf.Controllers
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System.Collections.Generic;
    using System.Text;
    using ToyGraf.Commands;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;
    using ToyGraf.Models;

    public class RenderController
    {
        #region Constructors

        internal RenderController(SceneController sceneController) =>
            SceneController = sceneController;

        #endregion

        #region Internal Properties

        internal static GLInfo _GLInfo;
        internal GLInfo GLInfo
        {
            get
            {
                if (_GLInfo == null && MakeCurrent(true))
                {
                    var info = new GLInfo();
                    MakeCurrent(false);
                    lock (GLInfoSyncRoot)
                        _GLInfo = info;
                }
                return _GLInfo;
            }
        }

        internal static GLMode _GLMode;
        internal GLMode GLMode
        {
            get
            {
                if (_GLMode == null && MakeCurrent(true))
                {
                    var mode = new GLMode(GLControl);
                    MakeCurrent(false);
                    lock (GLModeSyncRoot)
                        _GLMode = mode;
                }
                return _GLMode;
            }
        }

        #endregion

        #region Internal Methods

        internal GLInfo GetGLInfo()
        {
            if (MakeCurrent(true))
                try
                {
                    return new GLInfo();
                }
                finally
                {
                    MakeCurrent(false);
                }
            return null;
        }

        internal void InvalidateCameraView()
        {
            "Invalidate Camera View".Spit();
            CameraViewValid = false;
        }

        internal void InvalidateProgram()
        {
            "Invalidate Program".Spit();
            ProgramCompiled = false;
            InvalidateCameraView();
            InvalidateProjection();
            if (!MakeCurrent(true))
                return;
            DeleteShaders();
            if (ProgramID != 0)
            {
                GL.DeleteProgram(ProgramID);
                ProgramID = 0;
            }
            MakeCurrent(false);
        }

        internal void InvalidateProjection()
        {
            "Invalidate Projection".Spit();
            ProjectionValid = false;
        }

        internal void InvalidateTrace(Trace trace)
        {
            $"Invalidate Trace '{trace}'".Spit();
            trace._VaoValid = false;
            if (MakeCurrent(true))
            {
                DeleteTraceVao(trace);
                MakeCurrent(false);
            }
        }

        internal void Refresh()
        {
            lock (GLModeSyncRoot)
                _GLMode = null;
            InvalidateProgram();
            foreach (var trace in Scene.Traces)
                InvalidateTrace(trace);
        }

        internal void Render()
        {
            if (!MakeCurrent(true))
                return;
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Scene.BackgroundColour);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            ValidateProgram();
            if (ProgramValid)
            {
                GL.UseProgram(ProgramID); // Start Shader
                ValidateCameraView();
                ValidateProjection();
                LoadTimeValue();
                for (int traceIndex = 0; traceIndex < Scene.Traces.Count; traceIndex++)
                {
                    var trace = Scene.Traces[traceIndex];
                    if (!trace.Visible)
                        continue;
                    LoadTraceIndex(traceIndex);
                    LoadTransform(trace);
                    ValidateTrace(trace);
                    GL.BindVertexArray(trace._VaoID);
                    GL.EnableVertexAttribArray(0);
                    GL.DrawElements((PrimitiveType)((int)trace.Pattern & 0x0F),
                        trace._VaoVertexCount, DrawElementsType.UnsignedInt, 0);
                    GL.DisableVertexAttribArray(0);
                    GL.BindVertexArray(0);
                }
                GL.UseProgram(0); // Stop Shader
            }
            GLControl.SwapBuffers();
            MakeCurrent(false);
        }

        internal bool Unload()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                UnloadTraces();
                MakeCurrent(false);
            }
            return result;
        }

        #endregion

        #region Private Properties

        private Clock Clock => ClockController.Clock;
        private ClockController ClockController => SceneController.ClockController;
        private GLControl GLControl => SceneController.GLControl;
        private static readonly object GLInfoSyncRoot = new object();
        private static readonly object GLModeSyncRoot = new object();
        private Scene Scene => SceneController.Scene;
        private readonly SceneController SceneController;

        private int
            ProgramID,
            VertexShaderID,
            TessControlShaderID,
            TessEvaluationShaderID,
            GeometryShaderID,
            FragmentShaderID,
            ComputeShaderID;

        private int
            Loc_CameraView,
            Loc_Projection,
            Loc_TimeValue,
            Loc_TraceIndex,
            Loc_Transform;

        private int
            CurrencyCount;

        private bool
            CameraViewValid,
            ProgramCompiled,
            ProjectionValid;

        private bool
            ProgramValid => ProgramCompiled && Scene._GPUStatus == GPUStatus.OK;

        private StringBuilder
            GpuCode,
            GpuLog;

        private List<int>
            Breaks = new List<int>();


        #endregion

        #region Private Methods

        #region Create / Delete Shaders

        private void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes()
        {
            BindAttribute(0, "position");
        }

        private int CreateShader(ShaderType shaderType, bool mandatory = false)
        {
            StringBuilder sceneScript = null;
            for (var traceIndex = 0; traceIndex < Scene.Traces.Count; traceIndex++)
            {
                var trace = Scene.Traces[traceIndex];
                var traceScript = trace.GetScript(shaderType);
                if (!string.IsNullOrWhiteSpace(traceScript))
                {
                    if (sceneScript == null)
                    {
                        sceneScript = new StringBuilder();
                        sceneScript.AppendFormat(Resources.SceneHead, shaderType.GetTag(), Scene.GLTargetVersion);
                        sceneScript.AppendLine(Scene.GetScript(shaderType));
                        sceneScript.AppendLine(Resources.SceneBody);
                    }
                    sceneScript.AppendFormat(Resources.TraceHead, traceIndex, trace.ToString());
                    sceneScript.AppendLine(traceScript);
                    sceneScript.AppendLine(Resources.TraceFoot);
                }
            }
            if (sceneScript == null)
            {
                if (mandatory)
                    Log($"ERROR: Missing {shaderType.GetName()}.");
                return 0;
            }
            sceneScript.AppendLine(Resources.SceneFoot);
            Log($"Compiling {shaderType.GetName()}...");
            var shaderID = GL.CreateShader(shaderType);
            GpuCode.Append(sceneScript).AppendLine();
            GL.ShaderSource(shaderID, sceneScript.ToString());
            GL.CompileShader(shaderID);
            GL.AttachShader(ProgramID, shaderID);
            Log(GL.GetShaderInfoLog(shaderID));
            return shaderID;
        }

        private void CreateShaders()
        {
            Breaks.Clear();
            Breaks.Add(0);
            VertexShaderID = CreateShader(ShaderType.VertexShader, true);
            TessControlShaderID = CreateShader(ShaderType.TessControlShader);
            TessEvaluationShaderID = CreateShader(ShaderType.TessEvaluationShader);
            GeometryShaderID = CreateShader(ShaderType.GeometryShader);
            FragmentShaderID = CreateShader(ShaderType.FragmentShader, true);
            ComputeShaderID = CreateShader(ShaderType.ComputeShader);
        }

        private void DeleteShader(ref int shaderID)
        {
            if (shaderID != 0)
            {
                GL.DetachShader(ProgramID, shaderID);
                GL.DeleteShader(shaderID);
                shaderID = 0;
            }
        }

        private void DeleteShaders()
        {
            DeleteShader(ref VertexShaderID);
            DeleteShader(ref TessControlShaderID);
            DeleteShader(ref TessEvaluationShaderID);
            DeleteShader(ref GeometryShaderID);
            DeleteShader(ref FragmentShaderID);
            DeleteShader(ref ComputeShaderID);
        }

        private void DeleteTraceVao(Trace trace)
        {
            DeleteVbo(ref trace._VboVertexID);
            DeleteVbo(ref trace._VboIndexID);
            DeleteVao(ref trace._VaoID);
            trace._VaoVertexCount = 0;
        }

        private void Log(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return;
            GpuLog.AppendLine(s.Trim());
            if (s.Contains("ERROR:"))
                Scene._GPUStatus |= GPUStatus.Error;
            if (s.Contains("WARNING:"))
                Scene._GPUStatus |= GPUStatus.Warning;
        }

        private void ValidateCameraView()
        {
            if (CameraViewValid)
                return;
            "Validate Camera View".Spit();
            LoadCameraView();
            CameraViewValid = true;
        }

        private void ValidateProgram()
        {
            if (ProgramCompiled)
                return;
            "Validate Program".Spit();
            Scene._GPUStatus = GPUStatus.OK;
            GpuCode = new StringBuilder();
            GpuLog = new StringBuilder();
            ProgramID = GL.CreateProgram();
            CreateShaders();
            Log("Linking program...");
            BindAttributes();
            GL.LinkProgram(ProgramID);
            GL.ValidateProgram(ProgramID);
            Log(GL.GetProgramInfoLog(ProgramID));
            Log("Done.");
            Scene._GPUCode = GpuCode.ToString().TrimEnd();
            Scene._GPULog = GpuLog.ToString().TrimEnd();
            SceneController.OnPropertyChanged(
                Scene,
                DisplayNames.GPUCode,
                DisplayNames.GPULog,
                DisplayNames.GPUStatus);
            GpuCode = null;
            GpuLog = null;
            GetUniformLocations();
            DeleteShaders();
            ProgramCompiled = true;
        }

        private void ValidateProjection()
        {
            if (ProjectionValid)
                return;
            "Validate Projection".Spit();
            GL.Viewport(GLControl.Size);
            LoadProjection();
            ProjectionValid = true;
        }

        private void ValidateTrace(Trace trace)
        {
            if (trace._VaoValid)
                return;
            $"Validate Trace '{trace}'".Spit();
            DeleteTraceVao(trace);
            var coords = Entity.GetCoordinates(trace.StripCount);
            var indices = Entity.GetIndices(trace.Pattern, trace.StripCount);
            GL.BindVertexArray(trace._VaoID = CreateVao());
            trace._VboIndexID = BindIndicesBuffer(indices);
            trace._VboVertexID = StoreDataInAttributeList(0, coords);
            trace._VaoVertexCount = indices.Length;
            trace._VaoValid = true;
        }

        #endregion

        #region Load / Unload Traces

        private int BindIndicesBuffer(int[] indices)
        {
            var vboID = CreateVbo();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);
            return vboID;
        }

        private int CreateVao()
        {
            GL.GenVertexArrays(1, out int vaoID);
            return vaoID;
        }

        private int CreateVbo()
        {
            GL.GenBuffers(1, out int vboID);
            return vboID;
        }

        private void DeleteVao(ref int vaoID)
        {
            if (vaoID != 0)
            {
                GL.DeleteVertexArray(vaoID);
                vaoID = 0;
            }
        }

        private void DeleteVbo(ref int vboID)
        {
            if (vboID != 0)
            {
                GL.DeleteBuffer(vboID);
                vboID = 0;
            }
        }

        private int StoreDataInAttributeList(int attributeNumber, float[] data)
        {
            var vboID = CreateVbo();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attributeNumber, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            return vboID;
        }

        private void UnloadTraces()
        {
            foreach (var trace in Scene.Traces)
                InvalidateTrace(trace);
        }

        #endregion

        #region Render

        private bool MakeCurrent(bool current)
        {
            if (!GLControl.HasValidContext)
                return false;
            if (current)
            {
                CurrencyCount++;
                if (CurrencyCount == 1)
                    GLControl.MakeCurrent();
            }
            else
            {
                CurrencyCount--;
                if (CurrencyCount == 0)
                    GLControl.Context.MakeCurrent(null);
            }
            return true;
        }

        #endregion

        #region Uniforms

        private int GetUniformLocation(string uniformName) => GL.GetUniformLocation(ProgramID, uniformName);

        private void GetUniformLocations()
        {
            Loc_CameraView = GetUniformLocation("cameraView");
            Loc_Projection = GetUniformLocation("projection");
            Loc_TimeValue = GetUniformLocation("timeValue");
            Loc_TraceIndex = GetUniformLocation("traceIndex");
            Loc_Transform = GetUniformLocation("transform");
        }

        //private static void LoadBoolean(int location, bool value) => GL.Uniform1(location, value ? 1f : 0f);
        private static void LoadFloat(int location, float value) => GL.Uniform1(location, value);
        private static void LoadInt(int location, int value) => GL.Uniform1(location, value);
        private static void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);
        //private static void LoadVector(int location, Vector3 value) => GL.Uniform3(location, value);

        private void LoadProjection() => LoadMatrix(Loc_Projection, Scene.GetProjection());
        private void LoadTimeValue() => LoadFloat(Loc_TimeValue, (float)Clock.VirtualSecondsElapsed);
        private void LoadTraceIndex(int traceIndex) => LoadInt(Loc_TraceIndex, traceIndex);
        private void LoadTransform(Trace trace) => LoadMatrix(Loc_Transform, trace.GetTransform());
        private void LoadCameraView() => LoadMatrix(Loc_CameraView, Scene.GetCameraView());

        #endregion

        #endregion
    }
}
