namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using ToyGraf.Commands;
    using ToyGraf.Engine.Controllers;
    using ToyGraf.Engine.Entities;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public class SceneController
    {
        #region Internal Interface

        public SceneController()
        {
            SceneForm = new SceneForm();
            Scene = new Scene(this);
            CommandProcessor = new CommandProcessor(this);
            Renderer = new GLControlRenderer(SceneForm.GLControl);
            EntityTableController = new EntityTableController(this);
            FullScreenController = new FullScreenController(this);

            JsonController = new JsonController(Scene, SceneForm, SceneForm.FileReopen);
            JsonController.FileLoaded += JsonController_FileLoaded;
            JsonController.FilePathChanged += JsonController_FilePathChanged;
            JsonController.FilePathRequest += JsonController_FilePathRequest;
            JsonController.FileReopen += JsonController_FileReopen;
            JsonController.FileSaving += JsonController_FileSaving;
            JsonController.FileSaved += JsonController_FileSaved;

            PropertyGridController = new PropertyGridController(this);
            Scene.PropertyChanged += Scene_PropertyChanged;

            var trace = Scene.NewTrace();
            trace.Script = new string[]
            {
                "z = sqrt(x*x+y*y)",
                "z = cos(20 * z - 10 * t) * exp(-3 * z)"
            };

            PropertyGridController.SelectedObjects = new[] { trace };
        }

        private void Scene_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            PropertyGridController.Refresh();

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

                    SceneForm.HelpAbout.Click += HelpAbout_Click;
                }
            }
        }

        internal Camera Camera => Renderer.Camera;
        internal ClockController ClockController => new ClockController(this);
        internal readonly Scene Scene;
        internal GLControlRenderer Renderer;

        public CommandProcessor CommandProcessor { get; private set; }

        internal readonly EntityTableController EntityTableController;
        internal readonly PropertyGridController PropertyGridController;

        internal List<Entity> Entities = new List<Entity>();

        internal void Render() => Renderer.Paint();
        internal void Show() => SceneForm.Show();

        #endregion

        #region Private Event Handlers

        private void SceneForm_FormClosed(object sender, FormClosedEventArgs e) { }
        private void SceneForm_FormClosing(object sender, FormClosingEventArgs e) => e.Cancel = !FormClosing(e.CloseReason);

        private void FileNewEmptyScene_Click(object sender, System.EventArgs e) => NewEmptyScene();
        private void FileNewFromTemplate_Click(object sender, System.EventArgs e) => NewFromTemplate();
        private void FileOpen_Click(object sender, System.EventArgs e) => OpenFile();
        private void FileSave_Click(object sender, System.EventArgs e) => JsonController.Save();
        private void FileSaveAs_Click(object sender, System.EventArgs e) => JsonController.SaveAs();
        private void FileClose_Click(object sender, System.EventArgs e) => SceneForm.Close();
        private void FileExit_Click(object sender, System.EventArgs e) => AppController.Close();
        private void EditOptions_Click(object sender, EventArgs e) => EditOptions();

        private void TbOpen_DropDownOpening(object sender, EventArgs e) => SceneForm.FileReopen.CloneTo(SceneForm.tbOpen);

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

        #endregion

        #region Private Methods

        private void EditOptions() => new OptionsController(this).ShowModal(SceneForm);

        private bool FormClosing(CloseReason closeReason)
        {
            var cancel = !JsonController.SaveIfModified();
            if (!cancel)
                AppController.Remove(this);
            return !cancel;
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

        private void OpenFile() { }

        private SceneController OpenFile(FilterIndex filterIndex = FilterIndex.File) =>
            OpenFile(JsonController.SelectFilePath(filterIndex));

        private SceneController OpenFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return null;
            var sceneController = GetNewSceneController();
            if (sceneController == null)
                return null;
            sceneController.LoadFromFile(filePath);
            return sceneController;
        }

        internal void LoadFromFile(string filePath)
        {
            JsonController.LoadFromFile(filePath);
        }

        #endregion

        #region File Operations

        private void FileLoaded()
        {
            CommandProcessor.Clear();
            UpdateUI();
        }

        private void FilePathRequest(SdiController.FilePathEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FilePath))
                e.FilePath = Scene.Title.ToFilename();
        }

        private void FileSaved() => Camera.Fix();

        private void UpdateCaption() { SceneForm.Text = JsonController.WindowCaption; }

        private void UpdateUI()
        {
            ClockController.UpdateTimeControls();
            PropertyGridController.Refresh();
        }

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
