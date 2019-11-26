namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;
    using System.Drawing.Design;
    using ToyGraf.Commands;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;
    using ToyGraf.Controllers;

    public class Trace
    {
        #region Constructors

        public Trace() => RestoreDefaults();
        public Trace(Scene scene) : this() => Init(scene);
        public Trace(Trace trace) : this() => CopyFrom(trace);

        #endregion

        #region Public Properties

        #region Placement

        [Category(Categories.Placement)]
        [DefaultValue(typeof(Vector3f), Defaults.LocationString)]
        [Description(Descriptions.Location)]
        [DisplayName(DisplayNames.Location)]
        [JsonIgnore]
        public Vector3f Location { get => _Location; set => Run(new LocationCommand(Index, value)); }

        [Category(Categories.Placement)]
        [DefaultValue(typeof(Euler3f), Defaults.OrientationString)]
        [Description(Descriptions.Orientation)]
        [DisplayName(DisplayNames.Orientation)]
        [JsonIgnore]
        public Euler3f Orientation { get => _Orientation; set => Run(new OrientationCommand(Index, value)); }

        [Category(Categories.Placement)]
        [DefaultValue(typeof(Vector3f), Defaults.ScaleString)]
        [Description(Descriptions.Scale)]
        [DisplayName(DisplayNames.Scale)]
        [JsonIgnore]
        public Vector3f Scale
        {
            get => _Scale;
            set => Run(new ScaleCommand(Index, value));
        }

        [Category(Categories.Placement)]
        [DefaultValue(Defaults.Visible)]
        [Description(Descriptions.Visible)]
        [DisplayName(DisplayNames.Visible)]
        [JsonIgnore]
        public bool Visible { get => _Visible; set => Run(new VisibleCommand(Index, value)); }

        #endregion

        #region Read Only / System

        [Category(Categories.SystemRO)]
        [Description(Descriptions.Transform)]
        [DisplayName(DisplayNames.Transform)]
        [JsonIgnore]
        public Matrix4 Transform
        {
            get => GetTransform();
            set => Run(new TransformCommand(Index, value));
        }

        [Category(Categories.SystemRO)]
        [Description(Descriptions.VaoID)]
        [DisplayName(DisplayNames.VaoID)]
        [JsonIgnore]
        public int VaoID => _VaoID;

        [Category(Categories.SystemRO)]
        [Description(Descriptions.VaoVertexCount)]
        [DisplayName(DisplayNames.VaoVertexCount)]
        [JsonIgnore]
        public int VaoVertexCount => _VaoVertexCount;

        [Category(Categories.SystemRO)]
        [Description(Descriptions.VboIndexID)]
        [DisplayName(DisplayNames.VboIndexID)]
        [JsonIgnore]
        public int VboIndexID => _VboIndexID;

        [Category(Categories.SystemRO)]
        [Description(Descriptions.VboVertexID)]
        [DisplayName(DisplayNames.VboVertexID)]
        [JsonIgnore]
        public int VboVertexID => _VboVertexID;

        #endregion

        #region Shaders

        [Category(Categories.ShaderCode)]
        [DefaultValue(Defaults.Shader1Vertex)]
        [Description(Descriptions.Shader1Vertex)]
        [DisplayName(DisplayNames.Shader1Vertex)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader1Vertex
        {
            get => _Shader1Vertex;
            set => Run(new TraceVertexShaderCommand(Index, value));
        }

        [Category(Categories.ShaderCode)]
        [DefaultValue(Defaults.Shader2TessControl)]
        [Description(Descriptions.Shader2TessControl)]
        [DisplayName(DisplayNames.Shader2TessControl)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader2TessControl
        {
            get => _Shader2TessControl;
            set => Run(new TraceTessControlShaderCommand(Index, value));
        }

        [Category(Categories.ShaderCode)]
        [DefaultValue(Defaults.Shader3TessEvaluation)]
        [Description(Descriptions.Shader3TessEvaluation)]
        [DisplayName(DisplayNames.Shader3TessEvaluation)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader3TessEvaluation
        {
            get => _Shader3TessEvaluation;
            set => Run(new TraceTessEvaluationShaderCommand(Index, value));
        }

        [Category(Categories.ShaderCode)]
        [DefaultValue(Defaults.Shader4Geometry)]
        [Description(Descriptions.Shader4Geometry)]
        [DisplayName(DisplayNames.Shader4Geometry)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader4Geometry
        {
            get => _Shader4Geometry;
            set => Run(new TraceGeometryShaderCommand(Index, value));
        }

        [Category(Categories.ShaderCode)]
        [DefaultValue(Defaults.Shader5Fragment)]
        [Description(Descriptions.Shader5Fragment)]
        [DisplayName(DisplayNames.Shader5Fragment)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader5Fragment
        {
            get => _Shader5Fragment;
            set => Run(new TraceFragmentShaderCommand(Index, value));
        }

        [Category(Categories.ShaderCode)]
        [DefaultValue(Defaults.Shader6Compute)]
        [Description(Descriptions.Shader6Compute)]
        [DisplayName(DisplayNames.Shader6Compute)]
        [Editor(typeof(ShaderEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader6Compute
        {
            get => _Shader6Compute;
            set => Run(new TraceComputeShaderCommand(Index, value));
        }

        #endregion

        #region Trace

        [Category(Categories.Trace)]
        [DefaultValue(Defaults.Description)]
        [Description(Descriptions.Description)]
        [DisplayName(DisplayNames.Description)]
        [JsonIgnore]
        public string Description { get => _Description; set => Run(new DescriptionCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Vector3f), Defaults.MaximumString)]
        [Description(Descriptions.Maximum)]
        [DisplayName(DisplayNames.Maximum)]
        [JsonIgnore]
        public Vector3f Maximum { get => _Maximum; set => Run(new MaximumCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Vector3f), Defaults.MinimumString)]
        [Description(Descriptions.Minimum)]
        [DisplayName(DisplayNames.Minimum)]
        [JsonIgnore]
        public Vector3f Minimum { get => _Minimum; set => Run(new MinimumCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Pattern), Defaults.PatternString)]
        [Description(Descriptions.Pattern)]
        [DisplayName(DisplayNames.Pattern)]
        [JsonIgnore]
        public Pattern Pattern
        {
            get => _Pattern;
            set
            {
                if (Run(new PatternCommand(Index, value)))
                    Invalidate();
            }
        }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Vector3i), Defaults.StripCountString)]
        [Description(Descriptions.StripCount)]
        [DisplayName(DisplayNames.StripCount)]
        [JsonIgnore]
        public Vector3i StripCount
        {
            get => _StripCount;
            set
            {
                if (Run(new StripCountCommand(Index, value)))
                    Invalidate();
            }
        }

        #endregion

        #endregion

        #region Public Methods

        public void CopyFrom(Trace trace)
        {
            _Description = trace.Description;
            _Index = trace.Index;
            _Location = new Vector3f(trace.Location);
            _Maximum = new Vector3f(trace.Maximum);
            _Minimum = new Vector3f(trace.Minimum);
            _Orientation = new Euler3f(trace.Orientation);
            _Pattern = trace.Pattern;
            _Scale = new Vector3f(trace.Scale);
            _Shader1Vertex = trace.Shader1Vertex;
            _Shader2TessControl = trace.Shader2TessControl;
            _Shader3TessEvaluation = trace.Shader3TessEvaluation;
            _Shader4Geometry = trace.Shader4Geometry;
            _Shader5Fragment = trace.Shader5Fragment;
            _Shader6Compute = trace.Shader6Compute;
            _StripCount = new Vector3i(trace.StripCount);
            _Visible = trace.Visible;
        }

        public void CopyTo(Trace trace) => trace.CopyFrom(this);

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Description)
            ? _Description
            : Index >= 0
            ? $"Trace #{Index + 1}"
            : "New trace";

        #endregion

        #region Persistent Fields

        [JsonProperty] internal string _Description;
        [JsonProperty] internal Vector3f _Location;
        [JsonProperty] internal Vector3f _Maximum;
        [JsonProperty] internal Vector3f _Minimum;
        [JsonProperty] internal Euler3f _Orientation;
        [JsonProperty] internal Pattern _Pattern;
        [JsonProperty] internal Vector3f _Scale;
        [JsonProperty] internal string _Shader1Vertex;
        [JsonProperty] internal string _Shader2TessControl;
        [JsonProperty] internal string _Shader3TessEvaluation;
        [JsonProperty] internal string _Shader4Geometry;
        [JsonProperty] internal string _Shader5Fragment;
        [JsonProperty] internal string _Shader6Compute;
        [JsonProperty] internal Vector3i _StripCount;
        [JsonProperty] internal bool _Visible;

        #endregion

        #region Internal Properties

        internal int Index
        {
            get => Scene?.Traces.IndexOf(this) ?? _Index;
            set => _Index = value;
        }

        internal Scene Scene;

        internal int
            _VaoID,
            _VaoVertexCount,
            _VboVertexID,
            _VboIndexID;

        internal bool _VaoValid;

        #endregion

        #region Internal Methods

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

        internal Matrix4 GetTransform() => Maths.CreateTransformation(Location, Orientation, Scale);

        internal void Init(Scene scene)
        {
            Scene = scene;
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

        internal void SetTransform(Matrix4 transform)
        {
            SetLocation(transform.ExtractTranslation());
            SetOrientation(transform.ExtractRotation());
            SetScale(transform.ExtractScale());
        }

        #endregion

        #region Private Classes

        public class Defaults
        {
            public const Pattern
                Pattern = Common.Types.Pattern.Fill;

            public const bool
                Visible = true;

            public const int
                Index = -1;

            public static Euler3f
                Orientation = new Euler3f();

            public static Vector3i
                StripCount = new Vector3i(100, 100, 0);

            public static Vector3f
                Location = new Vector3f(),
                Maximum = new Vector3f(),
                Minimum = new Vector3f(),
                Scale = new Vector3f(1, 1, 1);

            public const string
                Description = "",
                Shader1Vertex = @"   t = timeValue;
   x = position.x;
   y = position.y;
   z = sqrt(x * x + y * y);
   z = cos(20 * z - 10 * t) * exp(-3 * z);
   r = (x + 1) / 2;
   g = (y + 1) / 2;
   b = clamp(abs(5 * z), 0, 1);
   gl_Position = projection * cameraView * transform * vec4(x, y, z, 1.0);
   colour = vec3(r, g, b);",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader5Fragment = "   FragColor = vec4(colour, 0.1f);",
                Shader6Compute = "";

            internal const string
                LocationString = "0, 0, 0",
                MaximumString = "0, 0, 0",
                MinimumString = "0, 0, 0",
                OrientationString = "0, 0, 0",
                PatternString = "TriangleStrip",
                ScaleString = "1, 1, 1",
                StripCountString = "100, 100, 0";
        }

        #endregion

        #region Private Properties

        private CommandProcessor CommandProcessor => Scene?.CommandProcessor;
        private int _Index;
        private RenderController RenderController => SceneController?.RenderController;
        private SceneController SceneController => Scene?.SceneController;

        #endregion

        #region Private Methods

        private void Invalidate() => RenderController?.InvalidateTrace(this);

        private void RestoreDefaults()
        {
            _Index = Defaults.Index;
            _Location = Defaults.Location;
            _Maximum = Defaults.Maximum;
            _Minimum = Defaults.Maximum;
            _Orientation = Defaults.Orientation;
            _Pattern = Defaults.Pattern;
            _Scale = Defaults.Scale;
            _Shader1Vertex = Defaults.Shader1Vertex;
            _Shader2TessControl = Defaults.Shader2TessControl;
            _Shader3TessEvaluation = Defaults.Shader3TessEvaluation;
            _Shader4Geometry = Defaults.Shader4Geometry;
            _Shader5Fragment = Defaults.Shader5Fragment;
            _Shader6Compute = Defaults.Shader6Compute;
            _StripCount = Defaults.StripCount;
            _Description = Defaults.Description;
            _Visible = Defaults.Visible;
        }

        private bool Run(ITracePropertyCommand command) =>
            CommandProcessor != null ? CommandProcessor.Run(command) : command.RunOn(this);

        internal void SetLocation(Vector3 location) => Location = location;

        internal void SetOrientation(Vector3 orientation) => Orientation = orientation;

        internal void SetOrientation(Quaternion orientation) => Orientation = orientation;

        internal void SetScale(Vector3 scale) => Scale = scale;

        #endregion
    }
}
