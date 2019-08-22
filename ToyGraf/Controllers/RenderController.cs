﻿namespace ToyGraf.Controllers
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Text;
    using ToyGraf.Commands;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public class RenderController
    {
        #region Constructor

        internal RenderController(SceneController sceneController)
        {
            SceneController = sceneController;
        }

        #endregion

        #region Internal Methods

        internal bool InitViewport()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                GL.Viewport(GLControl.Size);
                MakeCurrent(false);
            }
            return result;
        }

        internal void InvalidateProgram()
        {
            System.Diagnostics.Debug.WriteLine("SceneController.InvalidateProgram();");
            ProgramCompiled = false;
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
                RenderFrame();
            GLControl.SwapBuffers();
            MakeCurrent(false);
        }

        #endregion

        #region Private Properties

        private GLControl GLControl => SceneForm.GLControl;
        private Scene Scene => SceneController.Scene;
        private SceneController SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;

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
            ProgramCompiled;

        private bool
            ProgramValid => ProgramCompiled && Scene._GPUStatus == GPUStatus.OK;

        private StringBuilder
            GpuCode,
            GpuLog;

        #endregion

        #region Renderer Methods

        #region Create / Delete Shaders

        private void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes()
        {
            BindAttribute(0, "position");
        }

        private int CreateShader(ShaderType shaderType, bool mandatory = false)
        {
            StringBuilder shader = null;
            for (var traceIndex = 0; traceIndex < Scene._Traces.Count; traceIndex++)
            {
                var trace = Scene._Traces[traceIndex];
                var script = trace.GetScript(shaderType);
                if (!string.IsNullOrWhiteSpace(script))
                {
                    if (shader == null)
                    {
                        shader = new StringBuilder();
                        shader.AppendLine(Scene.GetScript(shaderType));
                    }
                    shader.AppendLine($@"  case {traceIndex}:
{script}
   break;
");
                }
            }
            if (shader == null)
            {
                if (mandatory)
                    Log("ERROR: Mandatory shader missing.");
                return 0;
            }
            shader.AppendLine(@"  default:
   break;
 }
}");
            Log($"Compiling {shaderType.GetShaderName()}...");
            var shaderID = GL.CreateShader(shaderType);
            GpuCode.Append(shader).AppendLine();
            GL.ShaderSource(shaderID, shader.ToString());
            GL.CompileShader(shaderID);
            GL.AttachShader(ProgramID, shaderID);
            Log(GL.GetShaderInfoLog(shaderID));
            return shaderID;
        }

        private void CreateShaders()
        {
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

        private void ValidateProgram()
        {
            if (ProgramCompiled)
                return;
            System.Diagnostics.Debug.WriteLine("SceneController.ValidateProgram();");
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
                DisplayNames.GPUCode,
                DisplayNames.GPULog,
                DisplayNames.GPUStatus);
            GpuCode = null;
            GpuLog = null;
            GetUniformLocations();
            DeleteShaders();
            ProgramCompiled = true;
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

        private bool Reload()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                UnloadTraces();
                ReloadTraces();
                MakeCurrent(false);
            }
            return result;
        }

        private void ReloadTraces()
        {
            ShaderStart();
            LoadProjection();
            LoadCameraView();
            for (int traceIndex = 0; traceIndex < Scene._Traces.Count; traceIndex++)
            {
                var trace = Scene._Traces[traceIndex];
                var coords = Grids.GetGrid(trace.StripCount);
                var indices = Grids.GetIndices(trace.StripCount, trace.Pattern);
                GL.BindVertexArray(trace.VaoID = CreateVao());
                trace.IndexVboID = BindIndicesBuffer(indices);
                trace.VertexVboID = StoreDataInAttributeList(0, coords);
                UnbindVao();
            }
            ShaderStop();
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

        private void UnbindVao() => GL.BindVertexArray(0);

        private bool Unload()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                UnloadTraces();
                MakeCurrent(false);
            }
            return result;
        }

        private void UnloadTraces()
        {
            for (int traceIndex = 0; traceIndex < Scene._Traces.Count; traceIndex++)
            {
                var trace = Scene._Traces[traceIndex];
                DeleteVbo(ref trace.VertexVboID);
                DeleteVbo(ref trace.IndexVboID);
                DeleteVao(ref trace.VaoID);
            }
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

        private void RenderFrame()
        {
            ShaderStart();
            for (int traceIndex = 0; traceIndex < Scene._Traces.Count; traceIndex++)
            {
                var trace = Scene._Traces[traceIndex];
                LoadTraceIndex(traceIndex);
                LoadTransform(trace);
                GL.BindVertexArray(trace.VaoID);
                GL.EnableVertexAttribArray(0);

                GL.DisableVertexAttribArray(0);
                GL.BindVertexArray(0);
            }
            ShaderStop();
        }

        private bool ShaderStart() => UseProgram(true);
        private bool ShaderStop() => UseProgram(false);

        private bool UseProgram(bool use)
        {
            var result = MakeCurrent(true);
            if (result)
            {
                GL.UseProgram(use ? ProgramID : 0);
                MakeCurrent(false);
            }
            return result;
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

        private static void LoadBoolean(int location, bool value) => GL.Uniform1(location, value ? 1f : 0f);
        private static void LoadFloat(int location, float value) => GL.Uniform1(location, value);
        private static void LoadInt(int location, int value) => GL.Uniform1(location, value);
        private static void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);
        private static void LoadVector(int location, Vector3 value) => GL.Uniform3(location, value);

        private void LoadProjection() => LoadMatrix(Loc_Projection, Scene.GetProjection());
        private void LoadTimeValue() => LoadFloat(Loc_TimeValue, 0f);
        private void LoadTraceIndex(int traceIndex) => LoadInt(Loc_TraceIndex, traceIndex);
        private void LoadTransform(Trace trace) => LoadMatrix(Loc_Transform, trace.GetTransform());
        private void LoadCameraView() => LoadMatrix(Loc_CameraView, Scene.GetCameraView());

        #endregion

        #endregion

    }
}
