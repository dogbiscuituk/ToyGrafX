namespace ToyGraf.Commands
{
    using ToyGraf.Models;

    public class TraceXmaxCommand : TracePropertyCommand<double>
    {
        public TraceXmaxCommand(Trace trace, double value) : base(trace, "Xmax",
            value, t => t.Xmax, (t, v) => t.Xmax = v)
        { }
    }
}
