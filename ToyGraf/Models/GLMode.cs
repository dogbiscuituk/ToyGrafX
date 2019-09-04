namespace ToyGraf.Models
{
    using OpenTK;
    using OpenTK.Graphics;
    using System.ComponentModel;

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

        [Description(Descriptions.GLMode_AccumColourFormat)]
        [DisplayName(DisplayNames.GLMode_AccumColourFormat)]
        public string AccumColourFormat { get; }

        [Description(Descriptions.GLMode_Buffers)]
        [DisplayName(DisplayNames.GLMode_Buffers)]
        public int Buffers { get; }

        [Description(Descriptions.GLMode_ColourFormat)]
        [DisplayName(DisplayNames.GLMode_ColourFormat)]
        public string ColourFormat { get; }

        [Description(Descriptions.GLMode_Depth)]
        [DisplayName(DisplayNames.GLMode_Depth)]
        public int Depth { get; }

        [Description(Descriptions.GLMode_Index)]
        [DisplayName(DisplayNames.GLMode_Index)]
        public System.IntPtr? Index { get; }

        [Description(Descriptions.GLMode_SampleCount)]
        [DisplayName(DisplayNames.GLMode_SampleCount)]
        public int SampleCount { get; }

        [Description(Descriptions.GLMode_Stencil)]
        [DisplayName(DisplayNames.GLMode_Stencil)]
        public int Stencil { get; }

        [Description(Descriptions.GLMode_Stereo)]
        [DisplayName(DisplayNames.GLMode_Stereo)]
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
