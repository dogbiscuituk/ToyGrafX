﻿namespace ToyGraf.Controllers
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using ToyGraf.Models;
    using ToyGraf.Models.Enums;

    /// <summary>
    /// "Single Document Interface" Controller.
    /// 
    /// Extend MruController to provide file Open and Save dialogs.
    /// Keep track of the document/model's "Modified" state, prompting for "Save" as necessary
    /// (for example, prior to "File|New" or "File|Open", or application closing).
    /// </summary>
    internal abstract class SdiController : MruController
    {
        #region Constructors

        protected SdiController(SceneController sceneController, string filter, string subKeyName)
            : base(sceneController, subKeyName)
        {
            OpenFileDialog = new OpenFileDialog { Filter = filter, Title = "Select the file to open" };
            SaveFileDialog = new SaveFileDialog { Filter = filter, Title = "Save file" };
        }

        #endregion

        #region Internal Interface

        internal void Clear()
        {
            FilePath = string.Empty;
            ClearDocument();
        }

        internal string SelectFilePath(FilterIndex filterIndex = FilterIndex.Default)
        {
            filterIndex = EvalFilterIndex(filterIndex);
            OpenFileDialog.FilterIndex = (int)filterIndex;
            InitFolderPath(OpenFileDialog, filterIndex);
            if (OpenFileDialog.ShowDialog() != DialogResult.OK)
                return null;
            return OpenFileDialog.FileName;
        }

        internal override void Reopen(ToolStripItem menuItem)
        {
            var filePath = menuItem.ToolTipText;
            if (!File.Exists(filePath))
            {
                if (MessageBox.Show(string.Format("File \"{0}\" no longer exists. Remove from menu?", filePath),
                    "Reopen file", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    RemoveItem(filePath);
                return;
            }
            OnFileReopen(filePath);

        }

        protected virtual void OnFileReopen(string filePath)
        {
            if (SaveIfModified())
                LoadFromFile(filePath);
        }

        internal bool Save(FilterIndex filterIndex = FilterIndex.Default) =>
            string.IsNullOrEmpty(FilePath)
            ? SaveAs(filterIndex)
            : SaveToFile(FilePath);

        internal bool SaveAs(FilterIndex filterIndex = FilterIndex.Default)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                OnFilePathRequest();
            SaveFileDialog.FileName = FilePath;
            filterIndex = EvalFilterIndex(filterIndex);
            InitFolderPath(SaveFileDialog, filterIndex);
            SaveFileDialog.FilterIndex = (int)filterIndex;
            return SaveFileDialog.ShowDialog() == DialogResult.OK
                && SaveToFile(SaveFileDialog.FileName);
        }

        private FilterIndex EvalFilterIndex(FilterIndex filterIndex)
        {
            if (filterIndex == FilterIndex.Default)
                switch (Path.GetExtension(FilePath))
                {
                    case ".tgt":
                        return FilterIndex.Template;
                    case ".tgf":
                    default:
                        return FilterIndex.File;
                }
            return filterIndex;
        }

        private void InitFolderPath(FileDialog dialog, FilterIndex filterIndex)
        {
            var folderPath = string.Empty;
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
                folderPath = Path.GetDirectoryName(dialog.FileName);
            if (string.IsNullOrWhiteSpace(folderPath))
                dialog.InitialDirectory = AppController.GetDefaultFolder(filterIndex);
        }

        internal bool SaveIfModified()
        {
            if (Scene.IsModified)
                switch (MessageBox.Show(
                    "The contents of this file have changed. Do you want to save the changes?",
                    "File modified",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        return Save();
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
            return true;
        }

        internal event EventHandler<CancelEventArgs> FileLoading, FileSaving;
        internal event EventHandler FileLoaded, FilePathChanged, FileSaved;
        internal event EventHandler<FilePathEventArgs> FilePathRequest;

        internal class FilePathEventArgs : EventArgs
        {
            internal FilePathEventArgs(string filePath) { FilePath = filePath; }
            internal string FilePath { get; set; }
        }

        #endregion

        #region Protected Properties

        protected internal string FilePath
        {
            get => _filePath;
            set
            {
                if (FilePath != value)
                {
                    _filePath = value;
                    OnFilePathChanged();
                }
            }
        }

        #endregion

        #region Private Properties

        private string _filePath = string.Empty;
        private readonly OpenFileDialog OpenFileDialog;
        private readonly SaveFileDialog SaveFileDialog;

        #endregion

        #region Protected Methods

        protected abstract void ClearDocument();

        protected abstract bool LoadFromStream(Stream stream);

        protected abstract bool SaveToStream(Stream stream);

        protected bool UseStream(Action action)
        {
            var result = true;
            try
            {
                action();
            }
            catch (Exception x)
            {
                MessageBox.Show(
                    x.Message,
                    x.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }

        protected virtual void OnFilePathChanged()
        {
            FilePathChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFileLoaded() => FileLoaded?.Invoke(this, EventArgs.Empty);

        protected virtual bool OnFileLoading()
        {
            var result = true;
            var fileLoading = FileLoading;
            if (fileLoading != null)
            {
                var e = new CancelEventArgs();
                fileLoading(this, e);
                result = !e.Cancel;
            }
            return result;
        }

        protected virtual void OnFileSaved() => FileSaved?.Invoke(this, EventArgs.Empty);

        protected virtual bool OnFileSaving()
        {
            var result = true;
            var fileSaving = FileSaving;
            if (fileSaving != null)
            {
                var e = new CancelEventArgs();
                fileSaving(this, e);
                result = !e.Cancel;
            }
            return result;
        }

        #endregion

        #region Private Methods

        internal bool LoadFromFile(string filePath)
        {
            var result = false;
            if (OnFileLoading())
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    result = LoadFromStream(stream);
                if (result)
                {
                    FilePath = filePath;
                    AddItem(filePath);
                    OnFileLoaded();
                }
            }
            return result;
        }

        private void OnFilePathRequest()
        {
            var e = new FilePathEventArgs(string.Empty);
            FilePathRequest?.Invoke(this, e);
            FilePath = e.FilePath;
        }

        private bool SaveToFile(string filePath)
        {
            var result = false;
            if (OnFileSaving())
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    result = SaveToStream(stream);
                    if (result)
                    {
                        FilePath = filePath;
                        AddItem(filePath);
                        OnFileSaved();
                    }
                }
            return result;
        }

        #endregion
    }
}
