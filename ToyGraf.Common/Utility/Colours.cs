namespace ToyGraf.Common.Utility
{
    using System.Drawing;
    using System.Reflection;

    public static class Colours
    {
        public static Brush ToBrush(this Color colour)
        {
            var bindingFlags = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static;
            var propInfo = typeof(Brushes).GetProperty(colour.Name, bindingFlags);
            if (propInfo != null)
                return (Brush)propInfo.GetValue(null);
            return new SolidBrush(colour);
        }
    }
}
