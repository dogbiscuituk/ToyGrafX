namespace ToyGrafX.Engine.Utility
{
    public static class Strings
    {
        /// <summary>
        /// Convert a string, potentially containing ampersands, for use in an
        /// accelerator-enabled UI context (label text, menu item caption, etc).
        /// </summary>
        /// <param name="s">The input string</param>
        /// <returns>The input string with all ampersands escaped (doubled up).</returns>
        public static string AmpersandEscape(this string s) => s?.Replace("&", "&&");

        /// <summary>
        /// Convert a string, obtained from an accelerator-enabled UI context
        /// (label text, menu item caption, etc) and potentially containing double
        /// ampersands, for use in other contexts.
        /// </summary>
        /// <param name="s">The string obtained from the UI context.</param>
        /// <returns>The input string with all escaped (doubled) ampersands unescaped.</returns>
        public static string AmpersandUnescape(this string s) => s?.Replace("&&", "&");

    }
}
