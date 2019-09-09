﻿namespace ToyGraf.Models
{
    using OpenTK;
    using OpenTK.Graphics;
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.Types;

    [TypeConverter(typeof(GLModeTypeConverter))]
    public class GLMode
    {
        #region Constructors

        public GLMode(GLControl control) : this(control.GraphicsMode) { }

        public GLMode(GLMode mode) =>
            Init(mode.Index, mode.ColourFormat, mode.AccumColourFormat,
            mode.Buffers, mode.Depth, mode.Samples, mode.Stencil, mode.Stereo);

        public GLMode(IntPtr? index, ColourFormat colourFormat, ColourFormat accumColourFormat,
            int buffers, int depth, int samples, int stencil, bool stereo) =>
            Init(index, colourFormat, accumColourFormat, buffers, depth, samples, stencil, stereo);

        public GLMode(GLMode mode, string field, object value) : this(mode)
        {
            switch (field)
            {
                case DisplayNames.GLMode_Index:
                    Index = (IntPtr?)value;
                    return;
                case DisplayNames.GLMode_ColourFormat:
                    ColourFormat = new ColourFormat((ColourFormat)value);
                    return;
                case DisplayNames.GLMode_AccumColourFormat:
                    AccumColourFormat = new ColourFormat((ColourFormat)value);
                    return;
                case DisplayNames.GLMode_Buffers:
                    Buffers = (int)value;
                    return;
                case DisplayNames.GLMode_Depth:
                    Depth = (int)value;
                    return;
                case DisplayNames.GLMode_Samples:
                    Samples = (int)value;
                    return;
                case DisplayNames.GLMode_Stencil:
                    Stencil = (int)value;
                    return;
                case DisplayNames.GLMode_Stereo:
                    Stereo = (bool)value;
                    return;
            }
            var v = (int)value;
            var fields = field.Split('.');
            var p = fields[0] == DisplayNames.GLMode_AccumColourFormat ? AccumColourFormat : ColourFormat;
            switch (fields[1])
            {
                case ColourFormat.DisplayNames.Red: p.Red = v; break;
                case ColourFormat.DisplayNames.Green: p.Green = v; break;
                case ColourFormat.DisplayNames.Blue: p.Blue = v; break;
                case ColourFormat.DisplayNames.Alpha: p.Alpha = v; break;
            }
            switch (fields[0])
            {
                case DisplayNames.GLMode_AccumColourFormat:
                    AccumColourFormat = p;
                    break;
                case DisplayNames.GLMode_ColourFormat:
                    ColourFormat = p;
                    break;
            }
        }

        #endregion

        #region Public Properties

        [Description(Descriptions.GLMode_Index)]
        [DisplayName(DisplayNames.GLMode_Index)]
        public IntPtr? Index { get; set; }

        [Description(Descriptions.GLMode_ColourFormat)]
        [DisplayName(DisplayNames.GLMode_ColourFormat)]
        public ColourFormat ColourFormat { get; set; }

        [Description(Descriptions.GLMode_AccumColourFormat)]
        [DisplayName(DisplayNames.GLMode_AccumColourFormat)]
        public ColourFormat AccumColourFormat { get; set; }

        [Description(Descriptions.GLMode_Buffers)]
        [DisplayName(DisplayNames.GLMode_Buffers)]
        public int Buffers { get; set; }

        [Description(Descriptions.GLMode_Depth)]
        [DisplayName(DisplayNames.GLMode_Depth)]
        public int Depth { get; set; }

        [Description(Descriptions.GLMode_Samples)]
        [DisplayName(DisplayNames.GLMode_Samples)]
        public int Samples { get; set; }

        [Description(Descriptions.GLMode_Stencil)]
        [DisplayName(DisplayNames.GLMode_Stencil)]
        public int Stencil { get; set; }

        [Description(Descriptions.GLMode_Stereo)]
        [DisplayName(DisplayNames.GLMode_Stereo)]
        public bool Stereo { get; set; }

        #endregion

        #region Public Operators

        public static implicit operator GLMode(GraphicsMode p) => new GLMode(
            index: p.Index,
            colourFormat: new ColourFormat(p.ColorFormat),
            accumColourFormat: new ColourFormat(p.AccumulatorFormat),
            buffers: p.Buffers,
            depth: p.Depth,
            samples: p.Samples,
            stencil: p.Stencil,
            stereo: p.Stereo);

        public static implicit operator GraphicsMode(GLMode p) => new GraphicsMode(
            color: p.ColourFormat,
            accum: p.AccumColourFormat,
            buffers: p.Buffers,
            depth: p.Depth,
            samples: p.Samples,
            stencil: p.Stencil,
            stereo: p.Stereo);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is GLMode p
            && p.ColourFormat == ColourFormat
            && p.AccumColourFormat == AccumColourFormat
            && p.Buffers == Buffers
            && p.Depth == Depth
            && p.Samples == Samples
            && p.Stencil == Stencil
            && p.Stereo == Stereo;

        public override int GetHashCode() =>
            ColourFormat.GetHashCode() ^ AccumColourFormat.GetHashCode() ^
            Buffers ^ Depth ^ Samples ^ Stencil ^ (Stereo ? 1 : 0);

        public static GLMode Parse(string s)
        {
            var t = s.Split(',');
            return new GLMode((IntPtr?)0,
                new ColourFormat(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]), int.Parse(t[3])),
                new ColourFormat(int.Parse(t[4]), int.Parse(t[5]), int.Parse(t[6]), int.Parse(t[7])),
                int.Parse(t[8]), int.Parse(t[9]), int.Parse(t[10]), int.Parse(t[11]), bool.Parse(t[12]));
        }

        public override string ToString() =>
            $"{ColourFormat}, {AccumColourFormat}, {Buffers}, {Depth}, {Samples}, {Stencil}, {Stereo}";

        #endregion

        #region Private Methods

        public string GetColourFormat(ColorFormat source) =>
            $"{source.Red}, {source.Green}, {source.Blue}, {source.Alpha}";

        private void Init(IntPtr? index, ColourFormat colourFormat, ColourFormat accumColourFormat,
            int buffers, int depth, int samples, int stencil, bool stereo)
        {
            Index = index;
            ColourFormat = new ColourFormat(colourFormat);
            AccumColourFormat = new ColourFormat(accumColourFormat);
            Buffers = buffers;
            Depth = depth;
            Samples = samples;
            Stencil = stencil;
            Stereo = stereo;
        }

        #endregion
    }
}
