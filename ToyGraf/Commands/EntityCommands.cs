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

    public class EntityRotationDegreesCommand : TracePropertyCommand<Vector3>
    {
        public EntityRotationDegreesCommand(int index, Vector3 value) : base(index, "Rotation",
            value, e => e.GetRotationDegrees(), (e, v) => e.SetRotationDegrees(v))
        { }
    }

    public class EntityRotationDegreesXCommand : TracePropertyCommand<float>
    {
        public EntityRotationDegreesXCommand(int index, float value) : base(index, "Rotation X",
            value, e => e._RotationDegreesX, (e, v) => e._RotationDegreesX = value)
        { }
    }

    public class EntityRotationDegreesYCommand : TracePropertyCommand<float>
    {
        public EntityRotationDegreesYCommand(int index, float value) : base(index, "Rotation Y",
            value, e => e._RotationDegreesY, (e, v) => e._RotationDegreesY = value)
        { }
    }

    public class EntityRotationDegreesZCommand : TracePropertyCommand<float>
    {
        public EntityRotationDegreesZCommand(int index, float value) : base(index, "Rotation Z",
            value, e => e._RotationDegreesZ, (e, v) => e._RotationDegreesZ = value)
        { }
    }

    public class EntityScaleCommand : TracePropertyCommand<float>
    {
        public EntityScaleCommand(int index, float value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }
}
