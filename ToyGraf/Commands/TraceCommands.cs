namespace ToyGraf.Commands
{
    using ToyGraf.Models.Enums;

    internal class TraceVisibleCommand : TracePropertyCommand<YN>
    {
        internal TraceVisibleCommand(int index, YN value) : base(index, "Visible",
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }

    internal class TraceXmaxCommand : TracePropertyCommand<double>
    {
        internal TraceXmaxCommand(int index, double value) : base(index, "Xmax",
            value, t => t._Xmax, (t, v) => t._Xmax = v)
        { }
    }

    internal class TraceXminCommand : TracePropertyCommand<double>
    {
        internal TraceXminCommand(int index, double value) : base(index, "Xmin",
            value, t => t._Xmin, (t, v) => t._Xmin = v)
        { }
    }

    internal class TraceYmaxCommand : TracePropertyCommand<double>
    {
        internal TraceYmaxCommand(int index, double value) : base(index, "Ymax",
            value, t => t._Ymax, (t, v) => t._Ymax = v)
        { }
    }

    internal class TraceYminCommand : TracePropertyCommand<double>
    {
        internal TraceYminCommand(int index, double value) : base(index, "Ymin",
            value, t => t._Ymin, (t, v) => t._Ymin = v)
        { }
    }

    internal class TraceZmaxCommand : TracePropertyCommand<double>
    {
        internal TraceZmaxCommand(int index, double value) : base(index, "Zmax",
            value, t => t._Zmax, (t, v) => t._Zmax = v)
        { }
    }

    internal class TraceZminCommand : TracePropertyCommand<double>
    {
        internal TraceZminCommand(int index, double value) : base(index, "Zmin",
            value, t => t._Zmin, (t, v) => t._Zmin = v)
        { }
    }
}
