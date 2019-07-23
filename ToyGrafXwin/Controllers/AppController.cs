namespace ToyGrafXwin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ToyGrafXwin.Views;

    internal static class AppController
    {
        static AppController()
        {
            Timer = new Timer
            {
                Interval = 5000,
                Enabled = true
            };
            Timer.Tick += Timer_Tick;
            AddNewSceneController();
            //ApplyOptions();
        }

        private static SceneController AddNewSceneController()
        {
            var sceneController = new SceneController();
            SceneControllers.Add(sceneController);
            sceneController.Show(null);
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

        internal static void Close() => Application.Exit();

        internal static void Remove(SceneController sceneController)
        {
            SceneControllers.Remove(sceneController);
            if (SceneControllers.Count == 0)
                Application.Exit();
        }

        internal static List<SceneController> SceneControllers = new List<SceneController>();

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Dispose();
            Timer = null;
            AboutDialog.Hide();
        }

        private static AboutDialog _AboutDialog;
        private static Timer Timer;
    }
}
