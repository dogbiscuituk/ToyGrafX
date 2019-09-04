namespace ToyGraf.Commands
{
    using ToyGraf.Models;

    internal class VSyncCommand : ScenePropertyCommand<bool>
    {
        internal VSyncCommand(bool value) : base(DisplayNames.VSync,
            value, s => s._VSync, (s, v) => s._VSync = v)
        { }
    }
}
