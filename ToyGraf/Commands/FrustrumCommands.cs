namespace ToyGraf.Commands
{
    using ToyGraf.Models;

    internal class FarPlaneCommand : ScenePropertyCommand<float>
    {
        internal FarPlaneCommand(float value) : base(PropertyNames.FarPlane,
            value, s => s._FarPlane, (s, v) => s._FarPlane = v)
        { }
    }

    internal class FieldOfViewCommand : ScenePropertyCommand<float>
    {
        internal FieldOfViewCommand(float value) : base(PropertyNames.FieldOfView,
            value, s => s._FieldOfView, (s, v) => s._FieldOfView = v)
        { }
    }

    internal class NearPlaneCommand : ScenePropertyCommand<float>
    {
        internal NearPlaneCommand(float value) : base(PropertyNames.NearPlane,
            value, s => s._NearPlane, (s, v) => s._NearPlane = v)
        { }
    }
}
