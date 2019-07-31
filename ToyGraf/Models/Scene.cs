namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Linq;
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

        #region Public Editable Properties

        [Category("Scene")]
        [Description("A cap on this scene's rendering frequency.")]
        [DisplayName("Frames per second (FPS)")]
        [JsonIgnore]
        public double FramesPerSecond { get => _FramesPerSecond; set => Run(new SceneFramesPerSecondCommand(value)); }

        [Category("Scene")]
        [Description("A title for this scene.")]
        [DisplayName("Title")]
        [JsonIgnore]
        public string Title { get => _Title; set => Run(new SceneTitleCommand(value)); }

        [Category("Scene")]
        [Description("A list of the traces in this scene.")]
        [DisplayName("Traces")]
        [Editor(typeof(TgCollectionEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public List<Trace> Traces
        {
            get => _Traces.Select(t => t.Clone()).ToList();
            set => _Traces = value;
        }

        [Category("Camera")]
        [Description("The X component of the Camera's Location.")]
        [DisplayName("Camera (X)")]
        [JsonIgnore]
        public float CameraX { get => _CameraX; set => Run(new CameraXCommand(value)); }

        [Category("Camera")]
        [Description("The Y component of the Camera's Location.")]
        [DisplayName("Camera (Y)")]
        [JsonIgnore]
        public float CameraY { get => _CameraY; set => Run(new CameraYCommand(value)); }

        [Category("Camera")]
        [Description("The Z component of the Camera's Location.")]
        [DisplayName("Camera (Z)")]
        [JsonIgnore]
        public float CameraZ { get => _CameraZ; set => Run(new CameraZCommand(value)); }

        [Category("Camera")]
        [Description("The Pitch component of the Camera's Rotation (in degrees).")]
        [DisplayName("Camera Pitch°")]
        [JsonIgnore]
        public float CameraPitch { get => _CameraPitch; set => Run(new CameraPitchCommand(value)); }

        [Category("Camera")]
        [Description("The Roll component of the Camera's Rotation (in degrees).")]
        [DisplayName("Camera Roll°")]
        [JsonIgnore]
        public float CameraRoll { get => _CameraRoll; set => Run(new CameraRollCommand(value)); }

        [Category("Camera")]
        [Description("The Yaw component of the Camera's Rotation (in degrees).")]
        [DisplayName("Camera Yaw°")]
        [JsonIgnore]
        public float CameraYaw { get => _CameraYaw; set => Run(new CameraYawCommand(value)); }

        #endregion

        internal bool IsModified
        {
            get => CommandProcessor?.IsModified ?? false;
            set => CommandProcessor.IsModified = value;
        }

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal SceneController SceneController;
        const double DefaultFramesPerSecond = 60;

        #region Persistent Fields

        [JsonProperty]
        internal float
            _CameraX,
            _CameraY,
            _CameraZ,
            _CameraPitch,
            _CameraRoll,
            _CameraYaw;

        [JsonProperty]
        internal double _FramesPerSecond = DefaultFramesPerSecond;

        [JsonProperty]
        internal string _Title = "(untitled)";

        [JsonProperty]
        internal List<Trace> _Traces = new List<Trace>();

        #endregion

        #region Non-Public Methods

        internal void AddTrace(Trace trace)
        {
            _Traces.Add(trace);
            OnPropertyChanged("Traces");
        }

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Init(this);
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
