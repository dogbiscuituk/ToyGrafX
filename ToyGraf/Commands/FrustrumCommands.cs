namespace ToyGraf.Commands
{
    internal class FarPlaneCommand : ScenePropertyCommand<float>
    {
        internal FarPlaneCommand(float value) : base("Far Plane",
            value, s => s._FarPlane, (s, v) => s._FarPlane = v)
        { }
    }

    internal class FieldOfViewCommand : ScenePropertyCommand<float>
    {
        internal FieldOfViewCommand(float value) : base("Field of View Y°",
            value, s => s._FieldOfView, (s, v) => s._FieldOfView = v)
        { }
    }

    internal class NearPlaneCommand : ScenePropertyCommand<float>
    {
        internal NearPlaneCommand(float value) : base("Near Plane",
            value, s => s._NearPlane, (s, v) => s._NearPlane = v)
        { }
    }
}
