namespace ToyGraf.Commands
{
    using OpenTK;

    public class EntityLocationCommand : TracePropertyCommand<Vector3>
    {
        public EntityLocationCommand(int index, Vector3 value) : base(index, "Location",
            value, e => e._Location, (e, v) => e._Location = v)
        { }
    }

    public class EntityLocationXCommand : TracePropertyCommand<float>
    {
        public EntityLocationXCommand(int index, float value) : base(index, "Location X",
            value, e => e._Location.X, (e, v) => e._Location = new Vector3(value, e._Location.Y, e._Location.Z))
        { }
    }

    public class EntityLocationYCommand : TracePropertyCommand<float>
    {
        public EntityLocationYCommand(int index, float value) : base(index, "Location Y",
            value, e => e._Location.Y, (e, v) => e._Location = new Vector3(e._Location.X, value, e._Location.Z))
        { }
    }

    public class EntityLocationZCommand : TracePropertyCommand<float>
    {
        public EntityLocationZCommand(int index, float value) : base(index, "Location Z",
            value, e => e._Location.Z, (e, v) => e._Location = new Vector3(e._Location.X, e._Location.Y, value))
        { }
    }

    public class EntityRotationCommand : TracePropertyCommand<Vector3>
    {
        public EntityRotationCommand(int index, Vector3 value) : base(index, "Rotation",
            value, e => e._Rotation, (e, v) => e._Rotation = v)
        { }
    }

    public class EntityRotationXCommand : TracePropertyCommand<float>
    {
        public EntityRotationXCommand(int index, float value) : base(index, "Rotation X",
            value, e => e._Rotation.X, (e, v) => e._Rotation = new Vector3(value, e._Rotation.Y, e._Rotation.Z))
        { }
    }

    public class EntityRotationYCommand : TracePropertyCommand<float>
    {
        public EntityRotationYCommand(int index, float value) : base(index, "Rotation Y",
            value, e => e._Rotation.Y, (e, v) => e._Rotation = new Vector3(e._Rotation.X, value, e._Rotation.Z))
        { }
    }

    public class EntityRotationZCommand : TracePropertyCommand<float>
    {
        public EntityRotationZCommand(int index, float value) : base(index, "Rotation Z",
            value, e => e._Rotation.Z, (e, v) => e._Rotation = new Vector3(e._Rotation.X, e._Rotation.Y, value))
        { }
    }

    public class EntityScaleCommand : TracePropertyCommand<float>
    {
        public EntityScaleCommand(int index, float value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }
}
