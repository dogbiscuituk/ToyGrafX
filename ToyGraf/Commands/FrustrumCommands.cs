namespace ToyGraf.Commands
{
    internal class FrustrumFarPlaneCommand : ScenePropertyCommand<float>
    {
        internal FrustrumFarPlaneCommand(float value) : base("Far Plane",
            value, s => s._FrustrumFarPlane, (s, v) => s._FrustrumFarPlane = v)
        { }
    }

    internal class FrustrumFieldOfViewCommand : ScenePropertyCommand<float>
    {
        internal FrustrumFieldOfViewCommand(float value) : base("Field of View Y°",
            value, s => s._FrustrumFieldOfView, (s, v) => s._FrustrumFieldOfView = v)
        { }
    }

    internal class FrustrumNearPlaneCommand : ScenePropertyCommand<float>
    {
        internal FrustrumNearPlaneCommand(float value) : base("Near Plane",
            value, s => s._FrustrumNearPlane, (s, v) => s._FrustrumNearPlane = v)
        { }
    }
}
