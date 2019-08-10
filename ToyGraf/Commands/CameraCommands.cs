namespace ToyGraf.Commands
{
    using OpenTK;

    internal class CameraOrientationCommand : ScenePropertyCommand<Vector3>
    {
        internal CameraOrientationCommand(Vector3 value) : base("Camera Orientation",
            value, s => s.GetCameraOrientation(), (s, v) => s.SetCameraOrientation(v))
        { }
    }

    internal class CameraPitchCommand : ScenePropertyCommand<float>
    {
        internal CameraPitchCommand(float value) : base("Camera Pitch",
            value, s => s._CameraPitch, (s, v) => s._CameraPitch = value)
        { }
    }

    internal class CameraPositionCommand : ScenePropertyCommand<Vector3>
    {
        internal CameraPositionCommand(Vector3 value) : base("Camera Position",
            value, s => s.GetCameraPosition(), (s, v) => s.SetCameraPosition(v))
        { }
    }

    internal class CameraRollCommand : ScenePropertyCommand<float>
    {
        internal CameraRollCommand(float value) : base("Camera Roll",
            value, s => s._CameraRoll, (s, v) => s._CameraRoll = value)
        { }
    }

    internal class CameraViewCommand : ScenePropertyCommand<Matrix4>
    {
        internal CameraViewCommand(Matrix4 value) : base("Camera View",
            value, s => s.GetCameraView(), (s, v) => s.SetCameraView(v))
        { }
    }

    internal class CameraXCommand : ScenePropertyCommand<float>
    {
        internal CameraXCommand(float value) : base("Camera X",
            value, s => s._CameraX, (s, v) => s._CameraX = value)
        { }
    }

    internal class CameraYawCommand : ScenePropertyCommand<float>
    {
        internal CameraYawCommand(float value) : base("Camera Yaw",
            value, s => s._CameraYaw, (s, v) => s._CameraYaw = value)
        { }
    }

    internal class CameraYCommand : ScenePropertyCommand<float>
    {
        internal CameraYCommand(float value) : base("Camera Y",
            value, s => s._CameraY, (s, v) => s._CameraY = value)
        { }
    }

    internal class CameraZCommand : ScenePropertyCommand<float>
    {
        internal CameraZCommand(float value) : base("Camera Z",
            value, s => s._CameraZ, (s, v) => s._CameraZ = value)
        { }
    }
}
