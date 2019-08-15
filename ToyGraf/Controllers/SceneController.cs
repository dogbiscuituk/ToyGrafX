namespace ToyGraf.Controllers
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Forms;
    using ToyGraf.Commands;
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

        internal bool MakeCurrent(bool current)
        {
            if (!GLControl.HasValidContext)
                return false;
            if (current)
                GLControl.MakeCurrent();
            else
                GLControl.Context.MakeCurrent(null);
            return true;
        }

        internal void ShowOpenGLSLBook(PropertyGrid propertyGrid) =>
            $"{GLSLUrl}{GetBookmark(propertyGrid)}".Launch();

        internal void Render() { } // => Renderer.Render();
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

        private void GLControl_ClientSizeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("DisplaySize");
            if (MakeCurrent(true))
            {

                MakeCurrent(false);
            }
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
        }

        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) =>
            ShowOpenGLSLBook(SceneForm.PropertyGrid);

        private void HelpAbout_Click(object sender, System.EventArgs e) => new AboutController().ShowDialog(SceneForm);

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

            SceneForm.GLControl.ClientSizeChanged -= GLControl_ClientSizeChanged;
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

        private void TimerInit() => Timer.Interval = GetFrameMilliseconds();
        private void TimerStart() { TimerInit(); Timer.Start(); }
        private void TimerStop() => Timer.Stop();
        private void Timer_Tick(object sender, EventArgs e) { Render(); }

        private void UpdateCaption() { SceneForm.Text = JsonController.WindowCaption; }

        #endregion

        #region Renderer

        #region Properties

        private int
            ProgramID,
            VertexShaderID,
            TessControlShaderID,
            TessEvaluationShaderID,
            GeometryShaderID,
            FragmentShaderID,
            ComputeShaderID;

        #endregion

        #region Methods

        private void AppendLog(StringBuilder log, string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
                log.AppendLine(s);
        }

        private void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes()
        {
            BindAttribute(0, "position");
            BindAttribute(1, "time");
        }

        private void CreateProgram()
        {
            MakeCurrent(true);
            var log = new StringBuilder();
            ProgramID = GL.CreateProgram();
            CreateShaders(log);
            BindAttributes();
            GL.LinkProgram(ProgramID);
            GL.ValidateProgram(ProgramID);
            AppendLog(log, GL.GetProgramInfoLog(ProgramID));
            GetAllUniformLocations();

            Scene._GPUStatus = log.ToString();
            log = null;

            DeleteShaders();
            MakeCurrent(false);
        }

        private int CreateShader(ShaderType shaderType, StringBuilder log, bool mandatory = false)
        {
            var scripts = new StringBuilder();
            foreach (var trace in Scene._Traces)
            {
                var script = trace.GetScript(shaderType);
                if (!string.IsNullOrWhiteSpace(script))
                    scripts.AppendLine(script);
            }
            if (scripts.Length < 1)
                return 0;
            scripts.Insert(0, $@"// {shaderType}\n");
            scripts.Insert(0, '\n');
            scripts.Insert(0, $@"# {AppController.OpenGLProperties.OpenGLVersionNumber}\n");
            scripts.Insert(0, '\n');
            var shaderID = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderID, scripts.ToString());
            GL.CompileShader(shaderID);
            AppendLog(log, GL.GetShaderInfoLog(shaderID));
            GL.AttachShader(ProgramID, shaderID);
            return shaderID;
        }

        private void CreateShaders(StringBuilder log)
        {
            VertexShaderID = CreateShader(ShaderType.VertexShader, log, true);
            TessControlShaderID = CreateShader(ShaderType.TessControlShader, log);
            TessEvaluationShaderID = CreateShader(ShaderType.TessEvaluationShader, log);
            GeometryShaderID = CreateShader(ShaderType.GeometryShader, log);
            FragmentShaderID = CreateShader(ShaderType.FragmentShader, log, true);
            ComputeShaderID = CreateShader(ShaderType.ComputeShader, log);
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

        private void GetAllUniformLocations()
        {

        }

        #endregion

        #endregion
    }
}
