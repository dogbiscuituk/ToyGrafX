namespace ToyGraf.Commands
{
    using OpenTK;
    using ToyGraf.Engine.Types;
    using ToyGraf.Models.Enums;

    internal class LocationCommand : TracePropertyCommand<Point3F>
    {
        internal LocationCommand(int index, Point3F value) : base(index, "Location",
            value, e => e._Location, (e, v) => e._Location = v)
        { }
    }

    internal class MaximumCommand : TracePropertyCommand<Point3F>
    {
        internal MaximumCommand(int index, Point3F value) : base(index, "Domain/Range Maximum",
            value, t => t._Maximum, (t, v) => t._Maximum = v)
        { }
    }

    internal class MinimumCommand : TracePropertyCommand<Point3F>
    {
        internal MinimumCommand(int index, Point3F value) : base(index, "Domain/Range Minimum",
            value, t => t._Minimum, (t, v) => t._Minimum = v)
        { }
    }

    internal class OrientationCommand : TracePropertyCommand<Euler3F>
    {
        internal OrientationCommand(int index, Euler3F value) : base(index, "Orientation",
            value, e => e._Orientation, (e, v) => e._Orientation = v)
        { }
    }

    internal class ScaleCommand : TracePropertyCommand<Point3F>
    {
        internal ScaleCommand(int index, Point3F value) : base(index, "Scale",
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }

    internal class StripCountCommand : TracePropertyCommand<Point3>
    {
        internal StripCountCommand(int index, Point3 value) : base(index, "Strip Count",
            value, t => t._StripCount, (t, v) => t._StripCount = v)
        { }
    }

    internal class TraceTitleCommand : TracePropertyCommand<string>
    {
        internal TraceTitleCommand(int index, string value) : base(index, "Title",
            value, t => t._Title, (t, v) => t._Title = v)
        { }
    }

    internal class TraceVisibleCommand : TracePropertyCommand<YN>
    {
        internal TraceVisibleCommand(int index, YN value) : base(index, "Visible",
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }

    internal class TransformationCommand : TracePropertyCommand<Matrix4>
    {
        internal TransformationCommand(int index, Matrix4 value) : base(index, "Transformation",
            value, e => e.GetTransformation(), (e, v) => e.SetTransformation(v))
        { }
    }
}
