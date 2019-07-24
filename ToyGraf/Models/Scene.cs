namespace ToyGraf.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Scene
    {
        public void Clear() { }

        public bool Modified { get; set; }

        public List<Trace> Traces = new List<Trace>();

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        internal Trace NewTrace(int index)
        {
            throw new NotImplementedException();
        }

        internal void AddTrace(Trace value)
        {
            throw new NotImplementedException();
        }

        internal void InsertTrace(int index, Trace value)
        {
            throw new NotImplementedException();
        }

        internal void RemoveTrace(int index)
        {
            throw new NotImplementedException();
        }
    }
}
