namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal abstract class DockableEditController
    {
        #region Constructor

        protected DockableEditController(SceneController sceneController, string caption)
        {
            SceneController = sceneController;
            Caption = caption;
        }

        #endregion

        #region Protected Fields

        protected bool
            _EditControlDocked = true,
            _EditControlVisible = true;

        protected HostController _HostController;

        protected Scene Scene => SceneController.Scene;
        protected readonly SceneController SceneController;
        protected SceneForm SceneForm => SceneController.SceneForm;

        #endregion

        #region Protected Properties

        protected abstract Control EditControl { get; }

        protected bool EditControlDocked
        {
            get => _EditControlDocked;
            set
            {
                if (EditControlDocked == value)
                    return;
                _EditControlDocked = value;
                UpdateConfiguration();
                HostController.FormVisible = !value && _EditControlVisible;
            }
        }

        protected internal bool EditControlVisible
        {
            get => _EditControlVisible;
            set
            {
                if (EditControlVisible == value)
                    return;
                _EditControlVisible = value;
                UpdateConfiguration();
                Refresh();
            }
        }

        protected HostController HostController
        {
            get
            {
                if (_HostController == null)
                {
                    _HostController = new HostController(SceneForm, Caption, EditControl);
                    _HostController.HostFormClosing += HostController_HostFormClosing;
                }
                return _HostController;
            }
        }

        #endregion

        #region Protected Abstract Methods

        protected internal abstract void Refresh();
        protected abstract void UpdateConfiguration();

        #endregion

        #region Private Fields

        private readonly string Caption;

        #endregion

        #region Private Event Handlers

        private void HostController_HostFormClosing(object sender, FormClosingEventArgs e) =>
            EditControlVisible = false;

        #endregion
    }
}
