namespace ToyGraf.Commands
{
    using ToyGraf.Models;

    public class TraceScriptCommand : TracePropertyCommand<string[]>
    {
        public TraceScriptCommand(Trace trace, string[] value) : base(trace, "Script",
            value, t => t._Script, (t, v) => t._Script = v)
        { }
    }

    public class TraceVisibleCommand : TracePropertyCommand<bool>
    {
        public TraceVisibleCommand(Trace trace, bool value) : base(trace, "Visible",
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }

    public class TraceXmaxCommand : TracePropertyCommand<double>
    {
        public TraceXmaxCommand(Trace trace, double value) : base(trace, "Xmax",
            value, t => t._Xmax, (t, v) => t._Xmax = v)
        { }
    }

    public class TraceXminCommand : TracePropertyCommand<double>
    {
        public TraceXminCommand(Trace trace, double value) : base(trace, "Xmin",
            value, t => t._Xmin, (t, v) => t._Xmin = v)
        { }
    }

    public class TraceYmaxCommand : TracePropertyCommand<double>
    {
        public TraceYmaxCommand(Trace trace, double value) : base(trace, "Ymax",
            value, t => t._Ymax, (t, v) => t._Ymax = v)
        { }
    }

    public class TraceYminCommand : TracePropertyCommand<double>
    {
        public TraceYminCommand(Trace trace, double value) : base(trace, "Ymin",
            value, t => t._Ymin, (t, v) => t._Ymin = v)
        { }
    }

    public class TraceZmaxCommand : TracePropertyCommand<double>
    {
        public TraceZmaxCommand(Trace trace, double value) : base(trace, "Zmax",
            value, t => t._Zmax, (t, v) => t._Zmax = v)
        { }
    }

    public class TraceZminCommand : TracePropertyCommand<double>
    {
        public TraceZminCommand(Trace trace, double value) : base(trace, "Zmin",
            value, t => t._Zmin, (t, v) => t._Zmin = v)
        { }
    }
}
