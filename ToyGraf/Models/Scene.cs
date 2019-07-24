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
        }

        public void Clear() { }

        public bool Modified { get; set; }

        public List<Trace> Traces = new List<Trace>();

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        #endregion

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

        #region Private Properties

        internal ICommandProcessor CommandProcessor => SceneController.CommandProcessor;
        private ISceneController SceneController;

        #endregion
    }
}
