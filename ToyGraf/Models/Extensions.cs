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
            target.Xmax = source.Xmax;
            target.Xmin = source.Xmin;
            target.Ymax = source.Ymax;
            target.Ymin = source.Ymin;
            target.Zmax = source.Zmax;
            target.Zmin = source.Zmin;
            // Placement
            target.LocationX = source.LocationX;
            target.LocationY = source.LocationY;
            target.LocationZ = source.LocationZ;
            target.OrientationX = source.OrientationX;
            target.OrientationY = source.OrientationY;
            target.OrientationZ = source.OrientationZ;
            target.Scale = source.Scale;
            // Shaders
            target.Shader1Vertex = source.Shader1Vertex;
            target.Shader2TessControl = source.Shader2TessControl;
            target.Shader3TessEvaluation = source.Shader3TessEvaluation;
            target.Shader4Geometry = source.Shader4Geometry;
            target.Shader5Fragment = source.Shader5Fragment;
            target.Shader6Compute = source.Shader6Compute;
            target._GPUStatus = source.GPUStatus;
            // Terrain
            target.StripCountX = source.StripCountX;
            target.StripCountY = source.StripCountY;
            target.StripCountZ = source.StripCountZ;
            // Trace
            target.Title = source.Title;
            target.Visible = source.Visible;
        }
    }
}
