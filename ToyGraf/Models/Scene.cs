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
    using ToyGraf.Engine;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Views;

    public class Scene
    {
        #region Constructors

        public Scene() => RestoreDefaults();

        internal Scene(SceneController sceneController) : this() => SceneController = sceneController;

        #endregion

        #region Public Properties

        #region Graphics Mode

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description(Descriptions.AccumColourFormat)]
        [DisplayName(DisplayNames.AccumColourFormat)]
        [JsonIgnore]
        public ColourFormat AccumColourFormat { get => _AccumColourFormat; set => Run(new AccumColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(Color), Defaults.BackgroundColourString)]
        [Description(Descriptions.BackgroundColour)]
        [DisplayName(DisplayNames.BackgroundColour)]
        [JsonIgnore]
        public Color BackgroundColour { get => _BackgroundColour; set => Run(new BackgroundColourCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Buffers)]
        [Description(Descriptions.Buffers)]
        [DisplayName(DisplayNames.Buffers)]
        [JsonIgnore]
        public int Buffers { get => _Buffers; set => Run(new BuffersCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(typeof(ColourFormat), Defaults.ColourFormatString)]
        [Description(Descriptions.ColourFormat)]
        [DisplayName(DisplayNames.ColourFormat)]
        [JsonIgnore]
        public ColourFormat ColourFormat { get => _ColourFormat; set => Run(new ColourFormatCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Depth)]
        [Description(Descriptions.Depth)]
        [DisplayName(DisplayNames.Depth)]
        [JsonIgnore]
        public int Depth { get => _Depth; set => Run(new DepthCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.FPS)]
        [Description(Descriptions.FPS)]
        [DisplayName(DisplayNames.FPS)]
        [JsonIgnore]
        public double FPS { get => _FPS; set => Run(new FpsCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.SampleCount)]
        [Description(Descriptions.SampleCount)]
        [DisplayName(DisplayNames.SampleCount)]
        [JsonIgnore]
        public int SampleCount { get => _SampleCount; set => Run(new SampleCountCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stencil)]
        [Description(Descriptions.Stencil)]
        [DisplayName(DisplayNames.Stencil)]
        [JsonIgnore]
        public int Stencil { get => _Stencil; set => Run(new StencilCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.Stereo)]
        [Description(Descriptions.Stereo)]
        [DisplayName(DisplayNames.Stereo)]
        [JsonIgnore]
        public bool Stereo { get => _Stereo; set => Run(new StereoCommand(value)); }

        [Category(Categories.GraphicsMode)]
        [DefaultValue(Defaults.VSync)]
        [Description(Descriptions.VSync)]
        [DisplayName(DisplayNames.VSync)]
        [JsonIgnore]
        public bool VSync { get => _VSync; set => Run(new VSyncCommand(value)); }

        #endregion

        #region Read Only / System

        [Category(Categories.SystemRO)]
        [Description(Descriptions.CameraView)]
        [DisplayName(DisplayNames.CameraView)]
        [JsonIgnore]
        public Matrix4 CameraView
        {
            get => GetCameraView();
            set => Run(new CameraViewCommand(value));
        }

        [Category(Categories.SystemRO)]
        [Description(Descriptions.GLInfo)]
        [DisplayName(DisplayNames.GLInfo)]
        [JsonIgnore]
        public GLInfo GLInfo => RenderController._GLInfo ?? RenderController?.GLInfo;

        [Category(Categories.SystemRO)]
        [DefaultValue(Defaults.GPUCode)]
        [Description(Descriptions.GPUCode)]
        [DisplayName(DisplayNames.GPUCode)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPUCode => _GPUCode;

        [Category(Categories.SystemRO)]
        [DefaultValue(Defaults.GPULog)]
        [Description(Descriptions.GPULog)]
        [DisplayName(DisplayNames.GPULog)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPULog => _GPULog;

        [Category(Categories.SystemRO)]
        [DefaultValue(typeof(GPUStatus), Defaults.GPUStatusString)]
        [Description(Descriptions.GPUStatus)]
        [DisplayName(DisplayNames.GPUStatus)]
        [JsonIgnore]
        public GPUStatus GPUStatus => _GPUStatus;

        [Category(Categories.SystemRO)]
        [Description(Descriptions.ProjectionMatrix)]
        [DisplayName(DisplayNames.ProjectionMatrix)]
        [JsonIgnore]
        public Matrix4 ProjectionMatrix
        {
            get => GetProjection();
            set => Run(new ProjectionMatrixCommand(value));
        }

        #endregion

        #region Scene

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Point3F), Defaults.CameraString)]
        [Description(Descriptions.Camera)]
        [DisplayName(DisplayNames.Camera)]
        [JsonIgnore]
        public Camera Camera { get => _Camera; set => Run(new CameraCommand(value)); }

        [Category(Categories.Scene)]
        [Description(Descriptions.Projection)]
        [DisplayName(DisplayNames.Projection)]
        [JsonIgnore]
        public Projection Projection { get => _Projection; set => Run(new ProjectionCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.Title)]
        [Description(Descriptions.Title)]
        [DisplayName(DisplayNames.Title)]
        [JsonIgnore]
        public string Title { get => _Title; set => Run(new TitleCommand(value)); }

        [Category(Categories.Scene)]
        [Description(Descriptions.TraceList)]
        [DisplayName(DisplayNames.TraceList)]
        [Editor(typeof(TgCollectionEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public List<Trace> TraceList
        {
            get => Traces.Select(t => t.Clone()).ToList();
            set => Traces = value;
        }

        // Used as a DataSource.DataMember, so public visibility required.
        [JsonProperty]
        public List<Trace> Traces { get; private set; }

        #endregion

        #region Shaders

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.Shader1Vertex)]
        [Description(Descriptions.Shader1Vertex)]
        [DisplayName(DisplayNames.Shader1Vertex)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader1Vertex
        {
            get => _Shader1Vertex;
            set => Run(new SceneVertexShaderCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.Shader2TessControl)]
        [Description(Descriptions.Shader2TessControl)]
        [DisplayName(DisplayNames.Shader2TessControl)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader2TessControl
        {
            get => _Shader2TessControl;
            set => Run(new SceneTessControlShaderCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.Shader3TessEvaluation)]
        [Description(Descriptions.Shader3TessEvaluation)]
        [DisplayName(DisplayNames.Shader3TessEvaluation)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader3TessEvaluation
        {
            get => _Shader3TessEvaluation;
            set => Run(new SceneTessEvaluationShaderCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.Shader4Geometry)]
        [Description(Descriptions.Shader4Geometry)]
        [DisplayName(DisplayNames.Shader4Geometry)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader4Geometry
        {
            get => _Shader4Geometry;
            set => Run(new SceneGeometryShaderCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.Shader5Fragment)]
        [Description(Descriptions.Shader5Fragment)]
        [DisplayName(DisplayNames.Shader5Fragment)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader5Fragment
        {
            get => _Shader5Fragment;
            set => Run(new SceneFragmentShaderCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.Shader6Compute)]
        [Description(Descriptions.Shader6Compute)]
        [DisplayName(DisplayNames.Shader6Compute)]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader6Compute
        {
            get => _Shader6Compute;
            set => Run(new SceneComputeShaderCommand(value));
        }

        #endregion

        #endregion

        #region Public Methods

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Title)
            ? _Title
            : "New scene";

        #endregion

        #region Internal Properties

        internal CommandProcessor CommandProcessor => SceneController?.CommandProcessor;
        internal bool IsModified => CommandProcessor?.IsModified ?? false;
        internal SceneController SceneController;

        internal string _GPUCode;
        internal string _GPULog;
        internal GPUStatus _GPUStatus;

        [JsonProperty] internal ColourFormat _AccumColourFormat;
        [JsonProperty] internal Color _BackgroundColour;
        [JsonProperty] internal int _Buffers;
        [JsonProperty] internal Camera _Camera;
        [JsonProperty] internal ColourFormat _ColourFormat;
        [JsonProperty] internal int _Depth;
        [JsonProperty] internal double _FPS;
        [JsonProperty] internal Projection _Projection;
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
        [JsonProperty] internal bool _VSync;

        #endregion

        #region Internal Methods

        internal void AddTrace(Trace trace) => Traces.Add(trace);

        internal void AttachTraces()
        {
            foreach (var trace in Traces)
                trace.Init(this);
        }

        internal void Clear()
        {
            RestoreDefaults();
            OnPropertyChanged(this, string.Empty);
        }

        internal Matrix4 GetCameraView() => Maths.CreateCameraView(Camera);
        internal Matrix4 GetProjection() => Maths.CreateProjection(Projection, GLControl.ClientSize);

        internal string GetScript(ShaderType shaderType)
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

        internal void InsertTrace(int index, Trace trace) => Traces.Insert(index, trace);
        internal Trace NewTrace() => new Trace(this);

        internal void OnPropertyChanged(Scene scene, string propertyName) =>
            SceneController?.OnPropertyChanged(scene, propertyName);

        internal void OnPropertyChanged(Trace trace, string propertyName) =>
            SceneController?.OnPropertyChanged(trace, propertyName);

        internal void RemoveTrace(int index)
        {
            if (index >= 0 && index < Traces.Count)
                Traces.RemoveAt(index);
        }

        internal void SetScript(ShaderType shaderType, string script)
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

        internal void SetCameraView(Matrix4 _) { }
        internal void SetProjection(Matrix4 _) { }

        #endregion

        #region Private Classes

        private class Defaults
        {
            internal const string
                BackgroundColourString = "White",
                CameraString = "0, 0, 2, 0, 0, 0",
                ColourFormatString = "0, 0, 0, 0",
                GPUCode = "",
                GPULog = "",
                GPUStatusString = "OK",
                Shader1Vertex = @"/* Vertex Shader */

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
                Shader5Fragment = @"/* Fragment Shader */

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

            internal const double
                FPS = 60;

            internal GPUStatus
                GPUStatus = GPUStatus.OK;

            internal static Camera
                Camera = new Camera(0, 0, -2, 0, 0, 0);

            internal static Color
                BackgroundColour = Color.White;

            internal static ColourFormat
                ColourFormat = new ColourFormat(8),
                AccumColourFormat = new ColourFormat();

            internal static Projection
                Projection = new Projection(75, 16, 9, 0.1f, 1000);

            internal static List<Trace>
                Traces => new List<Trace>();
        }

        #endregion

        #region Private Properties

        private GLControl GLControl => SceneForm?.GLControl;
        private RenderController RenderController => SceneController.RenderController;
        private SceneForm SceneForm => SceneController?.SceneForm;

        #endregion

        #region Private Methods

        private void RestoreDefaults()
        {
            _AccumColourFormat = Defaults.AccumColourFormat;
            _BackgroundColour = Defaults.BackgroundColour;
            _Buffers = Defaults.Buffers;
            _Camera = Defaults.Camera;
            _ColourFormat = Defaults.ColourFormat;
            _Depth = Defaults.Depth;
            _FPS = Defaults.FPS;
            _GPUCode = Defaults.GPUCode;
            _GPULog = Defaults.GPULog;
            _Projection = Defaults.Projection;
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
            Traces = Defaults.Traces;
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
