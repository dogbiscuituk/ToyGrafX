namespace ToyGraf.Commands
{
    using System.Drawing;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base("Background Colour",
            value, r => r._BackgroundColour, (r, v) => r._BackgroundColour = v)
        { }
    }

    internal class SampleCountCommand : ScenePropertyCommand<int>
    {
        internal SampleCountCommand(int value) : base("Sample Count",
            value, r => r._SampleCount, (r, v) => r._SampleCount = v)
        { }
    }
}
