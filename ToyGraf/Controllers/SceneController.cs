namespace ToyGraf.Controllers
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
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
            TraceTableController = new TraceTableController(this);
            FullScreenController = new FullScreenController(this);

            JsonController = new JsonController(this);
            JsonController.FileLoaded += JsonController_FileLoaded;
            JsonController.FilePathChanged += JsonController_FilePathChanged;
            JsonController.FilePathRequest += JsonController_FilePathRequest;
            JsonController.FileReopen += JsonController_FileReopen;
            JsonController.FileSaving += JsonController_FileSaving;
            JsonController.FileSaved += JsonController_FileSaved;

            PropertyGridController = new PropertyGridController(this);
            Scene.PropertyChanged += Scene_PropertyChanged;

            AttachControllers();
            CommandProcessor.Clear();

            Timer = new Timer();
            Timer.Tick += Timer_Tick;
            TimerStart();
        }

        #endregion

        #region Internal Properties

        public CommandProcessor CommandProcessor { get; private set; }
        internal readonly PropertyGridController PropertyGridController;
        internal Scene Scene;
        internal readonly TraceTableController TraceTableController;

        internal SceneForm SceneForm
        {
            get => _SceneForm;
            set
            {
                if (SceneForm == value)
                    return;
                if (SceneForm != null)
                    DetachEventHandlers();
                _SceneForm = value;
                if (SceneForm != null)
                    AttachEventHandlers();
            }
        }

        #endregion

        #region Internal Methods

        internal void AttachControllers() => PropertyGridController.SelectedObject = Scene;
        internal void BeginUpdate() => UpdateCount++;
        internal void DetachControllers() => PropertyGridController.SelectedObject = null;
        internal void EndUpdate() { if (--UpdateCount == 0) OnPropertyChanged(string.Empty); }
        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);
        internal void ModifiedChanged() => SceneForm.Text = JsonController.WindowCaption;

        internal static void InitTextureDialog(OpenFileDialog dialog)
        {
            dialog.Filter = Settings.Default.ImageFilter;
            dialog.Title = "Select Texture";
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

        private void HelpAbout()
        {
            new AboutController().ShowDialog(SceneForm);
            CreateProgram();
            DeleteProgram();
        }

        private void JsonController_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonController_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonController_FilePathRequest(object sender, SdiController.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonController_FileReopen(object sender, SdiController.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonController_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        private void Scene_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            OnPropertyChanged(e.PropertyName);

        #endregion

        #region Private Properties

        private readonly FullScreenController FullScreenController;
        private GLControl GLControl => SceneForm?.GLControl;
        private const string GLSLUrl = "https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html";
        private readonly JsonController JsonController;
        private SceneForm _SceneForm;
        private readonly Timer Timer;
        private int UpdateCount;
        private bool Updating => UpdateCount > 0;

        #endregion

        #region Private Methods

        private void AttachEventHandlers()
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
        }

        private void Cleanup()
        {
            TimerStop();
            Timer.Tick -= Timer_Tick;
            AppController.Remove(this);
        }

        private void DetachEventHandlers()
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
        }

        private void EditOptions()
        {
            using (var optionsController = new OptionsController(this))
                optionsController.ShowModal(SceneForm);
        }

        private void FileLoaded()
        {
            DetachControllers();
            Scene.SceneController = this;
            BeginUpdate();
            Scene.AttachTraces();
            CommandProcessor.Clear();
            EndUpdate();
            AttachControllers();
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

        private void FormClosed() => Cleanup();

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

        private void OnPropertyChanged(string propertyName)
        {
            if (Updating)
                return;
            switch (propertyName)
            {
                case "FramesPerSecond":
                    TimerInit();
                    break;
            }
            PropertyGridController.Refresh();
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

        private StringBuilder ShaderLog;

        #endregion

        #region Renderer Methods

        #region Create / Delete Shaders

        private void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes()
        {
            BindAttribute(0, "position");
        }

        private void CreateProgram()
        {
            if (!MakeCurrent(true))
                return;
            Scene._GPUStatus = GPUStatus.OK;
            ShaderLog = new StringBuilder();
            ProgramID = GL.CreateProgram();
            CreateShaders();
            Log("Linking program...");
            BindAttributes();
            GL.LinkProgram(ProgramID);
            GL.ValidateProgram(ProgramID);
            Log(GL.GetProgramInfoLog(ProgramID));
            Log("Done.");
            Scene._GPULog = ShaderLog.ToString().TrimEnd();
            ShaderLog = null;
            GetUniformLocations();
            DeleteShaders();
            MakeCurrent(false);
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
                    shader.AppendLine($@"
        case {traceIndex}:
{script}
            break;");
                }
            }
            if (shader == null)
            {
                if (mandatory)
                    Log("ERROR: Mandatory shader missing.");
                return 0;
            }
            shader.AppendLine(@"
        default:
            break;
    }
}");
            Log($"Compiling {shaderType.GetShaderName()}...");
            var shaderID = GL.CreateShader(shaderType);
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

        private void DeleteProgram()
        {
            if (ProgramID == 0)
                return;
            DeleteShaders();
            GL.DeleteProgram(ProgramID);
            ProgramID = 0;
        }

        private void DeleteShader(ref int shaderID)
        {
            if (shaderID == 0)
                return;
            GL.DetachShader(ProgramID, shaderID);
            GL.DeleteShader(shaderID);
            shaderID = 0;
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
            ShaderLog.AppendLine(s.Trim());
            if (s.Contains("ERROR:"))
                Scene._GPUStatus |= GPUStatus.Error;
            if (s.Contains("WARNING:"))
                Scene._GPUStatus |= GPUStatus.Warning;
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

        private bool Render()
        {
            var result = MakeCurrent(true);
            if (result)
            {
                RenderFrame();
                MakeCurrent(false);
            }
            return result;
        }

        private void RenderFrame()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Scene.BackgroundColour);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
            GLControl.SwapBuffers();
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
