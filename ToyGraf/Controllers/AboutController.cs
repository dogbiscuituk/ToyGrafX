﻿namespace ToyGraf.Controllers
{
    using System.Reflection;
    using System.Windows.Forms;
    using ToyGraf.Common.Utility;
    using ToyGraf.Views;

    internal class AboutController
    {
        #region Internal Interface

        internal AboutController()
        {
            View = new AboutDialog();
            var asm = Assembly.GetExecutingAssembly();
            View.Text = $"About {Application.ProductName}";
            View.lblProductName.Text = Application.ProductName;
            View.lblDescription.Text = asm.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            View.lblVersion.Text = Application.ProductVersion;
            View.lblAuthor.Text = Application.CompanyName;
            View.lblCopyright.Text = asm.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
        }

        internal void Show(IWin32Window owner)
        {
            View.btnOK.Visible = false;
            View.Show(owner);
        }

        internal void ShowDialog(IWin32Window owner)
        {
            View.btnOK.Visible = true;
            View.ShowDialog(owner);
        }

        internal AboutDialog View
        {
            get => _View;
            set
            {
                _View = value;
                View.NewtonsoftLinkLabel.LinkClicked += NewtonsoftLinkClick;
                View.GplLinkLabel.LinkClicked += GplLinkClick;
            }
        }

        #endregion

        #region Private Properties

        private AboutDialog _View;

        #endregion

        #region Private Event Handlers

        private void GplLinkClick(object sender, LinkLabelLinkClickedEventArgs e) =>
            Launch(View.GplLinkLabel);

        private void NewtonsoftLinkClick(object sender, LinkLabelLinkClickedEventArgs e) =>
            Launch(View.NewtonsoftLinkLabel);

        #endregion

        #region Private Methods

        private void Launch(LinkLabel linkLabel)
        {
            linkLabel.Text.Launch();
            linkLabel.LinkVisited = true;
        }

        #endregion
    }
}
