namespace ToyGraf.Commands
{
    using OpenTK;
    using System.Drawing;
    using ToyGraf.Engine;
    using ToyGraf.Engine.Types;
    using ToyGraf.Models;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base(DisplayNames.BackgroundColour,
            value, r => r._BackgroundColour, (r, v) => r._BackgroundColour = v)
        { }
    }

    internal class CameraCommand : ScenePropertyCommand<Camera>
    {
        internal CameraCommand(Camera value) : base(DisplayNames.Camera,
            value, s => s._Camera, (s, v) => s._Camera = v)
        { }
    }

    internal class CameraViewCommand : ScenePropertyCommand<Matrix4>
    {
        internal CameraViewCommand(Matrix4 value) : base(DisplayNames.CameraView,
            value, s => s.GetCameraView(), (s, v) => s.SetCameraView(v))
        { }
    }

    internal class FpsCommand : ScenePropertyCommand<double>
    {
        internal FpsCommand(double value) : base(DisplayNames.FPS,
            value, s => s._FPS, (s, v) => s._FPS = v)
        { }
    }

    internal class ProjectionCommand : ScenePropertyCommand<Projection>
    {
        internal ProjectionCommand(Projection value) : base(DisplayNames.Projection,
            value, s => s._Projection, (s, v) => s._Projection = v)
        { }
    }

    internal class ProjectionMatrixCommand : ScenePropertyCommand<Matrix4>
    {
        internal ProjectionMatrixCommand(Matrix4 value) : base(DisplayNames.ProjectionMatrix,
            value, s => s.GetProjection(), (s, v) => s.SetProjection(v))
        { }
    }

    internal class TitleCommand : ScenePropertyCommand<string>
    {
        internal TitleCommand(string value) : base(DisplayNames.Title,
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
