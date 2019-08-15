namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using ToyGraf.Engine;
    using ToyGraf.Models.Enums;
    using ToyGraf.Models.Structs;
    using ToyGraf.Properties;
    using ToyGraf.Views;

    internal static class AppController
    {
        static AppController()
        {
            CollectionController.Start();
            Timer = new Timer { Interval = 5000, Enabled = true };
            Timer.Tick += Timer_Tick;
            ApplyOptions();
            AddNewSceneController();
        }

        internal static SceneController AddNewSceneController()
        {
            var sceneController = new SceneController();
            SceneControllers.Add(sceneController);
            sceneController.Show();
            return sceneController;
        }

        internal static void Close()
        {
            CollectionController.Stop();
            Application.Exit();
        }

        internal static string GetDefaultFolder(FilterIndex filterIndex)
        {
            switch (filterIndex)
            {
                case FilterIndex.File:
                    return Options.FilesFolderPath;
                case FilterIndex.Template:
                    return Options.TemplatesFolderPath;
                default:
                    return string.Empty;
            }
        }

        internal static void Remove(SceneController sceneController)
        {
            SceneControllers.Remove(sceneController);
            if (SceneControllers.Count == 0)
                Close();
        }

        #region Internal Properties

        internal static AboutDialog AboutDialog
        {
            get
            {
                if (_AboutDialog == null)
                    _AboutDialog = new AboutController().View;
                return _AboutDialog;
            }
        }

        internal static OpenGLProperties OpenGLProperties
        {
            get
            {
                if (_OpenGLProperties == null)
                    _OpenGLProperties = new OpenGLProperties();
                return _OpenGLProperties;
            }
        }

        internal static Options Options
        {
            get
            {
                var options = new Options
                {
                    OpenInNewWindow = Settings.Options_OpenInNewWindow,
                    FilesFolderPath = Settings.FilesFolderPath,
                    TemplatesFolderPath = Settings.TemplatesFolderPath,
                };
                if (string.IsNullOrWhiteSpace(options.FilesFolderPath))
                    options.FilesFolderPath = DefaultFilesFolderPath;
                if (string.IsNullOrWhiteSpace(options.TemplatesFolderPath))
                    options.TemplatesFolderPath = $"{DefaultFilesFolderPath}\\Templates";
                return options;
            }
            set
            {
                Settings.Options_OpenInNewWindow = value.OpenInNewWindow;
                Settings.FilesFolderPath = value.FilesFolderPath;
                Settings.TemplatesFolderPath = value.TemplatesFolderPath;
                Settings.Save();
                ApplyOptions();
            }
        }

        internal static List<SceneController> SceneControllers = new List<SceneController>();

        #endregion

        #region Private Properties

        private static AboutDialog _AboutDialog;
        private static readonly string DefaultFilesFolderPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{Application.ProductName}";
        private static OpenGLProperties _OpenGLProperties;
        private static Settings Settings => Settings.Default;
        private static Timer Timer;

        #endregion

        #region Private Event Handlers

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            Timer.Dispose();
            Timer = null;
            AboutDialog.Hide();
        }

        #endregion

        #region Private Methods

        private static void ApplyOptions()
        {
            if (!Directory.Exists(Options.FilesFolderPath))
                Directory.CreateDirectory(Options.FilesFolderPath);
            if (!Directory.Exists(Options.TemplatesFolderPath))
                Directory.CreateDirectory(Options.TemplatesFolderPath);
        }

        #endregion
    }
}
