namespace ToyGraf.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal abstract class HostController
    {
        #region Constructor

        protected HostController(SceneController sceneController, string caption)
        {
            SceneController = sceneController;
            Caption = caption;
        }

        #endregion

        #region InternalProperties

        internal bool FormVisible
        {
            get => HostForm.Visible;
            set
            {
                if (HostForm.Visible == value)
                    return;
                if (value)
                {
                    ParentControl.Controls.Remove(EditControl);
                    HostForm.Controls.Add(EditControl);
                    HostForm.Show(SceneForm);
                }
                else
                {
                    HostForm.Controls.Remove(EditControl);
                    ParentControl.Controls.Add(EditControl);
                    EditControl.BringToFront();
                    HostForm.Hide();
                }
            }
        }

        #endregion

        #region Internal Events

        internal event EventHandler<FormClosingEventArgs> HostFormClosing;

        #endregion

        #region Protected Fields

        protected bool
            _EditControlDocked = true,
            _EditControlVisible = true;

        protected readonly SceneController SceneController;

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
                FormVisible = !value && _EditControlVisible;
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

        protected abstract Control ParentControl { get; }

        protected Scene Scene => SceneController.Scene;

        protected SceneForm SceneForm => SceneController.SceneForm;

        #endregion

        #region Protected Event Handlers

        protected void PopupEditControlFloat_Click(object sender, EventArgs e) =>
            EditControlDocked = !EditControlDocked;

        protected void PopupEditControlHide_Click(object sender, EventArgs e) =>
            EditControlVisible = false;

        protected void ToggleEditControl(object sender, EventArgs e) =>
            EditControlVisible = !EditControlVisible;

        #endregion

        #region Protected Methods

        protected internal abstract void Refresh();

        protected virtual void UpdateConfiguration()
        {
            FormVisible = !_EditControlDocked && _EditControlVisible;
        }

        #endregion

        #region Private Fields

        private readonly string Caption;
        private HostForm _HostForm;

        #endregion

        #region Private Properties

        private HostForm HostForm => _HostForm ?? (_HostForm = CreateHostForm());

        #endregion

        #region Private Event Handlers

        private void HostController_HostFormClosing(object sender, FormClosingEventArgs e) =>
            EditControlVisible = false;

        private void HostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HostFormClosing?.Invoke(sender, e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HostForm.Hide();
                return;
            }
            HostForm.FormClosing -= HostForm_FormClosing;
        }

        #endregion

        #region Private Methods

        private HostForm CreateHostForm()
        {
            var hostForm = new HostForm
            {
                ClientSize = EditControl.Size,
                Location = EditControl.PointToScreen(new Point()),
                Text = Caption
            };
            hostForm.FormClosing += HostController_HostFormClosing;
            return hostForm;
        }

        #endregion
    }
}
