namespace ToyGraf.Commands
{
    using ToyGraf.Engine.Types;

    internal class AccumColourFormatCommand : ScenePropertyCommand<ColourFormat>
    {
        internal AccumColourFormatCommand(ColourFormat value) : base("Accumulator Colour Format", value,
            s => s._AccumColourFormat, (s, v) => s._AccumColourFormat = v) { }
    }

    internal class BuffersCommand : ScenePropertyCommand<int>
    {
        internal BuffersCommand(int value) : base("Buffers", value,
            s => s._Buffers, (s, v) => s._Buffers = v) { }
    }

    internal class ColourFormatCommand : ScenePropertyCommand<ColourFormat>
    {
        internal ColourFormatCommand(ColourFormat value) : base("Colour Format", value,
            s => s._ColourFormat, (s, v) => s._ColourFormat = v) { }
    }

    internal class DepthCommand : ScenePropertyCommand<int>
    {
        internal DepthCommand(int value) : base("Depth Buffer Size", value,
            s => s._Depth, (s, v) => s._Depth = v) { }
    }

    internal class SampleCountCommand : ScenePropertyCommand<int>
    {
        internal SampleCountCommand(int value) : base("FSAA Sample Count", value,
            s => s._SampleCount, (s, v) => s._SampleCount = v) { }
    }

    internal class StencilCommand : ScenePropertyCommand<int>
    {
        internal StencilCommand(int value) : base("Stencil Buffer Size", value,
            s => s._Stencil, (s, v) => s._Stencil = v) { }
    }

    internal class StereoCommand : ScenePropertyCommand<bool>
    {
        internal StereoCommand(bool value) : base("Stereo", value,
            s => s._Stereo, (s, v) => s._Stereo = v) { }
    }
}
