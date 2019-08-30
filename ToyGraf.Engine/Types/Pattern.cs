// <copyright file="Pattern.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Pattern
    {
        [Description("No pattern")]
        None,
        [Description("Lines Strip")]
        LinesStrip,
        [Description("Triangles")]
        Triangles,
        [Description("Triangles Strip")]
        TriangleStrip
    }
}
