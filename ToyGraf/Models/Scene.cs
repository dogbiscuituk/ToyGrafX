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

        public string GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return _Shader1Vertex;
                case ShaderType.TessControlShader:
                    return _Shader2TessControl;
                case ShaderType.TessEvaluationShader:
                    return _Shader3TessEvaluation;
                case ShaderType.GeometryShader:
                    return _Shader4Geometry;
                case ShaderType.FragmentShader:
                    return _Shader5Fragment;
                case ShaderType.ComputeShader:
                    return _Shader6Compute;
            }
            return string.Empty;
        }

        public void SetScript(ShaderType shaderType, string script)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    _Shader1Vertex = script;
                    break;
                case ShaderType.TessControlShader:
                    _Shader2TessControl = script;
                    break;
                case ShaderType.TessEvaluationShader:
                    _Shader3TessEvaluation = script;
                    break;
                case ShaderType.GeometryShader:
                    _Shader4Geometry = script;
                    break;
                case ShaderType.FragmentShader:
                    _Shader5Fragment = script;
                    break;
                case ShaderType.ComputeShader:
                    _Shader6Compute = script;
                    break;
            }
        }

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
        [Description(PropertyDescriptions.AccumColourFormat)]
        [DisplayName(PropertyNames.AccumColourFormat)]
        [JsonIgnore]
        public ColourFormat AccumColourFormat { get => _AccumColourFormat; set => Run(new AccumColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(Color), Defaults.BackgroundColourString)]
        [Description(PropertyDescriptions.BackgroundColour)]
        [DisplayName(PropertyNames.BackgroundColour)]
        [JsonIgnore]
        public Color BackgroundColour { get => _BackgroundColour; set => Run(new BackgroundColourCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description(PropertyDescriptions.ColourFormat)]
        [DisplayName(PropertyNames.ColourFormat)]
        [JsonIgnore]
        public ColourFormat ColourFormat { get => _ColourFormat; set => Run(new ColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Depth)]
        [Description(PropertyDescriptions.Depth)]
        [DisplayName(PropertyNames.Depth)]
        [JsonIgnore]
        public int Depth { get => _Depth; set => Run(new DepthCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stencil)]
        [Description(PropertyDescriptions.Stencil)]
        [DisplayName(PropertyNames.Stencil)]
        [JsonIgnore]
        public int Stencil { get => _Stencil; set => Run(new StencilCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.SampleCount)]
        [Description(PropertyDescriptions.SampleCount)]
        [DisplayName(PropertyNames.SampleCount)]
        [JsonIgnore]
        public int SampleCount { get => _SampleCount; set => Run(new SampleCountCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Buffers)]
        [Description(PropertyDescriptions.Buffers)]
        [DisplayName(PropertyNames.Buffers)]
        [JsonIgnore]
        public int Buffers { get => _Buffers; set => Run(new BuffersCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stereo)]
        [Description(PropertyDescriptions.Stereo)]
        [DisplayName(PropertyNames.Stereo)]
        [JsonIgnore]
        public bool Stereo { get => _Stereo; set => Run(new StereoCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.VSync)]
        [Description(PropertyDescriptions.VSync)]
        [DisplayName(PropertyNames.VSync)]
        [JsonIgnore]
        public bool VSync { get => _VSync; set => Run(new VSyncCommand(value)); }

        #endregion

        #region Projection

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.FieldOfView)]
        [Description(PropertyDescriptions.FieldOfView)]
        [DisplayName(PropertyNames.FieldOfView)]
        [JsonIgnore]
        public float FieldOfView { get => _FieldOfView; set => Run(new FieldOfViewCommand(value)); }

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.NearPlane)]
        [Description(PropertyDescriptions.NearPlane)]
        [DisplayName(PropertyNames.NearPlane)]
        [JsonIgnore]
        public float NearPlane { get => _NearPlane; set => Run(new NearPlaneCommand(value)); }

        [Category(Categories.Projection)]
        [DefaultValue(Defaults.FarPlane)]
        [Description(PropertyDescriptions.FarPlane)]
        [DisplayName(PropertyNames.FarPlane)]
        [JsonIgnore]
        public float FarPlane { get => _FarPlane; set => Run(new FarPlaneCommand(value)); }

        #endregion

        #region Read Only / System

        [Category(Categories.SystemRO)]
        [Description(PropertyDescriptions.CameraView)]
        [DisplayName(PropertyNames.CameraView)]
        [JsonIgnore]
        public Matrix4 CameraView
        {
            get => GetCameraView();
            set => Run(new CameraViewCommand(value));
        }

        [Category(Categories.SystemRO)]
        [DefaultValue(Defaults.GPUCode)]
        [Description(PropertyDescriptions.GPUCode)]
        [DisplayName(PropertyNames.GPUCode)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPUCode => _GPUCode;

        [Category(Categories.SystemRO)]
        [DefaultValue(Defaults.GPULog)]
        [Description(PropertyDescriptions.GPULog)]
        [DisplayName(PropertyNames.GPULog)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPULog => _GPULog;

        [Category(Categories.SystemRO)]
        [DefaultValue(typeof(GPUStatus), Defaults.GPUStatusString)]
        [Description(PropertyDescriptions.GPUStatus)]
        [DisplayName(PropertyNames.GPUStatus)]
        [JsonIgnore]
        public GPUStatus GPUStatus => _GPUStatus;

        [Category(Categories.SystemRO)]
        [Description(PropertyDescriptions.Projection)]
        [DisplayName(PropertyNames.Projection)]
        [JsonIgnore]
        public Matrix4 Projection
        {
            get => GetProjection();
            set => Run(new ProjectionCommand(value));
        }

        #endregion

        #region Scene

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Point3F), Defaults.CameraPositionString)]
        [Description(PropertyDescriptions.CameraPosition)]
        [DisplayName(PropertyNames.CameraPosition)]
        [JsonIgnore]
        public Point3F CameraPosition { get => _CameraPosition; set => Run(new CameraPositionCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Euler3F), Defaults.CameraRotationString)]
        [Description(PropertyDescriptions.CameraRotation)]
        [DisplayName(PropertyNames.CameraRotation)]
        [JsonIgnore]
        public Euler3F CameraRotation { get => _CameraRotation; set => Run(new CameraRotationCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.FPS)]
        [Description(PropertyDescriptions.FPS)]
        [DisplayName(PropertyNames.FPS)]
        [JsonIgnore]
        public double FPS { get => _FPS; set => Run(new FpsCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.Title)]
        [Description(PropertyDescriptions.Title)]
        [DisplayName(PropertyNames.Title)]
        [JsonIgnore]
        public string Title { get => _Title; set => Run(new TitleCommand(value)); }

        [Category(Categories.Scene)]
        [Description(PropertyDescriptions.Traces)]
        [DisplayName(PropertyNames.Traces)]
        [Editor(typeof(TgCollectionEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public List<Trace> Traces
        {
            get => _Traces.Select(t => t.Clone()).ToList();
            set => _Traces = value;
        }

        #endregion

        #region Shaders

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader1Vertex)]
        [Description(PropertyDescriptions.Shader1Vertex)]
        [DisplayName(PropertyNames.Shader1Vertex)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader1Vertex
        {
            get => _Shader1Vertex;
            set => Run(new SceneVertexShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader2TessControl)]
        [Description(PropertyDescriptions.Shader2TessControl)]
        [DisplayName(PropertyNames.Shader2TessControl)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader2TessControl
        {
            get => _Shader2TessControl;
            set => Run(new SceneTessControlShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader3TessEvaluation)]
        [Description(PropertyDescriptions.Shader3TessEvaluation)]
        [DisplayName(PropertyNames.Shader3TessEvaluation)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader3TessEvaluation
        {
            get => _Shader3TessEvaluation;
            set => Run(new SceneTessEvaluationShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader4Geometry)]
        [Description(PropertyDescriptions.Shader4Geometry)]
        [DisplayName(PropertyNames.Shader4Geometry)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader4Geometry
        {
            get => _Shader4Geometry;
            set => Run(new SceneGeometryShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader5Fragment)]
        [Description(PropertyDescriptions.Shader5Fragment)]
        [DisplayName(PropertyNames.Shader5Fragment)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader5Fragment
        {
            get => _Shader5Fragment;
            set => Run(new SceneFragmentShaderCommand(value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader6Compute)]
        [Description(PropertyDescriptions.Shader6Compute)]
        [DisplayName(PropertyNames.Shader6Compute)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader6Compute
        {
            get => _Shader6Compute;
            set => Run(new SceneComputeShaderCommand(value));
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
        [JsonProperty] internal string _GPUCode;
        [JsonProperty] internal string _GPULog;
        [JsonProperty] internal GPUStatus _GPUStatus;
        [JsonProperty] internal float _NearPlane;
        [JsonProperty] internal int _SampleCount;
        [JsonProperty] internal string _Shader1Vertex;
        [JsonProperty] internal string _Shader2TessControl;
        [JsonProperty] internal string _Shader3TessEvaluation;
        [JsonProperty] internal string _Shader4Geometry;
        [JsonProperty] internal string _Shader5Fragment;
        [JsonProperty] internal string _Shader6Compute;
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

        internal void AddTrace(Trace trace) => _Traces.Add(trace);

        internal void AttachTraces()
        {
            foreach (var trace in _Traces)
                trace.Init(this);
        }

        internal void InsertTrace(int index, Trace trace) => _Traces.Insert(index, trace);

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
                _Traces.RemoveAt(index);
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
                Shaders = "Shader Templates",
                SystemRO = "Read Only / System";
        }

        private class Defaults
        {
            internal const string
                BackgroundColourString = "White",
                CameraPositionString = "0, 0, 0",
                CameraRotationString = "0, 0, 0",
                ColourFormatString = "0, 0, 0, 0",
                GPUCode = "",
                GPULog = "",
                GPUStatusString = "OK",
                Shader1Vertex = @"// Vertex Shader

#version 330 core

layout (location = 0) in vec3 position;
out vec3 colour;

uniform mat4 cameraView;
uniform mat4 projection;
uniform float timeValue;
uniform int traceIndex;
uniform mat4 transform;

void main()
{
 float
  t = timeValue,
  x = position.x,
  y = position.y,
  z = position.z,
  r = 0,
  g = 0,
  b = 0;

 switch (traceIndex)
 {",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader5Fragment = @"// Fragment Shader

#version 330 core

in vec3 colour;
out vec4 FragColor;

uniform int traceIndex;

void main()
{
 switch (traceIndex)
 {",
                Shader6Compute = "",
                Title = "";

            internal const bool
                Stereo = false,
                VSync = false;

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

            internal GPUStatus
                GPUStatus = GPUStatus.OK;

            internal static Color
                BackgroundColour = Color.White;

            internal static ColourFormat
                ColourFormat = new ColourFormat(8),
                AccumColourFormat = new ColourFormat();

            internal static Euler3F
                CameraRotation = new Euler3F();

            internal static Point3F
                CameraPosition = new Point3F();

            internal static List<Trace>
                Traces => new List<Trace>();
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

        #endregion

        #region Private Methods

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
            _GPUCode = Defaults.GPUCode;
            _GPULog = Defaults.GPULog;
            _NearPlane = Defaults.NearPlane;
            _SampleCount = Defaults.SampleCount;
            _Shader1Vertex = Defaults.Shader1Vertex;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Defaults.Shader5Fragment;
            _Shader6Compute = Defaults.Shader6Compute;
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
    }
}
