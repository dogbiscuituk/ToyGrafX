namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ToyGraf.Engine.Controllers;
    using ToyGraf.Engine.Entities;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class SceneController
    {
        #region Internal Interface

        internal SceneController(int sceneID)
        {
            SceneForm = new SceneForm();
            Scene = new Scene();
            Renderer = new GLControlRenderer(SceneForm.GLControl, sceneID);
            EntityTableController = new EntityTableController(this);
            FullScreenController = new FullScreenController(this);
            JsonController = new JsonController(Scene, SceneForm, SceneForm.FileReopen);
            PropertyGridController = new PropertyGridController(this);

            Trace = new Trace();
            PropertyGridController.SelectedObjects = new[] { Trace };
        }

        Trace Trace;

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

                    SceneForm.HelpAbout.Click += HelpAbout_Click;
                }
            }
        }

        internal Camera Camera => Renderer.Camera;
        internal readonly Scene Scene;
        internal GLControlRenderer Renderer;

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

        private void HelpAbout_Click(object sender, System.EventArgs e) => new AboutController().ShowDialog(SceneForm);

        #endregion

        #region Private Properties

        private SceneForm _SceneForm;

        private readonly FullScreenController FullScreenController;
        private readonly JsonController JsonController;

        #endregion

        #region Private Methods

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
            sceneController.JsonController.LoadFromFile(filePath);
            return sceneController;
        }

        #endregion

        private enum CameraMove
        {
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
