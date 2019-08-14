namespace ToyGraf.Commands
{
    using OpenTK;
    using ToyGraf.Engine.Types;

    internal class CameraPositionCommand : ScenePropertyCommand<Point3F>
    {
        internal CameraPositionCommand(Point3F value) : base("Camera Position",
            value, s => s._CameraPosition, (s, v) => s._CameraPosition = v)
        { }
    }

    internal class CameraRotationCommand : ScenePropertyCommand<Euler3F>
    {
        internal CameraRotationCommand(Euler3F value) : base("Camera Rotation",
            value, s => s._CameraRotation, (s, v) => s._CameraRotation = v)
        { }
    }

    internal class CameraViewCommand : ScenePropertyCommand<Matrix4>
    {
        internal CameraViewCommand(Matrix4 value) : base("Camera View",
            value, s => s.GetCameraView(), (s, v) => s.SetCameraView(v))
        { }
    }
}
