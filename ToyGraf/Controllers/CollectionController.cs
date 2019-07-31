﻿namespace ToyGraf.Controllers
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
        public static void Init()
        {
            TgCollectionEditor.CollectionEdited += TgCollectionEditor_CollectionEdited;
            TgCollectionEditor.CollectionFormShown += TgCollectionEditor_CollectionFormShown;
            TgFileNameEditor.InitDialog += TgFileNameEditor_InitDialog;
        }

        public static void Cleanup()
        {
            TgCollectionEditor.CollectionEdited -= TgCollectionEditor_CollectionEdited;
            TgCollectionEditor.CollectionFormShown -= TgCollectionEditor_CollectionFormShown;
            TgFileNameEditor.InitDialog -= TgFileNameEditor_InitDialog;
        }

        private static void TgCollectionEditor_CollectionEdited(object sender, CollectionEditedEventArgs e)
        {
            if (e.DialogResult == DialogResult.OK && e.Value is List<Trace> editedTraces)
                Traces = editedTraces;
            CommandProcessor = null;
        }

        private static void TgCollectionEditor_CollectionFormShown(object sender, EventArgs e)
        {
            if (sender is Form form)
            {
                form.Size = new Size(512, 512);
                form.Text = "Properties";
                if (form.Owner is SceneForm sceneForm)
                {
                    form.Font = sceneForm.Font;
                    CommandProcessor = AppController.SceneControllers
                        .FirstOrDefault(p => p.SceneForm == sceneForm)
                        .CommandProcessor;
                }
                var propertyGrid = form.Controls.Find("propertyBrowser", true)?[0] as PropertyGrid;
                PropertyGridController.HidePropertyPagesButton(propertyGrid);
                propertyGrid.HelpVisible = true;
            }
        }

        private static void TgFileNameEditor_InitDialog(object sender, InitDialogEventArgs e) =>
            SceneController.InitTextureDialog(e.OpenFileDialog);

        private static CommandProcessor CommandProcessor;
        private static Scene Scene => CommandProcessor?.Scene;
        private static List<Trace> Traces
        {
            get => Scene.Traces;
            set => Scene.Traces = value;
        }
    }
}