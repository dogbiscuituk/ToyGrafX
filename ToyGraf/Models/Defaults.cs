using System.Collections.Generic;
using ToyGraf.Models.Enums;

namespace ToyGraf.Models
{
    internal static class Defaults
    {
        // Categories

        internal const string
            Camera = "Camera",
            DomainRange = "Domain / Range",
            Placement = "Placement",
            Projection = "Projection",
            Shaders = "Shaders",
            SystemRO = "Read Only / System",
            Terrain = "Terrain",
            Trace = "Trace";

        // Scene Camera & Perspective

        internal const float
            CameraX = 0,
            CameraY = 0,
            CameraZ = 0,
            CameraPitch = 0,
            CameraRoll = 0,
            CameraYaw = 0,
            FieldOfView = 75,
            NearPlane = 0.1f,
            FarPlane = 1000;

        // Scene FPS

        internal const double
            FPS = 60;

        // Scene Renderer

        internal const int
            _SampleCount = 0;

        // Scene Title

        internal const string
            SceneTitle = "";

        // Scene Traces

        internal static List<Trace> Traces =>
            new List<Trace>();

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
            OrientationX = 0,
            OrientationY = 0,
            OrientationZ = 0,
            Scale = 1;

        internal const YN
            Visible = YN.Yes;

        // Trace Shaders

        internal const string
            GPUStatus = "",
            Shader1Vertex = "",
            Shader2TessControl = "",
            Shader3TessEvaluation = "",
            Shader4Geometry = "",
            Shader5Fragment = "",
            Shader6Compute = "";

        // Trace Terrain

        internal const uint
            StripCountX = 0,
            StripCountY = 0,
            StripCountZ = 0;

        // Trace Title

        internal const string
            TraceTitle = "";
    }
}
