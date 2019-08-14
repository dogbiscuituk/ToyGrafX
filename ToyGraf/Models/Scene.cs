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
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Views;

    [DefaultProperty("Traces")]
    public class Scene
    {
        #region Internal Interface

        public Scene() => RestoreDefaults();

        internal Scene(SceneController sceneController) : this() => SceneController = sceneController;

        internal Matrix4 GetCameraView() => Maths.CreateCameraView(CameraPosition, CameraRotation);
        internal Matrix4 GetProjection() => Maths.CreatePerspectiveProjection(FieldOfView, AspectRatio, NearPlane, FarPlane);

        internal void SetCameraView(Matrix4 cameraView) { }
        internal void SetProjection(Matrix4 projection) { }

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Title)
            ? _Title
            : "New scene";

        internal event PropertyChangedEventHandler PropertyChanged;

        internal void Clear()
        {
            RestoreDefaults();
            OnPropertyChanged(string.Empty);
        }

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
        [DefaultValue(Defaults.Title)]
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

        [Category(Categories.Camera)]
        [DefaultValue(typeof(Point3F), Defaults.CameraPositionString)]
        [Description("The camera position for the scene.")]
        [DisplayName("Position")]
        [JsonIgnore]
        public Point3F CameraPosition { get => _CameraPosition; set => Run(new CameraPositionCommand(value)); }

        [Category(Categories.Camera)]
        [DefaultValue(typeof(Euler3F), Defaults.CameraRotationString)]
        [Description("The camera rotation for the scene (in degrees).")]
        [DisplayName("Rotation°")]
        [JsonIgnore]
        public Euler3F CameraRotation { get => _CameraRotation; set => Run(new CameraRotationCommand(value)); }

        #endregion

        #region Graphics Mode

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.AccumColourFormatString)]
        [Description("The number of bits per pixel in each accumulator colour channel.")]
        [DisplayName("Accumulator Colour Format")]
        [JsonIgnore]
        public ColourFormat AccumColourFormat { get => _AccumColourFormat; set => Run(new AccumColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description("The number of bits per pixel in each colour channel.")]
        [DisplayName("Colour Format")]
        [JsonIgnore]
        public ColourFormat ColourFormat { get => _ColourFormat; set => Run(new ColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Depth)]
        [Description("The number of bits in the depth buffer.")]
        [DisplayName("Depth Bits")]
        [JsonIgnore]
        public int Depth { get => _Depth; set => Run(new DepthCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stencil)]
        [Description("The number of bits in the stencil buffer.")]
        [DisplayName("Stencil Bits")]
        [JsonIgnore]
        public int Stencil { get => _Stencil; set => Run(new StencilCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.SampleCount)]
        [Description("The number of Full Screen Anti-Aliasing (FSAA) samples used.")]
        [DisplayName("Sample Count")]
        [JsonIgnore]
        public int SampleCount { get => _SampleCount; set => Run(new SampleCountCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Buffers)]
        [Description("The number of buffers associated with this display mode.")]
        [DisplayName("Buffers")]
        [JsonIgnore]
        public int Buffers { get => _Buffers; set => Run(new BuffersCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stereo)]
        [Description("Whether this display mode is stereoscopic.")]
        [DisplayName("Stereo")]
        [JsonIgnore]
        public bool Stereo { get => _Stereo; set => Run(new StereoCommand(value)); }

        #endregion

        #region Projection

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.FieldOfView)]
        [Description("The frustrum field of view (Y component, degrees).")]
        [DisplayName("Field of View° Y")]
        [JsonIgnore]
        public float FieldOfView { get => _FieldOfView; set => Run(new FieldOfViewCommand(value)); }

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.NearPlane)]
        [Description("The distance from the camera position to the near plane of the frustrum.")]
        [DisplayName("Near Plane")]
        [JsonIgnore]
        public float NearPlane { get => _NearPlane; set => Run(new NearPlaneCommand(value)); }

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.FarPlane)]
        [Description("The distance from the camera position to the far plane of the frustrum.")]
        [DisplayName("Far Plane")]
        [JsonIgnore]
        public float FarPlane { get => _FarPlane; set => Run(new FarPlaneCommand(value)); }

        #endregion

        #region Read Only / System

        [Category(Categories.SystemRO)]
        [Description("The camera view matrix for the scene.")]
        [DisplayName("Camera View")]
        [JsonIgnore]
        public Matrix4 CameraView
        {
            get => GetCameraView();
            set => Run(new CameraViewCommand(value));
        }

        [Category(Categories.SystemRO)]
        [Description("The projection matrix for the scene.")]
        [DisplayName("Projection")]
        [JsonIgnore]
        public Matrix4 Projection
        {
            get => GetProjection();
            set => Run(new SceneProjectionCommand(value));
        }

        #endregion

        #region Renderer

        [Category(Categories.Renderer)]
        [DefaultValue(typeof(Color), Defaults.BackgroundColourString)]
        [Description("The colour of the background.")]
        [DisplayName("Background Colour")]
        [JsonIgnore]
        public Color BackgroundColour { get => _BackgroundColour; set => Run(new BackgroundColourCommand(value)); }

        #endregion

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal bool IsModified => CommandProcessor?.IsModified ?? false;
        internal SceneController SceneController;

        #endregion

        #region Persistent Fields

        [JsonProperty]
        internal bool
            _Stereo;

        [JsonProperty]
        internal int
            _Buffers,
            _Depth,
            _SampleCount,
            _Stencil;

        [JsonProperty]
        internal float
            _FieldOfView,
            _FarPlane,
            _NearPlane;

        [JsonProperty]
        internal double
            _FPS;

        [JsonProperty]
        internal Euler3F
            _CameraRotation;

        [JsonProperty]
        internal Point3F
            _CameraPosition;

        [JsonProperty]
        internal string
            _Title;

        [JsonProperty]
        internal Color
            _BackgroundColour;

        [JsonProperty]
        internal ColourFormat
            _AccumColourFormat,
            _ColourFormat;

        [JsonProperty]
        internal List<Trace>
            _Traces = new List<Trace>();

        #endregion

        #region Private Properties

        private float AspectRatio
        {
            get
            {
                var glControl = GLControl;
                if (glControl != null)
                {
                    float w = glControl.Width, h = glControl.Height;
                    if (w > 0 && h > 0)
                        return w / h;
                }
                return 1920f / 1080f;
            }
        }

        private GLControl GLControl => SceneForm?.GLControl;
        private SceneForm SceneForm => SceneController?.SceneForm;

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

        private void RestoreDefaults()
        {
            _Title = Defaults.Title;

            _AccumColourFormat = Defaults.AccumColourFormat;
            _Buffers = Defaults.Buffers;
            _ColourFormat = Defaults.ColourFormat;
            _Depth = Defaults.Depth;
            _SampleCount = Defaults.SampleCount;
            _Stencil = Defaults.Stencil;
            _Stereo = Defaults.Stereo;

            _CameraPosition = Defaults.CameraPosition;
            _CameraRotation = Defaults.CameraRotation;
            _FarPlane = Defaults.FarPlane;
            _FieldOfView = Defaults.FieldOfView;
            _NearPlane = Defaults.NearPlane;

            _FPS = Defaults.FPS;

            _BackgroundColour = Defaults.BackgroundColour;

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

        private class Categories
        {
            internal const string
                Camera = "Camera",
                GraphicsMode = "Graphics Mode",
                Projection = "Projection",
                Renderer = "Renderer",
                SystemRO = "Read Only / System";
        }

        private class Defaults
        {
            internal const string
                AccumColourFormatString = "(Red: 0, Green: 0, Blue: 0, Alpha: 0)",
                BackgroundColourString = "White",
                CameraPositionString = "(X: 0, Y: 0, Z: 0)",
                CameraRotationString = "(Pitch: 0, Yaw: 0, Roll: 0)",
                ColourFormatString = "(Red: 8, Green: 8, Blue: 8, Alpha: 8)",
                Title = "";

            internal const bool
                Stereo = false;

            internal const int
                Buffers = 2,
                Depth = 24,
                SampleCount = 0,
                Stencil = 8;

            internal const float
                FieldOfView = 75,
                NearPlane = 0.1f,
                FarPlane = 1000;

            internal const double
                FPS = 60;

            internal static Color
                BackgroundColour = Color.White;

            internal static ColourFormat
                ColourFormat = new ColourFormat(8),
                AccumColourFormat = new ColourFormat();

            internal static Euler3F
                CameraRotation = new Euler3F();

            internal static Point3F
                CameraPosition = new Point3F();

            internal static List<Trace> Traces =>
                new List<Trace>();
        }
    }
}
