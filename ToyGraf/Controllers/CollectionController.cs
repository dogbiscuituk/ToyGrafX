namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Commands;
    using ToyGraf.Controls;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public static class CollectionController
    {
        #region Public Interface

        public static void Start() => AttachEventHandlers();

        public static void Stop()
        {
            DetachEventHandlers();
            SceneController = null;
        }

        #endregion

        #region Private Properties

        private static CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        private static Scene Scene => CommandProcessor?.Scene;
        private static SceneController SceneController;
        private static List<Trace> Traces
        {
            get => Scene?.Traces;
            set => Scene.Traces = value;
        }

        #endregion

        #region Private Event Handlers

        private static void TgCollectionEditor_CollectionEdited(object sender, CollectionEditedEventArgs e)
        {
            if (e.DialogResult == DialogResult.OK && e.Value is List<Trace> editedTraces)
                Traces = editedTraces;
            // Scene.AttachTraces();
        }

        private static void TgCollectionEditor_CollectionFormLoad(object sender, EventArgs e)
        {
            if (sender is Form form)
            {
                form.Size = new Size(720, 540);
                form.Text = "Properties";
                if (form.Owner is SceneForm sceneForm)
                {
                    form.Font = sceneForm.Font;
                    SceneController = AppController.SceneControllers
                        .FirstOrDefault(p => p.SceneForm == sceneForm);
                }
            }
            var propertyGrid = FindPropertyGrid(sender);
            PropertyGridController.HidePropertyPagesButton(propertyGrid);
            propertyGrid.HelpVisible = true;
        }

        private static void TgCollectionEditor_CollectionFormHelpButtonClicked(object sender, CancelEventArgs e) =>
            SceneController.ShowOpenGLSLBook(FindPropertyGrid(sender));

        private static void TgFileNameEditor_InitDialog(object sender, InitDialogEventArgs e) =>
            SceneController.InitTextureDialog(e.OpenFileDialog);

        #endregion

        #region Private Methods

        private static void AttachEventHandlers()
        {
            TgCollectionEditor.CollectionEdited += TgCollectionEditor_CollectionEdited;
            TgCollectionEditor.CollectionFormHelpButtonClicked += TgCollectionEditor_CollectionFormHelpButtonClicked;
            TgCollectionEditor.CollectionFormLoad += TgCollectionEditor_CollectionFormLoad;
            TgFileNameEditor.InitDialog += TgFileNameEditor_InitDialog;
        }

        private static void DetachEventHandlers()
        {
            TgCollectionEditor.CollectionEdited -= TgCollectionEditor_CollectionEdited;
            TgCollectionEditor.CollectionFormHelpButtonClicked -= TgCollectionEditor_CollectionFormHelpButtonClicked;
            TgCollectionEditor.CollectionFormLoad -= TgCollectionEditor_CollectionFormLoad;
            TgFileNameEditor.InitDialog -= TgFileNameEditor_InitDialog;
        }

        private static PropertyGrid FindPropertyGrid(object sender) =>
            ((Form)sender).Controls.Find("propertyBrowser", true)?[0] as PropertyGrid;

        #endregion
    }
}
