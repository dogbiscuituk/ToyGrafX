﻿namespace ToyGraf.Common.Types
{
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;
    using ToyGraf.Common.TypeConverters;

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Pattern
    {
        [Description("Fill")]
        Fill = FillType.Fill | PrimitiveType.TriangleStrip,

        [Description("Points")]
        Points = FillType.Points | PrimitiveType.Points,

        [Description("Rectangles")]
        Rectangles = FillType.Rectangles | PrimitiveType.Lines,

        [Description("Saltires")]
        Saltires = FillType.Saltires | PrimitiveType.Lines,

        [Description("Triangles")]
        Triangles = FillType.Triangles | PrimitiveType.Lines
    }
}
