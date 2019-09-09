﻿namespace ToyGraf.Engine.Types
{
    using OpenTK.Graphics;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(ColourFormatTypeConverter))]
    public class ColourFormat
    {
        #region Constructors

        public ColourFormat() : this(0) { }

        public ColourFormat(int bpp) : this(bpp, bpp, bpp, bpp) { }

        public ColourFormat(ColourFormat colourFormat) :
            this(colourFormat.Red, colourFormat.Green, colourFormat.Blue, colourFormat.Alpha)
        { }

        public ColourFormat(ColourFormat colourFormat, string fieldName, int value) :
            this(colourFormat)
        {
            switch (fieldName)
            {
                case DisplayNames.Red: Red = value; break;
                case DisplayNames.Green: Green = value; break;
                case DisplayNames.Blue: Blue = value; break;
                case DisplayNames.Alpha: Alpha = value; break;
            }
        }

        public ColourFormat(int red, int green, int blue, int alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        #endregion

        #region Public Classes

        public static class Descriptions
        {
            public const string
                Red = "The Red component of the colour format.",
                Green = "The Green component of the colour format.",
                Blue = "The Blue component of the colour format.",
                Alpha = "The Alpha component of the colour format.";
        }

        public static class DisplayNames
        {
            public const string
                Red = "Red",
                Green = "Green",
                Blue = "Blue",
                Alpha = "Alpha";
        }

        #endregion

        #region Public Properties

        [DefaultValue(0)]
        [Description(Descriptions.Red)]
        [DisplayName(DisplayNames.Red)]
        public int Red { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Green)]
        [DisplayName(DisplayNames.Green)]
        public int Green { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Blue)]
        [DisplayName(DisplayNames.Blue)]
        public int Blue { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Alpha)]
        [DisplayName(DisplayNames.Alpha)]
        public int Alpha { get; set; }

        #endregion

        #region Public Operators

        public static bool operator ==(ColourFormat p, ColourFormat q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(ColourFormat p, ColourFormat q) => !(p == q);

        public static implicit operator ColorFormat(ColourFormat p) => new ColorFormat(p.Red, p.Green, p.Blue, p.Alpha);
        public static implicit operator ColourFormat(ColorFormat p) => new ColourFormat(p.Red, p.Green, p.Blue, p.Alpha);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is ColourFormat f &&
            f.Red == Red && f.Green == Green && f.Blue == Blue && f.Alpha == Alpha;
        public override int GetHashCode() => Red ^ Green ^ Blue ^ Alpha;
        public override string ToString() => $"{Red}, {Green}, {Blue}, {Alpha}";

        public static ColourFormat Parse(string s)
        {
            var t = s.Split(',');
            return new ColourFormat(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]), int.Parse(t[3]));
        }

        #endregion
    }
}