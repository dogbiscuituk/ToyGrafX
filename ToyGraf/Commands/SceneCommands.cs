namespace ToyGraf.Commands
{
    using OpenTK;
    using System.Drawing;
    using ToyGraf.Engine.Types;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base("Background Colour",
            value, r => r._BackgroundColour, (r, v) => r._BackgroundColour = v)
        { }
    }

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

    internal class SceneFpsCommand : ScenePropertyCommand<double>
    {
        internal SceneFpsCommand(double value) : base("FPS",
            value, s => s._FPS, (s, v) => s._FPS = v)
        { }
    }

    internal class SceneProjectionCommand : ScenePropertyCommand<Matrix4>
    {
        internal SceneProjectionCommand(Matrix4 value) : base("Projection",
            value, s => s.GetProjection(), (s, v) => s.SetProjection(v))
        { }
    }

    internal class SceneTitleCommand : ScenePropertyCommand<string>
    {
        internal SceneTitleCommand(string value) : base("Title",
            value, s => s._Title, (s, v) => s._Title = v)
        { }
    }

    internal class TraceInsertCommand : TracesCommand
    {
        internal TraceInsertCommand(int index) : base(index, true) { }
    }

    internal class TraceDeleteCommand : TracesCommand
    {
        internal TraceDeleteCommand(int index) : base(index, false) { }
    }

}
