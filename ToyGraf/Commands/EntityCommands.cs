namespace ToyGraf.Commands
{
    using OpenTK;
    using ToyGraf.Engine.Types;

    internal class EntityLocationCommand : TracePropertyCommand<Point3F>
    {
        internal EntityLocationCommand(int index, Point3F value) : base(index, "Location",
            value, e => e._Location, (e, v) => e._Location = v)
        { }
    }

    internal class EntityOrientationCommand : TracePropertyCommand<Euler3F>
    {
        internal EntityOrientationCommand(int index, Euler3F value) : base(index, "Orientation",
            value, e => e._Orientation, (e, v) => e._Orientation = v)
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
