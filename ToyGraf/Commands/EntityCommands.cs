namespace ToyGraf.Commands
{
    using OpenTK;

    internal class EntityLocationCommand : TracePropertyCommand<Vector3>
    {
        internal EntityLocationCommand(int index, Vector3 value) : base(index, "Location",
            value, e => e.GetLocation(), (e, v) => e.SetLocation(v))
        { }
    }

    internal class EntityLocationXCommand : TracePropertyCommand<float>
    {
        internal EntityLocationXCommand(int index, float value) : base(index, "Location X",
            value, e => e._LocationX, (e, v) => e._LocationX = value)
        { }
    }

    internal class EntityLocationYCommand : TracePropertyCommand<float>
    {
        internal EntityLocationYCommand(int index, float value) : base(index, "Location Y",
            value, e => e._LocationY, (e, v) => e._LocationY = value)
        { }
    }

    internal class EntityLocationZCommand : TracePropertyCommand<float>
    {
        internal EntityLocationZCommand(int index, float value) : base(index, "Location Z",
            value, e => e._LocationZ, (e, v) => e._LocationZ = value)
        { }
    }

    internal class EntityRotationCommand : TracePropertyCommand<Vector3>
    {
        internal EntityRotationCommand(int index, Vector3 value) : base(index, "Rotation",
            value, e => e.GetRotation(), (e, v) => e.SetRotation(v))
        { }
    }

    internal class EntityRotationXCommand : TracePropertyCommand<float>
    {
        internal EntityRotationXCommand(int index, float value) : base(index, "Rotation X",
            value, e => e._RotationX, (e, v) => e._RotationX = value)
        { }
    }

    internal class EntityRotationYCommand : TracePropertyCommand<float>
    {
        internal EntityRotationYCommand(int index, float value) : base(index, "Rotation Y",
            value, e => e._RotationY, (e, v) => e._RotationY = value)
        { }
    }

    internal class EntityRotationZCommand : TracePropertyCommand<float>
    {
        internal EntityRotationZCommand(int index, float value) : base(index, "Rotation Z",
            value, e => e._RotationZ, (e, v) => e._RotationZ = value)
        { }
    }

    internal class EntityScaleCommand : TracePropertyCommand<float>
    {
        internal EntityScaleCommand(int index, float value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }
}
