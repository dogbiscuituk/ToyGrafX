namespace ToyGraf.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using ToyGraf.Commands;

    public class Scene
    {
        #region Public Interface

        public Scene(ISceneController sceneController)
        {
            SceneController = sceneController;
            RestoreDefaults();
        }

        public bool Modified { get; set; }

        public List<Trace> Traces = new List<Trace>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Clear() { }

        #endregion

        #region Private Properties

        internal ICommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private ISceneController SceneController;

        #endregion

        #region Private Methods

        internal void AddTrace(Trace trace)
        {
            Traces.Add(trace);
            OnPropertyChanged("Traces");
        }

        internal void InsertTrace(int index, Trace trace)
        {
            Traces.Insert(index, trace);
            OnPropertyChanged("Traces");
        }

        internal Trace NewTrace()
        {
            var trace = new Trace(this);
            Traces.Add(trace);
            return trace;
        }

        internal void OnPropertyChanged(string propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < Traces.Count)
            {
                Traces.RemoveAt(index);
                OnPropertyChanged("Traces");
            }
        }

        public void RemoveTraceRange(int index, int count)
        {
            while (count-- > 0)
                RemoveTrace(index + count);
        }

        private void RestoreDefaults()
        {
        }

        #endregion
    }
}
