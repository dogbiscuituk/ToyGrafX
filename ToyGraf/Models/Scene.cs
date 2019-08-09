namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Linq;
    using ToyGraf.Commands;
    using ToyGraf.Controllers;
    using ToyGraf.Controls;
    using ToyGraf.Engine;
    using ToyGraf.Engine.Utility;

    [DefaultProperty("Traces")]
    public class Scene
    {
        #region Public Interface

        public Scene()
        {
            RestoreDefaults();
        }

        internal Scene(SceneController sceneController)
        {
            SceneController = sceneController;
            RestoreDefaults();
        }

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Title)
            ? _Title
            : "New scene";

        internal event PropertyChangedEventHandler PropertyChanged;

        internal void Clear() { }

        #endregion

        #region Browsable Properties

        #region Scene

        [Category("Scene")]
        [DefaultValue(Defaults.FPS)]
        [Description("Frames per second: a cap on this scene's rendering frequency.")]
        [DisplayName("FPS")]
        [JsonIgnore]
        public double FPS { get => _FPS; set => Run(new SceneFpsCommand(value)); }

        [Category("Scene")]
        [DefaultValue(Defaults.SceneTitle)]
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

        #endregion

        #region Camera

        [Category(Defaults.Camera)]
        [DefaultValue(Defaults.CameraX)]
        [Description("The X component of the camera position.")]
        [DisplayName("Camera (X)")]
        [JsonIgnore]
        public float CameraX { get => _CameraX; set => Run(new CameraXCommand(value)); }

        [Category(Defaults.Camera)]
        [DefaultValue(Defaults.CameraY)]
        [Description("The Y component of the camera position.")]
        [DisplayName("Camera (Y)")]
        [JsonIgnore]
        public float CameraY { get => _CameraY; set => Run(new CameraYCommand(value)); }

        [Category(Defaults.Camera)]
        [DefaultValue(Defaults.CameraZ)]
        [Description("The Z component of the camera position.")]
        [DisplayName("Camera (Z)")]
        [JsonIgnore]
        public float CameraZ { get => _CameraZ; set => Run(new CameraZCommand(value)); }

        [Category(Defaults.Camera)]
        [DefaultValue(Defaults.CameraPitch)]
        [Description("The pitch component of the camera orientation (in degrees).")]
        [DisplayName("Camera Pitch°")]
        [JsonIgnore]
        public float CameraPitch { get => _CameraPitch; set => Run(new CameraPitchCommand(value)); }

        [Category(Defaults.Camera)]
        [DefaultValue(Defaults.CameraRoll)]
        [Description("The roll component of the camera orientation (in degrees).")]
        [DisplayName("Camera Roll°")]
        [JsonIgnore]
        public float CameraRoll { get => _CameraRoll; set => Run(new CameraRollCommand(value)); }

        [Category(Defaults.Camera)]
        [DefaultValue(Defaults.CameraYaw)]
        [Description("The yaw component of the camera orientation (in degrees).")]
        [DisplayName("Camera Yaw°")]
        [JsonIgnore]
        public float CameraYaw { get => _CameraYaw; set => Run(new CameraYawCommand(value)); }

        #endregion

        #region Projection

        [Category(Defaults.Projection)]
        [DefaultValue(Defaults.FieldOfView)]
        [Description("The frustrum field of view (Y component, degrees).")]
        [DisplayName("Field of View Y°")]
        [JsonIgnore]
        public float FieldOfView { get => _FieldOfView; set => Run(new FieldOfViewCommand(value)); }

        [Category(Defaults.Projection)]
        [DefaultValue(Defaults.NearPlane)]
        [Description("The distance from the camera position to the near plane of the frustrum.")]
        [DisplayName("Near Plane")]
        [JsonIgnore]
        public float NearPlane { get => _NearPlane; set => Run(new NearPlaneCommand(value)); }

        [Category(Defaults.Projection)]
        [DefaultValue(Defaults.FarPlane)]
        [Description("The distance from the camera position to the far plane of the frustrum.")]
        [DisplayName("Far Plane")]
        [JsonIgnore]
        public float FarPlane { get => _FarPlane; set => Run(new FarPlaneCommand(value)); }

        #endregion

        #region Read Only / System

        [Category(Defaults.SystemRO)]
        [Description("The camera orientation for the scene.")]
        [DisplayName("Camera Orientation")]
        [JsonIgnore]
        public Vector3 CameraOrientation
        {
            get => GetCameraOrientation();
            set => Run(new CameraOrientationCommand(value));
        }

        [Category(Defaults.SystemRO)]
        [Description("The camera position for the scene.")]
        [DisplayName("Camera Position")]
        [JsonIgnore]
        public Vector3 CameraPosition
        {
            get => GetCameraPosition();
            set => Run(new CameraPositionCommand(value));
        }

        [Category(Defaults.SystemRO)]
        [Description("The camera view matrix for the scene.")]
        [DisplayName("Camera View")]
        [JsonIgnore]
        public Matrix4 CameraView
        {
            get => GetCameraView();
            set => Run(new CameraViewCommand(value));
        }

        [Category(Defaults.SystemRO)]
        [Description("The projection matrix for the scene.")]
        [DisplayName("Projection")]
        [JsonIgnore]
        public Matrix4 Projection
        {
            get => GetProjection();
            set => Run(new SceneProjectionCommand(value));
        }

        #endregion

        internal Vector3 GetCameraOrientation() => new Vector3(_CameraPitch, _CameraYaw, _CameraRoll);
        internal Vector3 GetCameraPosition() => new Vector3(_CameraX, _CameraY, _CameraZ);
        internal Matrix4 GetCameraView() => Maths.CreateCameraView(CameraPosition, CameraOrientation);
        internal Matrix4 GetProjection() => Maths.CreatePerspectiveProjection(FieldOfView, 1980f / 1080f, NearPlane, FarPlane);

        internal void SetCameraOrientation(Vector3 cameraOrientation)
        {
            _CameraPitch = cameraOrientation.X;
            _CameraYaw = cameraOrientation.Y;
            _CameraRoll = cameraOrientation.Z;
        }

        internal void SetCameraPosition(Vector3 cameraPosition)
        {
            _CameraX = cameraPosition.X;
            _CameraY = cameraPosition.Y;
            _CameraZ = cameraPosition.Z;
        }

        internal void SetCameraView(Matrix4 cameraView) { }
        internal void SetProjection(Matrix4 projection) { }

        #endregion

        internal bool IsModified
        {
            get => CommandProcessor?.IsModified ?? false;
            set => CommandProcessor.IsModified = value;
        }

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal SceneController SceneController;

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
        internal double _FPS;

        [JsonProperty]
        internal float
            _FarPlane,
            _FieldOfView,
            _NearPlane;

        [JsonProperty]
        internal string _Title;

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
            foreach (var trace in _Traces)
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
            //_Traces.Add(trace);
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
            // Scene Camera & Perspective

            _CameraX = Defaults.CameraX;
            _CameraY = Defaults.CameraY;
            _CameraZ = Defaults.CameraZ;
            _CameraPitch = Defaults.CameraPitch;
            _CameraRoll = Defaults.CameraRoll;
            _CameraYaw = Defaults.CameraYaw;
            _FieldOfView = Defaults.FieldOfView;
            _NearPlane = Defaults.NearPlane;
            _FarPlane = Defaults.FarPlane;

            // Scene FPS

            _FPS = Defaults.FPS;

            // Scene Title

            _Title = Defaults.SceneTitle;

            // Scene Traces

            _Traces = Defaults.Traces;
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
