namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using ToyGraf.Models.Structs;
    using ToyGraf.Views;

    internal static class AppController
    {
        static AppController()
        {
            RenderTimer = new Timer { Interval = 15, Enabled = true };
            SplashTimer = new Timer { Interval = 5000, Enabled = true };
            RenderTimer.Tick += RenderTimer_Tick;
            SplashTimer.Tick += SplashTimer_Tick;
            AddNewSceneController();
            ApplyOptions();
        }

        private static void RenderTimer_Tick(object sender, EventArgs e)
        {
            foreach (var sceneController in SceneControllers)
                sceneController.Render();
        }

        internal static SceneController AddNewSceneController()
        {
            var sceneController = new SceneController(SceneID++);
            SceneControllers.Add(sceneController);
            sceneController.Show();
            return sceneController;
        }

        internal static AboutDialog AboutDialog
        {
            get
            {
                if (_AboutDialog == null)
                    _AboutDialog = new AboutController().View;
                return _AboutDialog;
            }
        }

        internal static void Close()
        {
            if (RenderTimer != null)
            {
                RenderTimer.Enabled = false;
                RenderTimer.Dispose();
                RenderTimer = null;
            }
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

        private static Properties.Settings Settings => Properties.Settings.Default;
        private static int SceneID;

        internal static Options Options
        {
            get
            {
                var options = new Options
                {
                    OpenInNewWindow = Settings.Options_OpenInNewWindow,
                    GroupUndo = Settings.Options_GroupUndo,
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
                Settings.Options_GroupUndo = value.GroupUndo;
                Settings.FilesFolderPath = value.FilesFolderPath;
                Settings.TemplatesFolderPath = value.TemplatesFolderPath;
                Settings.Save();
                ApplyOptions();
            }
        }

        internal static List<SceneController> SceneControllers = new List<SceneController>();

        private static void SplashTimer_Tick(object sender, EventArgs e)
        {
            SplashTimer.Enabled = false;
            SplashTimer.Dispose();
            SplashTimer = null;
            AboutDialog.Hide();
        }

        private static readonly string DefaultFilesFolderPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{Application.ProductName}";
        private static AboutDialog _AboutDialog;
        private static Timer RenderTimer, SplashTimer;

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
