namespace ToyGraf.Commands
{
    public class TerrainStripCountXCommand : TracePropertyCommand<int>
    {
        public TerrainStripCountXCommand(int index, int value) : base(index, "Strip Count X",
            value, t => t._StripCountX, (t, v) => t._StripCountX = v)
        { }
    }

    public class TerrainStripCountYCommand : TracePropertyCommand<int>
    {
        public TerrainStripCountYCommand(int index, int value) : base(index, "Strip Count Y",
            value, t => t._StripCountY, (t, v) => t._StripCountY = v)
        { }
    }

    public class TerrainStripCountZCommand : TracePropertyCommand<int>
    {
        public TerrainStripCountZCommand(int index, int value) : base(index, "Strip Count Z",
            value, t => t._StripCountZ, (t, v) => t._StripCountZ = v)
        { }
    }
}
