namespace ToyGraf.Commands
{
    internal class BppAlphaCommand : ScenePropertyCommand<int>
    {
        internal BppAlphaCommand(int value) : base("Alpha BPP",
            value, p => p._BppAlpha, (p, v) => p._BppAlpha = v)
        { }
    }

    internal class BppBlueCommand : ScenePropertyCommand<int>
    {
        internal BppBlueCommand(int value) : base("Blue BPP",
            value, p => p._BppBlue, (p, v) => p._BppBlue = v)
        { }
    }

    internal class BppGreenCommand : ScenePropertyCommand<int>
    {
        internal BppGreenCommand(int value) : base("Green BPP",
            value, p => p._BppGreen, (p, v) => p._BppGreen = v)
        { }
    }

    internal class BppRedCommand : ScenePropertyCommand<int>
    {
        internal BppRedCommand(int value) : base("Red BPP",
            value, p => p._BppRed, (p, v) => p._BppRed = v)
        { }
    }
}
