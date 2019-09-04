namespace ToyGraf.Models
{
    using OpenTK;
    using OpenTK.Graphics;
    using System.ComponentModel;
    using ToyGraf.Engine.Types;

    [TypeConverter(typeof(GLModeTypeConverter))]
    public class GLMode
    {
        #region Constructors

        public GLMode(GLControl control)
        {
            var mode = control.GraphicsMode;
            AccumColourFormat = GetColourFormat(mode.AccumulatorFormat);
            Buffers = mode.Buffers;
            ColourFormat = GetColourFormat(mode.ColorFormat);
            Depth = mode.Depth;
            Index = mode.Index;
            SampleCount = mode.Samples;
            Stencil = mode.Stencil;
            Stereo = mode.Stereo;
        }

        #endregion

        #region Public Properties

        [Description(Descriptions.AccumColourFormat)]
        [DisplayName(DisplayNames.AccumColourFormat)]
        public string AccumColourFormat { get; }

        [Description(Descriptions.Buffers)]
        [DisplayName(DisplayNames.Buffers)]
        public int Buffers { get; }

        [Description(Descriptions.ColourFormat)]
        [DisplayName(DisplayNames.ColourFormat)]
        public string ColourFormat { get; }

        [Description(Descriptions.Depth)]
        [DisplayName(DisplayNames.Depth)]
        public int Depth { get; }

        [Description(Descriptions.GLModeIndex)]
        [DisplayName(DisplayNames.GLModeIndex)]
        public System.IntPtr? Index { get; }

        [Description(Descriptions.SampleCount)]
        [DisplayName(DisplayNames.SampleCount)]
        public int SampleCount { get; }

        [Description(Descriptions.Stencil)]
        [DisplayName(DisplayNames.Stencil)]
        public int Stencil { get; }

        [Description(Descriptions.Stereo)]
        [DisplayName(DisplayNames.Stereo)]
        public bool Stereo { get; }

        #endregion

        #region Public Methods

        public override string ToString() => $"{Index}";

        #endregion

        #region Private Methods

        public string GetColourFormat(ColorFormat source) =>
            $"{source.Red}, {source.Green}, {source.Blue}, {source.Alpha}";

        #endregion
    }
}
