namespace ToyGraf.Commands
{
    using OpenTK;
    using System.Drawing;
    using ToyGraf.Engine.Types;
    using ToyGraf.Models;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base(PropertyNames.BackgroundColour,
            value, r => r._BackgroundColour, (r, v) => r._BackgroundColour = v)
        { }
    }

    internal class CameraPositionCommand : ScenePropertyCommand<Point3F>
    {
        internal CameraPositionCommand(Point3F value) : base(PropertyNames.CameraPosition,
            value, s => s._CameraPosition, (s, v) => s._CameraPosition = v)
        { }
    }

    internal class CameraRotationCommand : ScenePropertyCommand<Euler3F>
    {
        internal CameraRotationCommand(Euler3F value) : base(PropertyNames.CameraRotation,
            value, s => s._CameraRotation, (s, v) => s._CameraRotation = v)
        { }
    }

    internal class CameraViewCommand : ScenePropertyCommand<Matrix4>
    {
        internal CameraViewCommand(Matrix4 value) : base(PropertyNames.CameraView,
            value, s => s.GetCameraView(), (s, v) => s.SetCameraView(v))
        { }
    }

    internal class FpsCommand : ScenePropertyCommand<double>
    {
        internal FpsCommand(double value) : base(PropertyNames.FPS,
            value, s => s._FPS, (s, v) => s._FPS = v)
        { }
    }

    internal class ProjectionCommand : ScenePropertyCommand<Matrix4>
    {
        internal ProjectionCommand(Matrix4 value) : base(PropertyNames.Projection,
            value, s => s.GetProjection(), (s, v) => s.SetProjection(v))
        { }
    }

    internal class TitleCommand : ScenePropertyCommand<string>
    {
        internal TitleCommand(string value) : base(PropertyNames.Title,
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
