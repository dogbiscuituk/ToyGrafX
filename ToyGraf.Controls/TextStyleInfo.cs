namespace ToyGraf.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;

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

        [Description("The foreground colour of the text style.")]
        public Color Foreground { get; set; }

        [DefaultValue(typeof(Color), "Transparent")]
        [Description("The background colour of the text style.")]
        public Color Background { get; set; }

        [DefaultValue(0)]
        [Description("The font attributes of the text style (bold, italic, underlined, etc).")]
        [Editor(typeof(TgFlagsEnumEditor), typeof(UITypeEditor))]
        public FontStyle FontStyle { get; set; }

        #endregion

        #region Public Methods

        public static TextStyleInfo Parse(string s)
        {
            var t = s.Split(';');
            return new TextStyleInfo(
                Color.FromName(t[0]),
                Color.FromName(t[1]),
                (FontStyle)Enum.Parse(typeof(FontStyle), t[2]));
        }

        public override string ToString() =>
            $"{Foreground.Name}; {Background.Name}; {FontStyle}";

        #endregion
    }
}
