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
        internal EntityLocationXCommand(int index, float value) : base(index, "X",
            value, e => e._LocationX, (e, v) => e._LocationX = v)
        { }
    }

    internal class EntityLocationYCommand : TracePropertyCommand<float>
    {
        internal EntityLocationYCommand(int index, float value) : base(index, "Y",
            value, e => e._LocationY, (e, v) => e._LocationY = v)
        { }
    }

    internal class EntityLocationZCommand : TracePropertyCommand<float>
    {
        internal EntityLocationZCommand(int index, float value) : base(index, "Z",
            value, e => e._LocationZ, (e, v) => e._LocationZ = v)
        { }
    }

    internal class EntityOrientationCommand : TracePropertyCommand<Vector3>
    {
        internal EntityOrientationCommand(int index, Vector3 value) : base(index, "Orientation",
            value, e => e.GetOrientation(), (e, v) => e.SetOrientation(v))
        { }
    }

    internal class EntityOrientationXCommand : TracePropertyCommand<float>
    {
        internal EntityOrientationXCommand(int index, float value) : base(index, "Orientation X",
            value, e => e._OrientationX, (e, v) => e._OrientationX = v)
        { }
    }

    internal class EntityOrientationYCommand : TracePropertyCommand<float>
    {
        internal EntityOrientationYCommand(int index, float value) : base(index, "Orientation Y",
            value, e => e._OrientationY, (e, v) => e._OrientationY = v)
        { }
    }

    internal class EntityOrientationZCommand : TracePropertyCommand<float>
    {
        internal EntityOrientationZCommand(int index, float value) : base(index, "Orientation Z",
            value, e => e._OrientationZ, (e, v) => e._OrientationZ = v)
        { }
    }

    internal class EntityScaleCommand : TracePropertyCommand<float>
    {
        internal EntityScaleCommand(int index, float value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }

    internal class EntityTransformationCommand : TracePropertyCommand<Matrix4>
    {
        internal EntityTransformationCommand(int index, Matrix4 value) : base(index, "Transformation",
            value, e => e.GetTransformation(), (e, v) => e.SetTransformation(v))
        { }
    }
}
