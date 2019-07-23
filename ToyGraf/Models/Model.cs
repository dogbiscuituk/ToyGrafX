namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;

    public class Model
    {
        public void Clear() { }

        public bool Modified { get; set; }

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;
    }
}
