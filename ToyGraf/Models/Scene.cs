namespace ToyGraf.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using ToyGraf.Commands;
    using ToyGraf.Controllers;

    public class Scene
    {
        #region Public Interface

        public Scene(SceneController sceneController)
        {
            SceneController = sceneController;
            RestoreDefaults();
        }

        public bool Modified { get; set; }

        public List<Trace> Traces = new List<Trace>();

        public bool UsesTime
        {
            get
            {
                return Traces.Any(p => p.Visible && p.UsesTime);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Clear() { }

        #endregion

        #region Persistent Properties

        [Category("Scene")]
        [Description("The title of this trace collection.")]
        public string Title { get => _Title; set => Run(new SceneTitleCommand(value)); }

        #endregion

        #region Private Properties

        internal CommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private SceneController SceneController;
        internal string _Title;

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

        private void Run(IScenePropertyCommand command) =>
            CommandProcessor.Run(command);

        #endregion
    }
}
