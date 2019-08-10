namespace ToyGraf.Commands
{
    internal class TerrainStripCountXCommand : TracePropertyCommand<uint>
    {
        internal TerrainStripCountXCommand(int index, uint value) : base(index, "X Strips",
            value, t => t._StripCountX, (t, v) => t._StripCountX = v)
        { }
    }

    internal class TerrainStripCountYCommand : TracePropertyCommand<uint>
    {
        internal TerrainStripCountYCommand(int index, uint value) : base(index, "Y Strips",
            value, t => t._StripCountY, (t, v) => t._StripCountY = v)
        { }
    }

    internal class TerrainStripCountZCommand : TracePropertyCommand<uint>
    {
        internal TerrainStripCountZCommand(int index, uint value) : base(index, "Z Strips",
            value, t => t._StripCountZ, (t, v) => t._StripCountZ = v)
        { }
    }
}
