// <copyright file="JsonController.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controllers
{
    using Newtonsoft.Json;
    using System;
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
        internal JsonController(SceneController sceneController)
            : base(sceneController, Properties.Settings.Default.FileFilter, "LibraryMRU")
        { }

        internal string WindowCaption
        {
            get
            {
                var text = Path.GetFileNameWithoutExtension(FilePath).ToFilename();
                if (Scene.IsModified)
                    text = string.Concat("* ", text);
                text = string.Concat(text, " - ", Application.ProductName);
                return text;
            }
        }

        protected override void ClearDocument() => Scene.Clear();

        protected override bool LoadFromStream(Stream stream)
        {
            bool result;
            using (var streamer = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamer))
                result = UseStream(() => Scene = GetSerializer().Deserialize<Scene>(reader));
            return result;
        }

        protected override void OnFileReopen(string filePath) =>
            FileReopen?.Invoke(this, new FilePathEventArgs(filePath));

        internal event EventHandler<FilePathEventArgs> FileReopen;

        protected override bool SaveToStream(Stream stream)
        {
            using (var streamer = new StreamWriter(stream))
            using (var writer = new JsonTextWriter(streamer))
                return UseStream(() => GetSerializer().Serialize(writer, Scene));
        }

        private Control View => SceneController.SceneForm;

        private static JsonSerializer GetSerializer() => new JsonSerializer
        {
            DefaultValueHandling = DefaultValueHandling.Include,
            Formatting = Formatting.Indented
        };
    }
}
