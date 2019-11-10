namespace ToyGraf.Commands
{
    using OpenTK;
    using ToyGraf.Common.Types;
    using ToyGraf.Models;

    internal class DescriptionCommand : TracePropertyCommand<string>
    {
        internal DescriptionCommand(int index, string value) : base(index, DisplayNames.Description,
            value, t => t._Description, (t, v) => t._Description = v)
        { }
    }

    internal class LocationCommand : TracePropertyCommand<Vector3f>
    {
        internal LocationCommand(int index, Vector3f value) : base(index, DisplayNames.Location,
            value, e => e._Location, (e, v) => e._Location = v)
        { }
    }

    internal class MaximumCommand : TracePropertyCommand<Vector3f>
    {
        internal MaximumCommand(int index, Vector3f value) : base(index, DisplayNames.Maximum,
            value, t => t._Maximum, (t, v) => t._Maximum = v)
        { }
    }

    internal class MinimumCommand : TracePropertyCommand<Vector3f>
    {
        internal MinimumCommand(int index, Vector3f value) : base(index, DisplayNames.Minimum,
            value, t => t._Minimum, (t, v) => t._Minimum = v)
        { }
    }

    internal class OrientationCommand : TracePropertyCommand<Euler3f>
    {
        internal OrientationCommand(int index, Euler3f value) : base(index, DisplayNames.Orientation,
            value, e => e._Orientation, (e, v) => e._Orientation = v)
        { }
    }

    internal class PatternCommand : TracePropertyCommand<Pattern>
    {
        internal PatternCommand(int index, Pattern value) : base(index, DisplayNames.Pattern,
            value, t => t._Pattern, (t, v) => t._Pattern = v)
        { }
    }

    internal class ScaleCommand : TracePropertyCommand<Vector3f>
    {
        internal ScaleCommand(int index, Vector3f value) : base(index, DisplayNames.Scale,
            value, e => e._Scale, (e, v) => e._Scale = v)
        { }
    }

    internal class StripCountCommand : TracePropertyCommand<Vector3i>
    {
        internal StripCountCommand(int index, Vector3i value) : base(index, DisplayNames.StripCount,
            value, t => t._StripCount, (t, v) => t._StripCount = v)
        { }
    }

    internal class TransformCommand : TracePropertyCommand<Matrix4>
    {
        internal TransformCommand(int index, Matrix4 value) : base(index, DisplayNames.Transform,
            value, e => e.GetTransform(), (e, v) => e.SetTransform(v))
        { }
    }

    internal class VisibleCommand : TracePropertyCommand<bool>
    {
        internal VisibleCommand(int index, bool value) : base(index, DisplayNames.Visible,
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }
}
