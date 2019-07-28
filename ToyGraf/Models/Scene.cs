namespace ToyGraf.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using ToyGraf.Commands;
    using ToyGraf.Controllers;
    using ToyGraf.Controls;

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
        [Description("A cap on this scene's rendering frequency.")]
        [DisplayName("Frames per second (FPS)")]
        public double FramesPerSecond { get => _FramesPerSecond; set => Run(new SceneFramesPerSecondCommand(value)); }

        [Category("Scene")]
        [Description("A title for this scene.")]
        [DisplayName("Title")]
        public string Title { get => _Title; set => Run(new SceneTitleCommand(value)); }

        [Category("Scene")]
        [Description("A list of the traces in this scene.")]
        [DisplayName("Traces")]
        [Editor(typeof(TgCollectionEditor), typeof(UITypeEditor))]
        public List<Trace> Traces { get => _Traces; set => _Traces = value; }

        [Category("Camera")]
        [Description("The X component of the Camera's Location.")]
        [DisplayName("Camera (X)")]
        public float CameraLocationX { get => _CameraLocationX; set => Run(new CameraLocationXCommand(value)); }

        [Category("Camera")]
        [Description("The Y component of the Camera's Location.")]
        [DisplayName("Camera (Y)")]
        public float CameraLocationY { get => _CameraLocationY; set => Run(new CameraLocationYCommand(value)); }

        [Category("Camera")]
        [Description("The Z component of the Camera's Location.")]
        [DisplayName("Camera (Z)")]
        public float CameraLocationZ { get => _CameraLocationZ; set => Run(new CameraLocationZCommand(value)); }

        [Category("Camera")]
        [Description("The Pitch component of the Camera's Rotation.")]
        [DisplayName("Camera Pitch")]
        public float CameraRotationPitch { get => _CameraRotationPitch; set => Run(new CameraRotationPitchCommand(value)); }

        [Category("Camera")]
        [Description("The Roll component of the Camera's Rotation.")]
        [DisplayName("Camera Roll")]
        public float CameraRotationRoll { get => _CameraRotationRoll; set => Run(new CameraRotationRollCommand(value)); }

        [Category("Camera")]
        [Description("The Yaw component of the Camera's Rotation.")]
        [DisplayName("Camera Yaw")]
        public float CameraRotationYaw { get => _CameraRotationYaw; set => Run(new CameraRotationYawCommand(value)); }

        #endregion

        internal bool IsModified
        {
            get => CommandProcessor?.IsModified ?? false;
            set => CommandProcessor.IsModified = value;
        }

        #region Private Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        private SceneController SceneController;
        const double DefaultFramesPerSecond = 60;

        internal double _FramesPerSecond = DefaultFramesPerSecond;
        internal string _Title = "(untitled)";
        internal List<Trace> _Traces = new List<Trace>();
        internal float
            _CameraLocationX,
            _CameraLocationY,
            _CameraLocationZ,
            _CameraRotationPitch,
            _CameraRotationRoll,
            _CameraRotationYaw;

        #endregion

        #region Private Methods

        internal void AddTrace(Trace trace)
        {
            _Traces.Add(trace);
            OnPropertyChanged("Traces");
        }

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Scene = this;
        }

        internal void InsertTrace(int index, Trace trace)
        {
            _Traces.Insert(index, trace);
            OnPropertyChanged("Traces");
        }

        internal Trace NewTrace()
        {
            var trace = new Trace(this);
            _Traces.Add(trace);
            return trace;
        }

        internal void OnPropertyChanged(string propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < _Traces.Count)
            {
                _Traces.RemoveAt(index);
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
