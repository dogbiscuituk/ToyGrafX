namespace ToyGraf.Commands
{
    using ToyGraf.Engine.Types;
    using ToyGraf.Models.Enums;

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
}
