// <copyright file="AboutController.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controllers
{
    using System.Reflection;
    using System.Windows.Forms;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Views;

    internal class AboutController
    {
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

        private AboutDialog _View;

        private void GplLinkClick(object sender, LinkLabelLinkClickedEventArgs e) =>
            Launch(View.GplLinkLabel);

        private void NewtonsoftLinkClick(object sender, LinkLabelLinkClickedEventArgs e) =>
            Launch(View.NewtonsoftLinkLabel);

        private void Launch(LinkLabel linkLabel)
        {
            linkLabel.Text.Launch();
            linkLabel.LinkVisited = true;
        }
    }
}
