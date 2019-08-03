using ToyGraf.Models.Enums;

namespace ToyGraf.Models
{
    public static class Extensions
    {
        public static void CopyTo(this Trace source, Trace target) => target.CopyFrom(source);

        public static void CopyFrom(this Trace target, Trace source)
        {
            // Domain & Range
            target._Xmax = source._Xmax;
            target._Xmin = source._Xmin;
            target._Ymax = source._Ymax;
            target._Ymin = source._Ymin;
            target._Zmax = source._Zmax;
            target._Zmin = source._Zmin;
            // Placement
            target._LocationX = source._LocationX;
            target._LocationY = source._LocationY;
            target._LocationZ = source._LocationZ;
            target._RotationX = source._RotationX;
            target._RotationY = source._RotationY;
            target._RotationZ = source._RotationZ;
            target._Scale = source._Scale;
            // Shaders
            target._VertexShader = source._VertexShader;
            target._TessControlShader = source._TessControlShader;
            target._TessEvaluationShader = source._TessEvaluationShader;
            target._GeometryShader = source._GeometryShader;
            target._FragmentShader = source._FragmentShader;
            target._ComputeShader = source._ComputeShader;
            target._ShaderStatus = source._ShaderStatus;
            // Terrain
            target._StripCountX = source._StripCountX;
            target._StripCountY = source._StripCountY;
            target._StripCountZ = source._StripCountZ;
            // Trace
            target._Visible = source._Visible;
        }

        public static YN BoolToYN(this bool value) => value ? YN.Yes : YN.No;
        public static bool BoolFromYN(this YN yn) => yn == YN.Yes;
    }
}
