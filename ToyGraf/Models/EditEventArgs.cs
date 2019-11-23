namespace ToyGraf.Models
{
    using System;

    public class EditEventArgs : EventArgs
    {
        public EditEventArgs(string text) : base() => Text = text;

        public string Text { get; set; }
    }
}
