namespace ToyGraf.Commands
{
    public class FrustrumFarPlaneCommand : ScenePropertyCommand<float>
    {
        public FrustrumFarPlaneCommand(float value) : base("Far Plane",
            value, s => s._FrustrumFarPlane, (s, v) => s._FrustrumFarPlane = v)
        { }
    }

    public class FrustrumFieldOfViewDegreesYCommand : ScenePropertyCommand<float>
    {
        public FrustrumFieldOfViewDegreesYCommand(float value) : base("Field of View Y°",
            value, s => s._FrustrumFieldOfViewDegreesY, (s, v) => s._FrustrumFieldOfViewDegreesY = v)
        { }
    }

    public class FrustrumNearPlaneCommand : ScenePropertyCommand<float>
    {
        public FrustrumNearPlaneCommand(float value) : base("Near Plane",
            value, s => s._FrustrumNearPlane, (s, v) => s._FrustrumNearPlane = v)
        { }
    }
}
