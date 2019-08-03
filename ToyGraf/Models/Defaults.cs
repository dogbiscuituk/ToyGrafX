namespace ToyGraf.Models
{
    internal class Defaults
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

        // Trace Domain & Range

        internal const double
            Xmin = -1,
            Xmax = +1,
            Ymin = -1,
            Ymax = +1,
            Zmin = -1,
            Zmax = +1;

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

        internal const string[]
            VertexShader = null,
            TessControlShader = null,
            TessEvaluationShader = null,
            GeometryShader = null,
            FragmentShader = null,
            ComputeShader = null,
            ShaderStatus = null;

        // Trace Terrain

        internal const int
            StripCountX = 0,
            StripCountY = 0,
            StripCountZ = 0;

        // Trace Miscellaneous

        internal const bool
            Visible = true;
    }
}
