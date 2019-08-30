// <copyright file="HostController.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class HostController
    {
        internal HostController(string text, Control hostedControl)
        {
            HostedControl = hostedControl;
            ParentControl = hostedControl.Parent;
            HostForm = new HostForm { Text = text };
            HostForm.FormClosing += HostForm_FormClosing;
        }

        internal void AdjustFormSize()
        {
            HostForm.ClientSize = new Size(
                HostedControl.Width,
                HostedControl.Height);
        }

        internal void Close()
        {
            HostForm.Controls.Remove(HostedControl);
            ParentControl.Controls.Add(HostedControl);
            HostedControl.BringToFront();
            HostForm.Hide();
        }

        internal void Show(IWin32Window owner)
        {
            AdjustFormSize();
            ParentControl.Controls.Remove(HostedControl);
            HostForm.Controls.Add(HostedControl);
            HostForm.Show(owner);
        }

        internal event EventHandler<FormClosingEventArgs> HostFormClosing;

        private readonly Control HostedControl, ParentControl;
        private readonly HostForm HostForm;

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
    }
}
