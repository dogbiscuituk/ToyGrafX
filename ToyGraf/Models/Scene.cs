﻿namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using Properties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Linq;
    using ToyGraf.Commands;
    using ToyGraf.Common.TypeConverters;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;
    using ToyGraf.Controllers;
    using ToyGraf.Controls;

    public class Scene
    {
        #region Constructors

        public Scene() => RestoreDefaults();

        internal Scene(SceneController sceneController) : this() => SceneController = sceneController;

        #endregion

        #region Public Properties

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
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string GPUCode => _GPUCode;

        [Category(Categories.SystemRO)]
        [DefaultValue(Defaults.GPULog)]
        [Description(Descriptions.GPULog)]
        [DisplayName(DisplayNames.GPULog)]
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
        [DefaultValue(typeof(Color), Defaults.BackgroundColourString)]
        [Description(Descriptions.BackgroundColour)]
        [DisplayName(DisplayNames.BackgroundColour)]
        [JsonIgnore]
        public Color BackgroundColour { get => _BackgroundColour; set => Run(new BackgroundColourCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(typeof(Vector3f), Defaults.CameraString)]
        [Description(Descriptions.Camera)]
        [DisplayName(DisplayNames.Camera)]
        [JsonIgnore]
        public Camera Camera { get => _Camera; set => Run(new CameraCommand(value)); }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.FPS)]
        [Description(Descriptions.FPS)]
        [DisplayName(DisplayNames.FPS)]
        [JsonIgnore]
        public double FPS { get => _FPS; set => Run(new FpsCommand(value)); }

        [Category(Categories.Scene)]
        [Description(Descriptions.GLMode)]
        [DisplayName(DisplayNames.GLMode)]
        public GLMode GLMode
        {
            get => SceneController?.GLMode;
            set => Run(new GLModeCommand(value));
        }

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
            get => Traces.Select(t => new Trace(t)).ToList();
            set => Traces = value;
        }

        // Used as a DataSource.DataMember, so public visibility required.
        [JsonProperty]
        public List<Trace> Traces { get; private set; }

        [Category(Categories.Scene)]
        [DefaultValue(Defaults.VSync)]
        [Description(Descriptions.VSync)]
        [DisplayName(DisplayNames.VSync)]
        [JsonIgnore]
        public bool VSync { get => _VSync; set => Run(new VSyncCommand(value)); }

        #endregion

        #region Shaders

        [Category(Categories.ShaderTemplates)]
        [DefaultValue(Defaults.GLTargetVersion)]
        [Description(Descriptions.GLTargetVersion)]
        [DisplayName(DisplayNames.GLTargetVersion)]
        [TypeConverter(typeof(GLSLVersionTypeConverter))]
        public string GLTargetVersion
        {
            get => _GLTargetVersion;
            set => Run(new GLTargetVersionCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [Description(Descriptions.Shader1Vertex)]
        [DisplayName(DisplayNames.Shader1Vertex)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
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
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
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
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
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
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader4Geometry
        {
            get => _Shader4Geometry;
            set => Run(new SceneGeometryShaderCommand(value));
        }

        [Category(Categories.ShaderTemplates)]
        [Description(Descriptions.Shader5Fragment)]
        [DisplayName(DisplayNames.Shader5Fragment)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
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
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
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

        [JsonProperty] internal Color _BackgroundColour;
        [JsonProperty] internal Camera _Camera;
        [JsonProperty] internal double _FPS;
        [JsonProperty] internal string _GLTargetVersion;
        [JsonProperty] internal Projection _Projection;
        [JsonProperty] internal string _Shader1Vertex;
        [JsonProperty] internal string _Shader2TessControl;
        [JsonProperty] internal string _Shader3TessEvaluation;
        [JsonProperty] internal string _Shader4Geometry;
        [JsonProperty] internal string _Shader5Fragment;
        [JsonProperty] internal string _Shader6Compute;
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
        internal GLMode GetGLMode() => SceneController?.GLMode;
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

        internal void SetGLMode(GLMode mode) => SceneController?.SetGLMode(mode);

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

        internal void CameraMoveBack() => CameraMoveFront(-1);
        internal void CameraMoveDown() => CameraMoveUp(-1);
        internal void CameraMoveForward() => CameraMoveFront(+1);
        internal void CameraMoveLeft() => CameraMoveRight(-1);
        internal void CameraMoveRight() => CameraMoveRight(+1);
        internal void CameraMoveUp() => CameraMoveUp(+1);
        internal void CameraRotateDown() => CameraRotateUp(-1);
        internal void CameraRotateLeft() => CameraRotateRight(-1);
        internal void CameraRotateRight() => CameraRotateRight(+1);
        internal void CameraRotateUp() => CameraRotateUp(+1);

        #endregion

        #region Private Classes

        public class Defaults
        {
            public const string
                BackgroundColourString = "White",
                CameraString = "0, 0, 2, 0, 0, 0",
                GLTargetVersion = "330",
                GPUCode = "",
                GPULog = "",
                GPUStatusString = "OK",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader6Compute = "",
                Title = "";

            public const bool
                VSync = false;

            public const double
                FPS = 60;

            public GPUStatus
                GPUStatus = GPUStatus.OK;

            public static Camera
                Camera = new Camera();

            public static Color
                BackgroundColour = Color.White;

            public static Projection
                Projection = new Projection(75, 16, 9, 0.1f, 1000);

            public static List<Trace>
                Traces => new List<Trace>();
        }

        #endregion

        #region Private Properties

        private const float
            CameraBump = 0.1f;

        private GLControl GLControl => SceneController?.GLControl;
        private RenderController RenderController => SceneController.RenderController;

        #endregion

        #region Private Methods

        private void CameraMove(Vector3f basis, float delta, bool strafe)
        {
            var shift = delta * CameraBump * basis;
            Camera = strafe
                ? new Camera(Camera.Position + shift, Camera.Focus + shift)
                : new Camera(Camera, "Position", Camera.Position + shift);
        }

        private void CameraMoveFront(int delta) => CameraMove(Camera.Ufront, delta, false);
        private void CameraMoveRight(int delta) => CameraMove(Camera.Uright, delta, true);
        private void CameraMoveUp(int delta) => CameraMove(Camera.Uup, delta, true);

        private void CameraRotate(Vector3f basis, float delta)
        {
            Vector3f
                f = Camera.Focus,
                p = Camera.Position - f,
                q = p + delta * CameraBump * basis;
            Camera = new Camera(q * p.Norm / q.Norm + f, f);
        }

        private void CameraRotateRight(int delta) => CameraRotate(Camera.Uright, delta);
        private void CameraRotateUp(int delta) => CameraRotate(Camera.Uup, delta);

        private void RestoreDefaults()
        {
            _BackgroundColour = Defaults.BackgroundColour;
            _Camera = Defaults.Camera;
            _FPS = Defaults.FPS;
            _GLTargetVersion = Defaults.GLTargetVersion;
            _GPUCode = Defaults.GPUCode;
            _GPULog = Defaults.GPULog;
            _Projection = Defaults.Projection;
            _Shader1Vertex = Resources.VertexHead;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Resources.FragmentHead;
            _Shader6Compute = Defaults.Shader6Compute;
            _Title = Defaults.Title;
            _VSync = Defaults.VSync;
            Traces = Defaults.Traces;
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
