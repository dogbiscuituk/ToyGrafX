namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(ColourFormatTypeConverter))]
    public class ColourFormat
    {
        public ColourFormat() : this(0) { }

        public ColourFormat(int bpp) : this(bpp, bpp, bpp, bpp) { }

        public ColourFormat(int red, int green, int blue, int alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }

        public override bool Equals(object obj) => obj is ColourFormat f &&
            f.Red == Red && f.Green == Green && f.Blue == Blue && f.Alpha == Alpha;
        public override int GetHashCode() => Red ^ Green ^ Blue ^ Alpha;
        public override string ToString() => $"(Red: {Red}, Green: {Green}, Blue: {Blue}, Alpha: {Alpha})";
    }
}
