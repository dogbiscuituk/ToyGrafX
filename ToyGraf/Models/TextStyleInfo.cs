namespace ToyGraf.Models
{
    using System.Drawing;

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
    }
}
