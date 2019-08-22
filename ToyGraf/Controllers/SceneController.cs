namespace ToyGraf.Controllers
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using ToyGraf.Commands;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;
    using ToyGraf.Models.Enums;
    using ToyGraf.Properties;
    using ToyGraf.Views;

    internal class SceneController
    {
        #region Constructors

        internal SceneController()
        {
            SceneForm = new SceneForm();
            Scene = new Scene(this);
            CommandProcessor = new CommandProcessor(this);
            FullScreenController = new FullScreenController(this);
            JsonController = new JsonController(this);
            PropertyGridController = new PropertyGridController(this);
            TraceTableController = new TraceTableController(this);
            ConnectAll(true);
        }

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor { get; private set; }
        internal readonly PropertyGridController PropertyGridController;
        internal Scene Scene;
        internal SceneForm SceneForm;
        internal readonly TraceTableController TraceTableController;

        #endregion

        #region Internal Methods

        private void ConnectControllers(bool connect)
        {
            if (connect)
            {
                PropertyGridController.SelectedObject = Scene;
            }
            else
            {
                PropertyGridController.SelectedObject = null;
            }
        }

        internal void BeginUpdate() => ++UpdateCount;

        internal void EndUpdate()
        {
            if (--UpdateCount == 0)
            {
                foreach (var propertyName in ChangedPropertyNames)
                    OnPropertyChanged(propertyName);
                ChangedPropertyNames.Clear();
            }
        }

        internal static void InitTextureDialog(OpenFileDialog dialog)
        {
            dialog.Filter = Settings.Default.ImageFilter;
            dialog.Title = "Select Texture";
        }

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => SceneForm.Text = JsonController.WindowCaption;

        internal void OnPropertyChanged(params string[] propertyNames)
        {
            if (Updating)
            {
                ChangedPropertyNames.AddRange(propertyNames.Where(p => !ChangedPropertyNames.Contains(p)));
                return;
            }
            System.Diagnostics.Debug.WriteLine(
                $"SceneController.OnPropertyChanged({propertyNames.Aggregate((s, t) => $"{s}, {t}")})");
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case DisplayNames.FPS:
                        TimerInit();
                        break;
                    case DisplayNames.Shader1Vertex:
                    case DisplayNames.Shader2TessControl:
                    case DisplayNames.Shader3TessEvaluation:
                    case DisplayNames.Shader4Geometry:
                    case DisplayNames.Shader5Fragment:
                    case DisplayNames.Shader6Compute:
                    case DisplayNames.Traces:
                        InvalidateProgram();
                        break;
                }
            PropertyGridController.Refresh();
            TraceTableController.Refresh();
        }

        internal void OnSelectionChanged() => PropertyGridController.Refresh();

        /// <summary>
        /// When the PropertyGrid signals editing of a subproperty, it has already modified the
        /// parent property directly, bypassing the Command pattern. Therefore we need to spoof the
        /// appropriate command, to ensure the undo/redo mechanism is kept in sync with the state of
        /// the model.
        /// </summary>
        /// <param name="e">The EventArgs from the original event.</param>
        internal bool PropertyChanged(PropertyValueChangedEventArgs e)
        {
            var item = e.ChangedItem;
            var label = item.Label;
            var parentItem = item.Parent;
            var parentLabel = parentItem.Label;
            var value = e.OldValue;
            var scene = PropertyGrid.SelectedObject;
            if (scene != null)
                Spoof(Spoof(parentLabel, label, value));
            else
                foreach (Trace trace in PropertyGrid.SelectedObjects)
                    Spoof(Spoof(trace, parentLabel, label, value));
            return true;
        }

        internal void ShowOpenGLSLBook(PropertyGrid propertyGrid) =>
            $"{GLSLUrl}{GetBookmark(propertyGrid)}".Launch();

        internal void Show() => SceneForm.Show();

        #endregion

        #region Private Event Handlers

        private void SceneForm_FormClosed(object sender, FormClosedEventArgs e) => FormClosed();
        private void SceneForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);

        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => SaveFile();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => SaveFileAs();
        private void FileClose_Click(object sender, System.EventArgs e) => SceneForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();

        private void TbOpen_DropDownOpening(object sender, EventArgs e) => SceneForm.FileReopen.CloneTo(SceneForm.tbOpen);
        private void TbSave_Click(object sender, EventArgs e) => SaveOrSaveAs();

        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) =>
            ShowOpenGLSLBook(SceneForm.PropertyGrid);

        private void HelpAbout_Click(object sender, System.EventArgs e) => HelpAbout();

        private void HelpAbout() => new AboutController().ShowDialog(SceneForm);

        private void JsonController_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonController_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonController_FilePathRequest(object sender, SdiController.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonController_FileReopen(object sender, SdiController.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonController_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        private void Scene_PropertyChanged(object sender, PropertyChangedEventArgs e) => OnPropertyChanged(e.PropertyName);

        #endregion

        #region Private Properties

        private readonly List<string> ChangedPropertyNames = new List<string>();
        private readonly FullScreenController FullScreenController;
        private GLControl GLControl => SceneForm?.GLControl;
        private const string GLSLUrl = "https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html";
        private readonly JsonController JsonController;
        private PropertyGrid PropertyGrid => PropertyGridController.PropertyGrid;
        private Timer Timer;
        private int UpdateCount;
        private bool Updating => UpdateCount > 0;

        #endregion

        #region Private Methods

        private void ConnectAll(bool connect)
        {
            if (connect)
            {
                ConnectEventHandlers(true);
                ConnectControllers(true);
                CommandProcessor.Clear();
                Timer = new Timer();
                Timer.Tick += Timer_Tick;
                TimerStart();
            }
            else
            {
                TimerStop();
                Timer.Tick -= Timer_Tick;
                InvalidateProgram();
                CommandProcessor.Clear();
                ConnectControllers(false);
                ConnectEventHandlers(false);
                AppController.Remove(this);
            }
        }

        private void ConnectEventHandlers(bool connect)
        {
            if (connect)
            {
                SceneForm.FormClosed += SceneForm_FormClosed;
                SceneForm.FormClosing += SceneForm_FormClosing;

                SceneForm.FileNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click += FileOpen_Click;
                SceneForm.FileSave.Click += FileSave_Click;
                SceneForm.FileSaveAs.Click += FileSaveAs_Click;
                SceneForm.FileClose.Click += FileClose_Click;
                SceneForm.FileExit.Click += FileExit_Click;
                SceneForm.EditOptions.Click += EditOptions_Click;

                SceneForm.tbNew.ButtonClick += FileNewEmptyScene_Click;
                SceneForm.tbNewEmptyScene.Click += FileNewEmptyScene_Click;
                SceneForm.tbNewFromTemplate.Click += FileNewFromTemplate_Click;
                SceneForm.tbOpen.ButtonClick += FileOpen_Click;
                SceneForm.tbOpen.DropDownOpening += TbOpen_DropDownOpening;
                SceneForm.tbSave.Click += TbSave_Click;

                SceneForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                SceneForm.HelpAbout.Click += HelpAbout_Click;

                GLControl.ClientSizeChanged += GLControl_ClientSizeChanged;
                GLControl.Load += GLControl_Load;
                GLControl.Paint += GLControl_Paint;
                GLControl.Resize += GLControl_Resize;

                JsonController.FileLoaded += JsonController_FileLoaded;
                JsonController.FilePathChanged += JsonController_FilePathChanged;
                JsonController.FilePathRequest += JsonController_FilePathRequest;
                JsonController.FileReopen += JsonController_FileReopen;
                JsonController.FileSaving += JsonController_FileSaving;
                JsonController.FileSaved += JsonController_FileSaved;
            }
            else
            {
                SceneForm.FormClosed -= SceneForm_FormClosed;
                SceneForm.FormClosing -= SceneForm_FormClosing;

                SceneForm.FileNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.FileNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.FileOpen.Click -= FileOpen_Click;
                SceneForm.FileSave.Click -= FileSave_Click;
                SceneForm.FileSaveAs.Click -= FileSaveAs_Click;
                SceneForm.FileClose.Click -= FileClose_Click;
                SceneForm.FileExit.Click -= FileExit_Click;
                SceneForm.EditOptions.Click -= EditOptions_Click;

                SceneForm.tbNew.ButtonClick -= FileNewEmptyScene_Click;
                SceneForm.tbNewEmptyScene.Click -= FileNewEmptyScene_Click;
                SceneForm.tbNewFromTemplate.Click -= FileNewFromTemplate_Click;
                SceneForm.tbOpen.ButtonClick -= FileOpen_Click;
                SceneForm.tbOpen.DropDownOpening -= TbOpen_DropDownOpening;
                SceneForm.tbSave.Click -= TbSave_Click;

                SceneForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                SceneForm.HelpAbout.Click -= HelpAbout_Click;

                GLControl.ClientSizeChanged -= GLControl_ClientSizeChanged;
                GLControl.Load -= GLControl_Load;
                GLControl.Paint -= GLControl_Paint;
                GLControl.Resize -= GLControl_Resize;

                JsonController.FileLoaded -= JsonController_FileLoaded;
                JsonController.FilePathChanged -= JsonController_FilePathChanged;
                JsonController.FilePathRequest -= JsonController_FilePathRequest;
                JsonController.FileReopen -= JsonController_FileReopen;
                JsonController.FileSaving -= JsonController_FileSaving;
                JsonController.FileSaved -= JsonController_FileSaved;
            }
        }

        private void EditOptions()
        {
            using (var optionsController = new OptionsController(this))
                optionsController.ShowModal(SceneForm);
        }

        private void FileLoaded()
        {
            ConnectControllers(false);
            Scene.SceneController = this;
            BeginUpdate();
            Scene.AttachTraces();
            CommandProcessor.Clear();
            EndUpdate();
            ConnectControllers(true);
        }

        private void FilePathRequest(SdiController.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void FileSaved()
        {
            BeginUpdate();
            CommandProcessor.Save();
            EndUpdate();
        }

        private bool FormClosing(CloseReason closeReason) => JsonController.SaveIfModified();

        private void FormClosed() => ConnectAll(false);

        private static string GetBookmark(PropertyGrid propertyGrid)
        {
            switch (propertyGrid.SelectedGridItem?.PropertyDescriptor.Name)
            {
                case "Shader1Vertex":
                    return "#vertex-processor";
                case "Shader2TessControl":
                    return "#tessellation-control-processor";
                case "Shader3TessEvaluation":
                    return "#tessellation-evaluation-processor";
                case "Shader4Geometry":
                    return "#geometry-processor";
                case "Shader5Fragment":
                    return "#fragment-processor";
                case "Shader6Compute":
                    return "#compute-processor";
                default:
                    return string.Empty;
            }
        }

        private int GetFrameMilliseconds() => (int)Math.Round(1000 / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private SceneController GetNewSceneController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewSceneController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        private void NewEmptyScene()
        {
            GetNewSceneController();
            CommandProcessor.Clear();
        }

        private void NewFromTemplate()
        {
            var sceneController = OpenFile(FilterIndex.Template);
            if (sceneController != null)
                sceneController.JsonController.FilePath = string.Empty;
        }

        private SceneController OpenFile(FilterIndex filterIndex = FilterIndex.File) =>
            OpenFile(JsonController.SelectFilePath(filterIndex));

        private SceneController OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var sceneController = GetNewSceneController();
            sceneController?.LoadFromFile(filePath);
            return sceneController;
        }

        private bool SaveFile() => JsonController.Save();
        private bool SaveFileAs() => JsonController.SaveAs();
        private bool SaveOrSaveAs() => Scene.IsModified ? SaveFile() : SaveFileAs();

        private void Spoof(ICommand command) => CommandProcessor.Run(command, true);

        private ICommand Spoof(string property, string field, object value)
        {
            switch (property)
            {
                case DisplayNames.AccumColourFormat:
                    return new AccumColourFormatCommand(new ColourFormat(Scene.AccumColourFormat, field, (int)value));
                case DisplayNames.ColourFormat:
                    return new ColourFormatCommand(new ColourFormat(Scene.ColourFormat, field, (int)value));
                case DisplayNames.CameraPosition:
                    return new CameraPositionCommand(new Point3F(Scene.CameraPosition, field, (float)value));
                case DisplayNames.CameraRotation:
                    return new CameraRotationCommand(new Euler3F(Scene.CameraRotation, field, (float)value));
            }
            return null;
        }

        private ICommand Spoof(Trace trace, string property, string field, object value)
        {
            var index = trace.Index;
            switch (property)
            {
                case DisplayNames.Location:
                    return new LocationCommand(index, new Point3F(trace.Location, field, (float)value));
                case DisplayNames.Maximum:
                    return new MaximumCommand(index, new Point3F(trace.Maximum, field, (float)value));
                case DisplayNames.Minimum:
                    return new MinimumCommand(index, new Point3F(trace.Minimum, field, (float)value));
                case DisplayNames.Orientation:
                    return new OrientationCommand(index, new Euler3F(trace.Orientation, field, (float)value));
                case DisplayNames.Scale:
                    return new ScaleCommand(index, new Point3F(trace.Scale, field, (float)value));
                case DisplayNames.StripCount:
                    return new StripCountCommand(index, new Point3(trace.StripCount, field, (int)value));
            }
            return null;
        }

        private void UpdateCaption() { SceneForm.Text = JsonController.WindowCaption; }

        #endregion

        #region Render Event Handlers

        private void GLControl_ClientSizeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("DisplaySize");
            InitViewport();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e) { Render(); }

        #endregion

        #region Renderer Properties

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

        private void InvalidateProgram()
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
            OnPropertyChanged(
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

        private bool InitViewport()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                GL.Viewport(GLControl.Size);
                MakeCurrent(false);
            }
            return result;
        }

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

        private void Render()
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

        #region Timer

        private void TimerInit() => Timer.Interval = GetFrameMilliseconds();
        private void TimerStart() { TimerInit(); Timer.Start(); }
        private void TimerStop() => Timer.Stop();

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

        private void LoadBoolean(int location, bool value) => GL.Uniform1(location, value ? 1f : 0f);
        private void LoadFloat(int location, float value) => GL.Uniform1(location, value);
        private void LoadInt(int location, int value) => GL.Uniform1(location, value);
        private void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);
        private void LoadVector(int location, Vector3 value) => GL.Uniform3(location, value);

        private void LoadProjection() => LoadMatrix(Loc_Projection, Scene.GetProjection());
        private void LoadTimeValue() => LoadFloat(Loc_TimeValue, 0f);
        private void LoadTraceIndex(int traceIndex) => LoadInt(Loc_TraceIndex, traceIndex);
        private void LoadTransform(Trace trace) => LoadMatrix(Loc_Transform, trace.GetTransform());
        private void LoadCameraView() => LoadMatrix(Loc_CameraView, Scene.GetCameraView());

        #endregion

        #endregion
    }
}
