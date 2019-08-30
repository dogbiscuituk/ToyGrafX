// <copyright file="TgFlagsCheckedListBoxItem.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Controls
{
    public class TgFlagsCheckedListBoxItem
    {
        public TgFlagsCheckedListBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public string Text;
        public int Value;

        public override string ToString() => Text;


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
