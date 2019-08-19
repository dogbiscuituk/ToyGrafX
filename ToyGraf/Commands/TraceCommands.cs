namespace ToyGraf.Commands
{
    using OpenTK;
    using ToyGraf.Engine.Types;
    using ToyGraf.Models;

    internal class DescriptionCommand : TracePropertyCommand<string>
    {
        internal DescriptionCommand(int index, string value) : base(index, PropertyNames.Description,
            value, t => t._Description, (t, v) => t._Description = v)
        { }
    }

    internal class LocationCommand : TracePropertyCommand<Point3F>
    {
        internal LocationCommand(int index, Point3F value) : base(index, PropertyNames.Location,
            value, e => e._Location, (e, v) => e._Location = v)
        { }
    }

    internal class MaximumCommand : TracePropertyCommand<Point3F>
    {
        internal MaximumCommand(int index, Point3F value) : base(index, PropertyNames.Maximum,
            value, t => t._Maximum, (t, v) => t._Maximum = v)
        { }
    }

    internal class MinimumCommand : TracePropertyCommand<Point3F>
    {
        internal MinimumCommand(int index, Point3F value) : base(index, PropertyNames.Minimum,
            value, t => t._Minimum, (t, v) => t._Minimum = v)
        { }
    }

    internal class OrientationCommand : TracePropertyCommand<Euler3F>
    {
        internal OrientationCommand(int index, Euler3F value) : base(index, PropertyNames.Orientation,
            value, e => e._Orientation, (e, v) => e._Orientation = v)
        { }
    }

    internal class PatternCommand : TracePropertyCommand<Pattern>
    {
        internal PatternCommand(int index, Pattern value) : base(index, PropertyNames.Pattern,
            value, t => t._Pattern, (t, v) => t._Pattern = v)
        { }
    }

    internal class ScaleCommand : TracePropertyCommand<Point3F>
    {
        internal ScaleCommand(int index, Point3F value) : base(index, PropertyNames.Scale,
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }

    internal class StripCountCommand : TracePropertyCommand<Point3>
    {
        internal StripCountCommand(int index, Point3 value) : base(index, PropertyNames.StripCount,
            value, t => t._StripCount, (t, v) => t._StripCount = v)
        { }
    }

    internal class TransformCommand : TracePropertyCommand<Matrix4>
    {
        internal TransformCommand(int index, Matrix4 value) : base(index, PropertyNames.Transform,
            value, e => e.GetTransform(), (e, v) => e.SetTransform(v))
        { }
    }

    internal class VisibleCommand : TracePropertyCommand<bool>
    {
        internal VisibleCommand(int index, bool value) : base(index, PropertyNames.Visible,
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }
}
