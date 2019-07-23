﻿namespace ToyGraf.Controllers
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;

    /// <summary>
    /// Extend SdiController to provide concrete I/O methods using Json data format.
    /// Maintain a "WindowCaption" property for the app, including the product name,
    /// current filename if any - otherwise "(untitled)" - and the "Modified" flag.
    /// </summary>
    internal class JsonController : SdiController
    {
        #region Internal Interface

        internal JsonController(Model model, Control view, ToolStripDropDownItem recentMenu)
            : base(model, Properties.Settings.Default.FileFilter, "LibraryMRU", recentMenu)
        {
            Model.PropertyChanged += Model_PropertyChanged;
            View = view;
        }

        internal string WindowCaption
        {
            get
            {
                var text = Path.GetFileNameWithoutExtension(FilePath).ToFilename();
                var modified = Model.Modified;
                if (modified)
                    text = string.Concat("* ", text);
                text = string.Concat(text, " - ", Application.ProductName);
                return text;
            }
        }

        #endregion

        #region Protected I/O Overrides

        protected override void ClearDocument() => Model.Clear();

        protected override bool LoadFromStream(Stream stream, string format)
        {
            bool result;
            using (var streamer = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamer))
                result = UseStream(() => Model = GetSerializer().Deserialize<Model>(reader));
            return result;
        }

        protected override void OnFileReopen(string filePath) =>
            FileReopen?.Invoke(this, new FilePathEventArgs(filePath));

        internal event EventHandler<FilePathEventArgs> FileReopen;

        protected override bool SaveToStream(Stream stream, string format)
        {
            using (var streamer = new StreamWriter(stream))
            using (var writer = new JsonTextWriter(streamer))
                return UseStream(() => GetSerializer().Serialize(writer, Model));
        }

        #endregion

        #region Private Implementation

        private readonly Control View;

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e) { }

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        #endregion
    }
}