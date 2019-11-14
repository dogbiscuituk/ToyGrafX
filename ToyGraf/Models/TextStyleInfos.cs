namespace ToyGraf.Models
{
    using System.Drawing;

    public class TextStyleInfos
    {
        #region Public Properties

        public TextStyleInfo Comments { get; set; } = new TextStyleInfo(Color.Green, FontStyle.Italic);
        public TextStyleInfo Directives { get; set; } = new TextStyleInfo(Color.Maroon);
        public TextStyleInfo Functions { get; set; } = new TextStyleInfo(Color.DarkTurquoise);
        public TextStyleInfo Keywords { get; set; } = new TextStyleInfo(Color.Blue);
        public TextStyleInfo Numbers { get; set; } = new TextStyleInfo(Color.Magenta);
        public TextStyleInfo ReservedWords { get; set; } = new TextStyleInfo(Color.Red);
        public TextStyleInfo Strings { get; set; } = new TextStyleInfo(Color.Brown);

        #endregion
    }
}
