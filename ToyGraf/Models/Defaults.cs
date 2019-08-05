using System.Collections.Generic;
using ToyGraf.Models.Enums;

namespace ToyGraf.Models
{
    internal static class Defaults
    {
        // Scene Camera & Perspective

        internal const float
            CameraX = 0,
            CameraY = 0,
            CameraZ = 0,
            CameraPitch = 0,
            CameraRoll = 0,
            CameraYaw = 0,
            FrustrumFieldOfView = 75,
            FrustrumNearPlane = 0,
            FrustrumFarPlane = 1000;

        // Scene FPS

        internal const double
            FPS = 60;

        // Scene Title

        internal const string
            SceneTitle = "";

        // Scene Traces

        internal static List<Trace> Traces => new List<Trace>();

        // Trace Domain & Range

        internal const double
            Xmin = -11,
            Xmax = +11,
            Ymin = -11,
            Ymax = +11,
            Zmin = -11,
            Zmax = +11;

        // Trace Placement

        internal const float
            LocationX = 0,
            LocationY = 0,
            LocationZ = 0,
            RotationX = 0,
            RotationY = 0,
            RotationZ = 0,
            Scale = 1;

        // Trace Shaders

        internal const string
            VertexShader = "",
            TessControlShader = "",
            TessEvaluationShader = "",
            GeometryShader = "",
            FragmentShader = "",
            ComputeShader = "",
            ShaderStatus = "";

        // Trace Terrain

        internal const uint
            StripCountX = 0,
            StripCountY = 0,
            StripCountZ = 0;

        // Trace Miscellaneous

        internal const YN
            Visible = YN.Yes;
    }
}
