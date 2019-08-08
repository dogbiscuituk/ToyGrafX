namespace ToyGraf.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using ToyGraf.Commands;
    using ToyGraf.Engine;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;
    using ToyGraf.Models.Enums;
    using ToyGraf.Properties;
    using ToyGraf.Views;

    internal class SceneController
    {
        #region Internal Interface

        internal SceneController()
        {
            SceneForm = new SceneForm();
            Scene = new Scene(this);
            CommandProcessor = new CommandProcessor(this);
            Renderer = new GLControlRenderer(this);
            EntityTableController = new TraceTableController(this);
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

            PropertyGridController.SelectedObject = Scene;

            Timer = new Timer();
            Timer.Tick += Timer_Tick;
            TimerStart();
        }

        internal void BeginUpdate() => UpdateCount++;

        internal void EndUpdate()
        {
            if (--UpdateCount == 0)
                OnPropertyChanged(string.Empty);
        }

        internal static void InitTextureDialog(OpenFileDialog dialog)
        {
            dialog.Filter = Settings.Default.ImageFilter;
            dialog.Title = "Select Texture";
        }

        private void TimerInit() => Timer.Interval = GetFrameMilliseconds();
        private void TimerStart() { TimerInit(); Timer.Start(); }
        private void TimerStop() => Timer.Stop();
        private void Timer_Tick(object sender, EventArgs e) { Render(); }

        private int GetFrameMilliseconds() => (int)Math.Round(1000 / Math.Min(Math.Max(Scene.FPS, 1), int.MaxValue));

        private void Cleanup()
        {
            TimerStop();
            Timer.Tick -= Timer_Tick;
            AppController.Remove(this);
        }

        private void Scene_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            OnPropertyChanged(e.PropertyName);

        internal event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (Updating)
                return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch (propertyName)
            {
                case "FramesPerSecond":
                    TimerInit();
                    break;
            }
            PropertyGridController.Refresh();
        }

        internal SceneForm SceneForm
        {
            get => _SceneForm;
            set
            {
                if (SceneForm == value)
                    return;
                if (SceneForm != null)
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

                    SceneForm.CameraMoveLeft.Click -= CameraMoveLeft_Click;
                    SceneForm.CameraMoveRight.Click -= CameraMoveRight_Click;
                    SceneForm.CameraMoveUp.Click -= CameraMoveUp_Click;
                    SceneForm.CameraMoveDown.Click -= CameraMoveDown_Click;
                    SceneForm.CameraMoveIn.Click -= CameraMoveIn_Click;
                    SceneForm.CameraMoveOut.Click -= CameraMoveOut_Click;
                    SceneForm.CameraRotateLeft.Click -= CameraRotateLeft_Click;
                    SceneForm.CameraRotateRight.Click -= CameraRotateRight_Click;
                    SceneForm.CameraRotateUp.Click -= CameraRotateUp_Click;
                    SceneForm.CameraRotateDown.Click -= CameraRotateDown_Click;
                    SceneForm.CameraRotateAnticlockwise.Click -= CameraRotateAnticlockwise_Click;
                    SceneForm.CameraRotateClockwise.Click -= CameraRotateClockwise_Click;
                    SceneForm.CameraHome.Click -= CameraHome_Click;

                    SceneForm.HelpOpenGLShadingLanguage.Click -= HelpTheOpenGLShadingLanguage_Click;
                    SceneForm.HelpAbout.Click -= HelpAbout_Click;
                }
                _SceneForm = value;
                if (SceneForm != null)
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

                    SceneForm.CameraMoveLeft.Click += CameraMoveLeft_Click;
                    SceneForm.CameraMoveRight.Click += CameraMoveRight_Click;
                    SceneForm.CameraMoveUp.Click += CameraMoveUp_Click;
                    SceneForm.CameraMoveDown.Click += CameraMoveDown_Click;
                    SceneForm.CameraMoveIn.Click += CameraMoveIn_Click;
                    SceneForm.CameraMoveOut.Click += CameraMoveOut_Click;
                    SceneForm.CameraRotateLeft.Click += CameraRotateLeft_Click;
                    SceneForm.CameraRotateRight.Click += CameraRotateRight_Click;
                    SceneForm.CameraRotateUp.Click += CameraRotateUp_Click;
                    SceneForm.CameraRotateDown.Click += CameraRotateDown_Click;
                    SceneForm.CameraRotateAnticlockwise.Click += CameraRotateAnticlockwise_Click;
                    SceneForm.CameraRotateClockwise.Click += CameraRotateClockwise_Click;
                    SceneForm.CameraHome.Click += CameraHome_Click;

                    SceneForm.HelpOpenGLShadingLanguage.Click += HelpTheOpenGLShadingLanguage_Click;
                    SceneForm.HelpAbout.Click += HelpAbout_Click;
                }
            }
        }

        internal Camera Camera => Renderer.Camera;
        internal GLControlRenderer Renderer;
        internal Scene Scene;

        public CommandProcessor CommandProcessor { get; private set; }

        internal readonly TraceTableController EntityTableController;
        internal readonly PropertyGridController PropertyGridController;

        internal void Render() => Renderer.Render();
        internal void Show() => SceneForm.Show();

        #endregion

        #region Private Event Handlers

        private void SceneForm_FormClosed(object sender, FormClosedEventArgs e) { }
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

        private void CameraMoveLeft_Click(object sender, System.EventArgs e) => MoveCamera(CameraMove.Left);
        private void CameraMoveRight_Click(object sender, System.EventArgs e) => MoveCamera(CameraMove.Right);
        private void CameraMoveUp_Click(object sender, System.EventArgs e) => MoveCamera(CameraMove.Up);
        private void CameraMoveDown_Click(object sender, System.EventArgs e) => MoveCamera(CameraMove.Down);
        private void CameraMoveIn_Click(object sender, System.EventArgs e) => MoveCamera(CameraMove.In);
        private void CameraMoveOut_Click(object sender, System.EventArgs e) => MoveCamera(CameraMove.Out);
        private void CameraRotateLeft_Click(object sender, EventArgs e) => MoveCamera(CameraMove.YawLeft);
        private void CameraRotateRight_Click(object sender, EventArgs e) => MoveCamera(CameraMove.YawRight);
        private void CameraRotateUp_Click(object sender, EventArgs e) => MoveCamera(CameraMove.PitchUp);
        private void CameraRotateDown_Click(object sender, EventArgs e) => MoveCamera(CameraMove.PitchDown);
        private void CameraRotateAnticlockwise_Click(object sender, EventArgs e) => MoveCamera(CameraMove.RollLeft);
        private void CameraRotateClockwise_Click(object sender, EventArgs e) => MoveCamera(CameraMove.RollRight);
        private void CameraHome_Click(object sender, EventArgs e) => MoveCamera(CameraMove.Home);

        private void HelpTheOpenGLShadingLanguage_Click(object sender, EventArgs e) =>
            ShowOpenGLSLBook(SceneForm.PropertyGrid);

        private void HelpAbout_Click(object sender, System.EventArgs e) => new AboutController().ShowDialog(SceneForm);

        private void JsonController_FileLoaded(object sender, EventArgs e) => FileLoaded();
        private void JsonController_FilePathChanged(object sender, EventArgs e) => UpdateCaption();
        private void JsonController_FilePathRequest(object sender, SdiController.FilePathEventArgs e) => FilePathRequest(e);
        private void JsonController_FileReopen(object sender, SdiController.FilePathEventArgs e) => OpenFile(e.FilePath);
        private void JsonController_FileSaved(object sender, EventArgs e) => FileSaved();
        private void JsonController_FileSaving(object sender, CancelEventArgs e) => e.Cancel = false;

        #endregion

        #region Private Properties

        private SceneForm _SceneForm;

        private readonly FullScreenController FullScreenController;
        private readonly JsonController JsonController;
        private Timer Timer;
        private int UpdateCount;

        private bool Updating => UpdateCount > 0;

        private const string GLSLUrl = "https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.html";

        #endregion

        #region Non-Public Methods

        private void EditOptions()
        {
            using (var optionsController = new OptionsController(this))
                optionsController.ShowModal(SceneForm);
        }

        private void FileLoaded()
        {
            Scene.SceneController = this;
            BeginUpdate();
            Scene.AttachTraces();
            CommandProcessor.Clear();
            EndUpdate();
        }

        private void FilePathRequest(SdiController.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void FileSaved()
        {
            Camera.Fix();
        }

        private bool FormClosing(CloseReason closeReason)
        {
            var cancel = !JsonController.SaveIfModified();
            if (!cancel)
                Cleanup();
            return !cancel;
        }

        private static string GetBookmark(PropertyGrid propertyGrid)
        {
            switch (propertyGrid.SelectedGridItem?.PropertyDescriptor.Name)
            {
                case "Shader1_Vertex":
                    return "#vertex-processor";
                case "Shader2_TessControl":
                    return "#tessellation-control-processor";
                case "Shader3_TessEvaluation":
                    return "#tessellation-evaluation-processor";
                case "Shader4_Geometry":
                    return "#geometry-processor";
                case "Shader5_Fragment":
                    return "#fragment-processor";
                case "Shader6_Compute":
                    return "#compute-processor";
                default:
                    return string.Empty;
            }
        }

        private SceneController GetNewSceneController()
        {
            if (AppController.Options.OpenInNewWindow)
                return AppController.AddNewSceneController();
            if (!JsonController.SaveIfModified())
                return null;
            JsonController.Clear();
            return this;
        }

        internal void LoadFromFile(string filePath) => JsonController.LoadFromFile(filePath);

        private void MoveCamera(CameraMove cameraMove)
        {
            const float r = 2f, s = 0.02f;
            switch (cameraMove)
            {
                case CameraMove.Home: Camera.Reset(); break;
                case CameraMove.Left: Camera.X -= s; break;
                case CameraMove.Right: Camera.X += s; break;
                case CameraMove.Up: Camera.Y += s; break;
                case CameraMove.Down: Camera.Y -= s; break;
                case CameraMove.In: Camera.Z -= s; break;
                case CameraMove.Out: Camera.Z += s; break;
                case CameraMove.YawLeft: Camera.Yaw -= r; break;
                case CameraMove.YawRight: Camera.Yaw += r; break;
                case CameraMove.PitchUp: Camera.Pitch -= r; break;
                case CameraMove.PitchDown: Camera.Pitch += r; break;
                case CameraMove.RollLeft: Camera.Roll -= r; break;
                case CameraMove.RollRight: Camera.Roll += r; break;
            }
        }

        private void NewEmptyScene() => GetNewSceneController();

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

        internal void ShowOpenGLSLBook(PropertyGrid propertyGrid) =>
            $"{GLSLUrl}{GetBookmark(propertyGrid)}".Launch();

        private void UpdateCaption() { SceneForm.Text = JsonController.WindowCaption; }

        #endregion

        private enum CameraMove
        {
            Home,
            Left,
            Right,
            Up,
            Down,
            In,
            Out,
            YawLeft,
            YawRight,
            PitchUp,
            PitchDown,
            RollLeft,
            RollRight
        }
    }
}
