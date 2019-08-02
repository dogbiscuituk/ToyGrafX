namespace ToyGraf.Commands
{
    using OpenTK;

    public class EntityLocationCommand : TracePropertyCommand<Vector3>
    {
        public EntityLocationCommand(int index, Vector3 value) : base(index, "Location",
            value, e => e.GetLocation(), (e, v) => e.SetLocation(v))
        { }
    }

    public class EntityLocationXCommand : TracePropertyCommand<float>
    {
        public EntityLocationXCommand(int index, float value) : base(index, "Location X",
            value, e => e._LocationX, (e, v) => e._LocationX = value)
        { }
    }

    public class EntityLocationYCommand : TracePropertyCommand<float>
    {
        public EntityLocationYCommand(int index, float value) : base(index, "Location Y",
            value, e => e._LocationY, (e, v) => e._LocationY = value)
        { }
    }

    public class EntityLocationZCommand : TracePropertyCommand<float>
    {
        public EntityLocationZCommand(int index, float value) : base(index, "Location Z",
            value, e => e._LocationZ, (e, v) => e._LocationZ = value)
        { }
    }

    public class EntityRotationCommand : TracePropertyCommand<Vector3>
    {
        public EntityRotationCommand(int index, Vector3 value) : base(index, "Rotation",
            value, e => e.GetRotation(), (e, v) => e.SetRotation(v))
        { }
    }

    public class EntityRotationXCommand : TracePropertyCommand<float>
    {
        public EntityRotationXCommand(int index, float value) : base(index, "Rotation X",
            value, e => e._RotationX, (e, v) => e._RotationX = value)
        { }
    }

    public class EntityRotationYCommand : TracePropertyCommand<float>
    {
        public EntityRotationYCommand(int index, float value) : base(index, "Rotation Y",
            value, e => e._RotationY, (e, v) => e._RotationY = value)
        { }
    }

    public class EntityRotationZCommand : TracePropertyCommand<float>
    {
        public EntityRotationZCommand(int index, float value) : base(index, "Rotation Z",
            value, e => e._RotationZ, (e, v) => e._RotationZ = value)
        { }
    }

    public class EntityScaleCommand : TracePropertyCommand<float>
    {
        public EntityScaleCommand(int index, float value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }
}
