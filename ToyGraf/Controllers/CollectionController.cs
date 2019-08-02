namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Commands;
    using ToyGraf.Controls;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public static class CollectionController
    {
        public static void Init() => AttachEventHandlers(true);

        private static void TgCollectionEditor_CollectionFormLoad(object sender, EventArgs e)
        {
            if (sender is Form form)
            {
                form.Size = new Size(720, 540);
                form.Text = "Properties";
                if (form.Owner is SceneForm sceneForm)
                    form.Font = sceneForm.Font;
            }
        }

        public static void Cleanup() => AttachEventHandlers(false);

        private static void TgCollectionEditor_CollectionEdited(object sender, CollectionEditedEventArgs e)
        {
            if (e.DialogResult == DialogResult.OK && e.Value is List<Trace> editedTraces)
                Traces = editedTraces;
            // Scene.AttachTraces();
            CommandProcessor = null;
        }

        private static void TgCollectionEditor_CollectionFormShown(object sender, EventArgs e)
        {
            if (sender is Form form)
            {
                if (form.Owner is SceneForm sceneForm)
                    CommandProcessor = AppController.SceneControllers
                        .FirstOrDefault(p => p.SceneForm == sceneForm)
                        .CommandProcessor;
                var propertyGrid = form.Controls.Find("propertyBrowser", true)?[0] as PropertyGrid;
                PropertyGridController.HidePropertyPagesButton(propertyGrid);
                propertyGrid.HelpVisible = true;
            }
        }

        //private void TgCollectionEditor_CollectionFormHelpButtonClicked(object sender, CancelEventArgs e) => ShowOpenGLShadingLanguageBook();

        private static void TgFileNameEditor_InitDialog(object sender, InitDialogEventArgs e) =>
            SceneController.InitTextureDialog(e.OpenFileDialog);

        private static CommandProcessor CommandProcessor;
        private static Scene Scene => CommandProcessor?.Scene;
        private static List<Trace> Traces
        {
            get => Scene.Traces;
            set => Scene.Traces = value;
        }

        #region Private Methods

        private static void AttachEventHandlers(bool attach)
        {
            if (attach)
            {
                TgCollectionEditor.CollectionEdited += TgCollectionEditor_CollectionEdited;
                TgCollectionEditor.CollectionFormLoad += TgCollectionEditor_CollectionFormLoad;
                TgCollectionEditor.CollectionFormShown += TgCollectionEditor_CollectionFormShown;
                TgFileNameEditor.InitDialog += TgFileNameEditor_InitDialog;
            }
            else
            {
                TgCollectionEditor.CollectionEdited -= TgCollectionEditor_CollectionEdited;
                TgCollectionEditor.CollectionFormLoad -= TgCollectionEditor_CollectionFormLoad;
                TgCollectionEditor.CollectionFormShown -= TgCollectionEditor_CollectionFormShown;
                TgFileNameEditor.InitDialog -= TgFileNameEditor_InitDialog;
            }
        }

        #endregion
    }
}
