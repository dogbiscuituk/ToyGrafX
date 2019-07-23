namespace ToyGraf.Controllers
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ToyGraf.Engine.Controllers;
    using ToyGraf.Engine.Entities;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public class SceneController
    {
        public SceneController()
        {
            SceneForm = new SceneForm();
            Model = new Model();
            Renderer = new GLControlRenderer(SceneForm.GLControl);
            EntityTableController = new EntityTableController(this);
            FullScreenController = new FullScreenController(this);
            JsonController = new JsonController(Model, SceneForm, SceneForm.FileReopen);
            PropertyGridController = new PropertyGridController(this);
        }

        private SceneForm _SceneForm;
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
                    SceneForm.HelpAbout.Click += HelpAbout_Click;
                }
            }
        }

        internal Camera Camera => Renderer.Camera;
        internal readonly Model Model;
        internal GLControlRenderer Renderer;

        internal readonly EntityTableController EntityTableController;
        internal readonly PropertyGridController PropertyGridController;

        private readonly FullScreenController FullScreenController;
        private readonly JsonController JsonController;

        internal List<Entity> Entities = new List<Entity>();

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
        private void HelpAbout_Click(object sender, System.EventArgs e) => new AboutController().ShowDialog(SceneForm);

        #endregion

        #region Private Methods

        private bool FormClosing(CloseReason closeReason)
        {
            var cancel = !JsonController.SaveIfModified();
            if (!cancel)
            {
                Renderer.Stop();
                AppController.Remove(this);
            }
            return !cancel;
        }

        private void NewEmptyScene() { }
        private void NewFromTemplate() { }
        private void OpenFile() { }
        private bool SaveIfModified() => true;
        public void Show(IWin32Window owner) => SceneForm.Show(owner);

        #endregion
    }
}
