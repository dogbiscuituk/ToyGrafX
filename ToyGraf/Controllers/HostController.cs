namespace ToyGraf.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class HostController
    {
        #region Constructor

        internal HostController(string text, Control hostedControl)
        {
            HostedControl = hostedControl;
            ParentControl = hostedControl.Parent;
            HostForm = new HostForm
            {
                ClientSize = new Size(HostedControl.Width, HostedControl.Height),
                Location = hostedControl.PointToScreen(new Point()),
                Text = text
            };
            HostForm.FormClosing += HostForm_FormClosing;
        }

        #endregion

        #region Internal Events

        internal event EventHandler<FormClosingEventArgs> HostFormClosing;

        #endregion

        #region Internal Methods

        internal void Close()
        {
            HostForm.Controls.Remove(HostedControl);
            ParentControl.Controls.Add(HostedControl);
            HostedControl.BringToFront();
            HostForm.Hide();
        }

        internal void Show(IWin32Window owner)
        {
            ParentControl.Controls.Remove(HostedControl);
            HostForm.Controls.Add(HostedControl);
            HostForm.Show(owner);
        }

        #endregion

        #region Private Properties

        private readonly Control HostedControl, ParentControl;
        private readonly HostForm HostForm;

        #endregion

        #region Private Event Handlers

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
    }
}
