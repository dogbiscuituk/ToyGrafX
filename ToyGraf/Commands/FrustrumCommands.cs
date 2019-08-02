﻿namespace ToyGraf.Commands
{
    public class FrustrumFarPlaneCommand : ScenePropertyCommand<float>
    {
        public FrustrumFarPlaneCommand(float value) : base("Far Plane",
            value, s => s._FrustrumFarPlane, (s, v) => s._FrustrumFarPlane = v)
        { }
    }

    public class FrustrumFieldOfViewCommand : ScenePropertyCommand<float>
    {
        public FrustrumFieldOfViewCommand(float value) : base("Field of View Y°",
            value, s => s._FrustrumFieldOfView, (s, v) => s._FrustrumFieldOfView = v)
        { }
    }

    public class FrustrumNearPlaneCommand : ScenePropertyCommand<float>
    {
        public FrustrumNearPlaneCommand(float value) : base("Near Plane",
            value, s => s._FrustrumNearPlane, (s, v) => s._FrustrumNearPlane = v)
        { }
    }
}
