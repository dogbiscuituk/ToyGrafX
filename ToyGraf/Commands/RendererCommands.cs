namespace ToyGraf.Commands
{
    using System.Drawing;

    internal class BackgroundColourCommand : ScenePropertyCommand<Color>
    {
        internal BackgroundColourCommand(Color value) : base("Background Colour",
            value, r => r._BackgroundColour, (r, v) => r._BackgroundColour = v)
        { }
    }
}
