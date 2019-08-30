// <copyright file="TgStatusStrip.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controls
{
    using System.Windows.Forms;

    public class TgStatusStrip : StatusStrip
    {
        protected override void WndProc(ref Message m)
        {
            this.FirstFocus(ref m);
            base.WndProc(ref m);
        }
    }
}
