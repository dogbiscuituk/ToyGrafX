// <copyright file="GraphicsModeCommands.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Commands
{
    using ToyGraf.Engine.Types;
    using ToyGraf.Models;

    internal class AccumColourFormatCommand : ScenePropertyCommand<ColourFormat>
    {
        internal AccumColourFormatCommand(ColourFormat value) : base(DisplayNames.AccumColourFormat,
            value, s => s._AccumColourFormat, (s, v) => s._AccumColourFormat = v)
        { }
    }

    internal class BuffersCommand : ScenePropertyCommand<int>
    {
        internal BuffersCommand(int value) : base(DisplayNames.Buffers,
            value, s => s._Buffers, (s, v) => s._Buffers = v)
        { }
    }

    internal class ColourFormatCommand : ScenePropertyCommand<ColourFormat>
    {
        internal ColourFormatCommand(ColourFormat value) : base(DisplayNames.ColourFormat,
            value, s => s._ColourFormat, (s, v) => s._ColourFormat = v)
        { }
    }

    internal class DepthCommand : ScenePropertyCommand<int>
    {
        internal DepthCommand(int value) : base(DisplayNames.Depth,
            value, s => s._Depth, (s, v) => s._Depth = v)
        { }
    }

    internal class SampleCountCommand : ScenePropertyCommand<int>
    {
        internal SampleCountCommand(int value) : base(DisplayNames.SampleCount,
            value, s => s._SampleCount, (s, v) => s._SampleCount = v)
        { }
    }

    internal class StencilCommand : ScenePropertyCommand<int>
    {
        internal StencilCommand(int value) : base(DisplayNames.Stencil,
            value, s => s._Stencil, (s, v) => s._Stencil = v)
        { }
    }

    internal class StereoCommand : ScenePropertyCommand<bool>
    {
        internal StereoCommand(bool value) : base(DisplayNames.Stereo,
            value, s => s._Stereo, (s, v) => s._Stereo = v)
        { }
    }

    internal class VSyncCommand : ScenePropertyCommand<bool>
    {
        internal VSyncCommand(bool value) : base(DisplayNames.VSync,
            value, s => s._VSync, (s, v) => s._VSync = v)
        { }
    }
}
