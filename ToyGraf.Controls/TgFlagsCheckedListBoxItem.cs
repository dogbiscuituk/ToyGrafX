namespace ToyGraf.Controls
{
    public class TgFlagsCheckedListBoxItem
    {
        #region Constructors

        public TgFlagsCheckedListBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        #endregion

        #region Public Properties

        public string Text;
        public int Value;

        #endregion

        #region Public Methods

        public override string ToString() => Text;

        #endregion

        /// <summary>
        /// Is this a single bit flag?
        /// </summary>
        public bool IsFlag => (Value & (Value - 1)) == 0;

        /// <summary>
        /// Is this part of a flag set?
        /// </summary>
        /// <param name="flags">The flag set.</param>
        /// <returns>True if part of the flag set, otherwise false.</returns>
        public bool IsMemberFlag(TgFlagsCheckedListBoxItem flags) =>
            IsFlag && (Value & flags.Value) == Value;
    }
}
