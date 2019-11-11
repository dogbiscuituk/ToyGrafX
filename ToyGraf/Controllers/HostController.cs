namespace ToyGraf.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class HostController
    {
        #region Constructor

        internal HostController(IWin32Window owner, string text, Control hostedControl)
        {
            Owner = owner;
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
                    ParentControl.Controls.Remove(HostedControl);
                    HostForm.Controls.Add(HostedControl);
                    HostForm.Show(Owner);
                }
                else
                {
                    HostForm.Controls.Remove(HostedControl);
                    ParentControl.Controls.Add(HostedControl);
                    HostedControl.BringToFront();
                    HostForm.Hide();
                }
            }
        }

        #endregion

        #region Internal Events

        internal event EventHandler<FormClosingEventArgs> HostFormClosing;

        #endregion

        #region Private Properties

        private readonly Control HostedControl, ParentControl;
        private readonly HostForm HostForm;
        private readonly IWin32Window Owner;

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
