namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Linq;
    using System.Text;
    using ToyGraf.Commands;
    using ToyGraf.Controllers;
    using ToyGraf.Controls;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Views;

    [DefaultProperty("Traces")]
    public class Scene
    {
        #region Public Interface

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

        #region Graphics Mode

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description("The number of bits per pixel in each accumulator colour channel.")]
        [DisplayName("Accumulator Colour Format")]
        [JsonIgnore]
        public ColourFormat AccumColourFormat { get => _AccumColourFormat; set => Run(new AccumColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(Color), Defaults.BackgroundColourString)]
        [Description("The colour of the background.")]
        [DisplayName("Background Colour")]
        [JsonIgnore]
        public Color BackgroundColour { get => _BackgroundColour; set => Run(new BackgroundColourCommand(value)); }

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
        [Description("Indicates whether this display mode is stereoscopic 3D.")]
        [DisplayName("Stereo")]
        [JsonIgnore]
        public bool Stereo { get => _Stereo; set => Run(new StereoCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.VSync)]
        [Description("Indicates whether GLControl updates are synced to the monitor's refresh rate.")]
        [DisplayName("VSync")]
        [JsonIgnore]
        public bool VSync { get => _VSync; set => Run(new VSyncCommand(value)); }

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
        [DefaultValue(Defaults.GPUStatus)]
        [Description("The status of the most recent GPU compilation action. An empty value indicates successful compilation.")]
        [DisplayName("GPU Status")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPUStatus
        {
            get => _GPUStatus;
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

        #region Scene

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Point3F), Defaults.CameraPositionString)]
        [Description("The camera position for the scene.")]
        [DisplayName("Camera Position")]
        [JsonIgnore]
        public Point3F CameraPosition { get => _CameraPosition; set => Run(new CameraPositionCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Euler3F), Defaults.CameraRotationString)]
        [Description("The camera rotation for the scene (in degrees).")]
        [DisplayName("Camera Rotation°")]
        [JsonIgnore]
        public Euler3F CameraRotation { get => _CameraRotation; set => Run(new CameraRotationCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.FPS)]
        [Description("Frames per second: a cap on this scene's rendering frequency.")]
        [DisplayName("FPS")]
        [JsonIgnore]
        public double FPS { get => _FPS; set => Run(new SceneFpsCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.Title)]
        [Description("A title for this scene.")]
        [DisplayName("Title")]
        [JsonIgnore]
        public string Title { get => _Title; set => Run(new SceneTitleCommand(value)); }

        [Category(Categories.Scene)]
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

        #endregion

        #region Persistent Fields

        [JsonProperty] internal ColourFormat _AccumColourFormat;
        [JsonProperty] internal Color _BackgroundColour;
        [JsonProperty] internal int _Buffers;
        [JsonProperty] internal Point3F _CameraPosition;
        [JsonProperty] internal Euler3F _CameraRotation;
        [JsonProperty] internal ColourFormat _ColourFormat;
        [JsonProperty] internal int _Depth;
        [JsonProperty] internal float _FarPlane;
        [JsonProperty] internal float _FieldOfView;
        [JsonProperty] internal double _FPS;
        [JsonProperty] internal string _GPUStatus;
        [JsonProperty] internal float _NearPlane;
        [JsonProperty] internal int _SampleCount;
        [JsonProperty] internal int _Stencil;
        [JsonProperty] internal bool _Stereo;
        [JsonProperty] internal string _Title;
        [JsonProperty] internal List<Trace> _Traces = new List<Trace>();
        [JsonProperty] internal bool _VSync;

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal bool IsModified => CommandProcessor?.IsModified ?? false;
        internal SceneController SceneController;

        #endregion

        #region Internal Methods

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

        private int ProgramID;
        private StringBuilder ShaderLog = new StringBuilder();

        private int
            VertexShaderID,
            TessControlShaderID,
            TessEvaluationShaderID,
            GeometryShaderID,
            FragmentShaderID,
            ComputeShaderID;

        #endregion

        #region Private Methods

        private void AppendLog(string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
                ShaderLog.AppendLine(s);
        }

        private void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        private void BindAttributes()
        {
            BindAttribute(0, "position");
            BindAttribute(1, "time");
        }

        private void CreateProgram()
        {
            MakeCurrent(true);
            ShaderLog = new StringBuilder();
            ProgramID = GL.CreateProgram();
            CreateShaders();
            BindAttributes();
            GL.LinkProgram(ProgramID);
            GL.ValidateProgram(ProgramID);
            GetAllUniformLocations();


            var log = ShaderLog.ToString();
            ShaderLog = null;
#if DEBUG
            System.Diagnostics.Debug.WriteLine(log);
#endif
            DeleteShaders();
            MakeCurrent(false);
        }

        private int CreateShader(ShaderType shaderType, bool mandatory = false)
        {
            var scripts = new StringBuilder();
            foreach (var trace in _Traces)
            {
                var script = trace.GetScript(shaderType);
                if (!string.IsNullOrWhiteSpace(script))
                    scripts.AppendLine(script);
            }
            if (scripts.Length < 1)
                return 0;
            scripts.Insert(0, $@"// {shaderType}\n");
            scripts.Insert(0, '\n');
            scripts.Insert(0, $@"# {AppController.OpenGLProperties.OpenGLVersionNumber}\n");
            scripts.Insert(0, '\n');
            var shaderID = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderID, scripts.ToString());
            GL.CompileShader(shaderID);
            AppendLog(GL.GetShaderInfoLog(shaderID));
            GL.AttachShader(ProgramID, shaderID);
            return shaderID;
        }

        private void CreateShaders()
        {
            VertexShaderID = CreateShader(ShaderType.VertexShader, true);
            TessControlShaderID = CreateShader(ShaderType.TessControlShader);
            TessEvaluationShaderID = CreateShader(ShaderType.TessEvaluationShader);
            GeometryShaderID = CreateShader(ShaderType.GeometryShader);
            FragmentShaderID = CreateShader(ShaderType.FragmentShader, true);
            ComputeShaderID = CreateShader(ShaderType.ComputeShader);
        }

        private void DeleteShader(ref int shaderID)
        {
            if (shaderID == 0)
                return;
            GL.DetachShader(ProgramID, shaderID);
            GL.DeleteShader(shaderID);
            shaderID = 0;
        }

        private void DeleteShaders()
        {
            DeleteShader(ref VertexShaderID);
            DeleteShader(ref TessControlShaderID);
            DeleteShader(ref TessEvaluationShaderID);
            DeleteShader(ref GeometryShaderID);
            DeleteShader(ref FragmentShaderID);
            DeleteShader(ref ComputeShaderID);
        }

        private void GetAllUniformLocations()
        {

        }

        private bool MakeCurrent(bool current) => SceneController.MakeCurrent(current);

        private void RestoreDefaults()
        {
            _AccumColourFormat = Defaults.AccumColourFormat;
            _BackgroundColour = Defaults.BackgroundColour;
            _Buffers = Defaults.Buffers;
            _CameraPosition = Defaults.CameraPosition;
            _CameraRotation = Defaults.CameraRotation;
            _ColourFormat = Defaults.ColourFormat;
            _Depth = Defaults.Depth;
            _FarPlane = Defaults.FarPlane;
            _FieldOfView = Defaults.FieldOfView;
            _FPS = Defaults.FPS;
            _GPUStatus = Defaults.GPUStatus;
            _NearPlane = Defaults.NearPlane;
            _SampleCount = Defaults.SampleCount;
            _Stencil = Defaults.Stencil;
            _Stereo = Defaults.Stereo;
            _Title = Defaults.Title;
            _Traces = Defaults.Traces;
            _VSync = Defaults.VSync;
        }

        private void Run(IScenePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        #endregion

        #region Private Classes

        private class Categories
        {
            internal const string
                Camera = "Camera",
                GraphicsMode = "Graphics Mode",
                Projection = "Projection",
                Scene = "Scene",
                SystemRO = "Read Only / System";
        }

        private class Defaults
        {
            internal const string
                BackgroundColourString = "White",
                CameraPositionString = "0, 0, 0",
                CameraRotationString = "0, 0, 0",
                ColourFormatString = "0, 0, 0, 0",
                GPUStatus = "",
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

            internal const bool VSync = false;
        }

        #endregion
    }
}
