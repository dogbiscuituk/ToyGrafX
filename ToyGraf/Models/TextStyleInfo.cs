namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(TextStyleInfoTypeConverter))]
    public class TextStyleInfo
    {
        #region Constructors

        public TextStyleInfo(Color foreground, FontStyle fontStyle = 0)
            : this(foreground, Color.Transparent, fontStyle) { }

        public TextStyleInfo(Color foreground, Color background, FontStyle fontStyle = 0)
        {
            FontStyle = fontStyle;
            Foreground = foreground;
            Background = background;
        }

        #endregion

        #region Public Properties

        public Color Foreground { get; set; }
        public Color Background { get; set; }
        public FontStyle FontStyle { get; set; }

        #endregion

        public static TextStyleInfo Parse(string s)
        {
            var t = s.Split(',');
            return new TextStyleInfo(
                Color.FromName(t[0]),
                Color.FromName(t[1]),
                (FontStyle)Enum.Parse(typeof(FontStyle), t[2]));
        }

        public override string ToString() =>
            $"{Foreground.Name}, {Background.Name}, {FontStyle}";
    }
}
