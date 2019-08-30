﻿// <copyright file="OptionsController.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controllers
{
    using System;
    using System.Windows.Forms;
    using ToyGraf.Models.Structs;
    using ToyGraf.Views;

    internal class OptionsController : IDisposable
    {
        internal OptionsController(SceneController sceneController)
        {
            SceneController = sceneController;
            OptionsDialog = new OptionsDialog();
            OptionsDialog.btnFilesFolder.Click += BtnFilesFolder_Click;
            OptionsDialog.btnTemplatesFolder.Click += BtnTemplatesFolder_Click;
        }

        internal DialogResult ShowModal(IWin32Window owner)
        {
            Options = AppController.Options;
            var result = OptionsDialog.ShowDialog(owner);
            if (result == DialogResult.OK)
                AppController.Options = Options;
            return result;
        }

        private readonly SceneController SceneController;
        private OptionsDialog OptionsDialog;
        private Options Options
        {
            get => GetOptions();
            set => SetOptions(value);
        }

        private void BtnFilesFolder_Click(object sender, EventArgs e) =>
            BrowseFolder("files", OptionsDialog.edFilesFolder);

        private void BtnTemplatesFolder_Click(object sender, EventArgs e) =>
            BrowseFolder("templates", OptionsDialog.edTemplatesFolder);

        private void BrowseFolder(string detail, TextBox textBox)
        {
            using (var dialog = new FolderBrowserDialog
            {
                Description = $"Select the default folder for storing scene {detail}:",
                SelectedPath = textBox.Text,
                ShowNewFolderButton = true
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    textBox.Text = dialog.SelectedPath;
            }
        }

        private Options GetOptions() => new Options
        {
            OpenInNewWindow = OptionsDialog.rbWindowNew.Checked,
            FilesFolderPath = OptionsDialog.edFilesFolder.Text,
            TemplatesFolderPath = OptionsDialog.edTemplatesFolder.Text,
            ShowSystemRO = OptionsDialog.cbShowSystemRO.Checked
        };

        private void SetOptions(Options options)
        {
            OptionsDialog.rbWindowNew.Checked = options.OpenInNewWindow;
            OptionsDialog.rbWindowReuse.Checked = !options.OpenInNewWindow;
            OptionsDialog.edFilesFolder.Text = options.FilesFolderPath;
            OptionsDialog.edTemplatesFolder.Text = options.TemplatesFolderPath;
            OptionsDialog.cbShowSystemRO.Checked = options.ShowSystemRO;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                DisposeOptionsDialog();
        }

        private void DisposeOptionsDialog()
        {
            if (OptionsDialog != null)
            {
                OptionsDialog.Dispose();
                OptionsDialog = null;
            }
        }
    }
}
