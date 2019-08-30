// <copyright file="Extensions.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Models
{
    public static class Extensions
    {
        public static void CopyTo(this Trace source, Trace target) => target.CopyFrom(source);

        public static void CopyFrom(this Trace target, Trace source)
        {
            // System
            target.Index = source.Index;
            // Domain & Range
            target.Maximum = source.Maximum;
            target.Minimum = source.Minimum;
            // Placement
            target.Location = source.Location;
            target.Orientation = source.Orientation;
            target.Scale = source.Scale;
            // Shaders
            target.Shader1Vertex = source.Shader1Vertex;
            target.Shader2TessControl = source.Shader2TessControl;
            target.Shader3TessEvaluation = source.Shader3TessEvaluation;
            target.Shader4Geometry = source.Shader4Geometry;
            target.Shader5Fragment = source.Shader5Fragment;
            target.Shader6Compute = source.Shader6Compute;
            // Terrain
            target.StripCount = source.StripCount;
            // Trace
            target.Description = source.Description;
            target.Visible = source.Visible;
        }
    }
}
