// <copyright file="PropertyGridInitEventArgs.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controls.Events
{
    using System;
    using System.Windows.Forms;

    public class PropertyGridInitEventArgs : EventArgs
    {
        public PropertyGridInitEventArgs(PropertyGrid propertyGrid) : base()
            => PropertyGrid = propertyGrid;

        public PropertyGrid PropertyGrid { get; set; }
    }
}
