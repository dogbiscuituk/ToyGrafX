namespace ToyGraf.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void Clear() { }

        #endregion

        #region Persistent Properties

        [Category("Scene")]
        [Description("The title of this trace collection.")]
        public string Title { get => _Title; set => Run(new SceneTitleCommand(value)); }

        [Category("Scene")]
        [Description("The list of traces in this collection.")]
        public List<Trace> Traces = new List<Trace>();

        #endregion

        internal bool IsModified => CommandProcessor?.IsModified ?? false;

        #region Private Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        private SceneController SceneController;
        internal string _Title = "(untitled)";

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

        private void Run(IScenePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        #endregion
    }
}
