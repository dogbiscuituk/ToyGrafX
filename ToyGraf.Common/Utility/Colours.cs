﻿namespace ToyGraf.Common.Utility
{
    using System.Drawing;
    using System.Reflection;

    public static class Colours
    {
        public static Brush ToBrush(this Color colour)
        {
            var flags = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static;
            var prop = typeof(Brushes).GetProperty(colour.Name, flags);
            return prop != null ? (Brush)prop.GetValue(null) : new SolidBrush(colour);
        }
    }
}
