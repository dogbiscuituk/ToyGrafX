namespace ToyGraf.Commands
{
    using ToyGraf.Engine.Types;

    internal class StripCountCommand : TracePropertyCommand<Point3>
    {
        internal StripCountCommand(int index, Point3 value) : base(index, "Strip Count",
            value, t => t._StripCount, (t, v) => t._StripCount = v)
        { }
    }
}
