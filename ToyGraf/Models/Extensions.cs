using ToyGraf.Models.Enums;

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
            target.RotationX = source.RotationX;
            target.RotationY = source.RotationY;
            target.RotationZ = source.RotationZ;
            target.Scale = source.Scale;
            // Shaders
            target.Shader1_Vertex = source.Shader1_Vertex;
            target.Shader2_TessControl = source.Shader2_TessControl;
            target.Shader3_TessEvaluation = source.Shader3_TessEvaluation;
            target.Shader4_Geometry = source.Shader4_Geometry;
            target.Shader5_Fragment = source.Shader5_Fragment;
            target.Shader6_Compute = source.Shader6_Compute;
            target._ShaderStatus = source.ShaderStatus;
            // Terrain
            target.StripCountX = source.StripCountX;
            target.StripCountY = source.StripCountY;
            target.StripCountZ = source.StripCountZ;
            // Trace
            target.Visible = source.Visible;
        }
    }
}
