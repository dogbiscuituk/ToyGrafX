namespace ToyGraf.Commands
{
    internal class TerrainStripCountXCommand : TracePropertyCommand<int>
    {
        internal TerrainStripCountXCommand(int index, int value) : base(index, "Strip Count X",
            value, t => t._StripCountX, (t, v) => t._StripCountX = v)
        { }
    }

    internal class TerrainStripCountYCommand : TracePropertyCommand<int>
    {
        internal TerrainStripCountYCommand(int index, int value) : base(index, "Strip Count Y",
            value, t => t._StripCountY, (t, v) => t._StripCountY = v)
        { }
    }

    internal class TerrainStripCountZCommand : TracePropertyCommand<int>
    {
        internal TerrainStripCountZCommand(int index, int value) : base(index, "Strip Count Z",
            value, t => t._StripCountZ, (t, v) => t._StripCountZ = v)
        { }
    }
}
