namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using ToyGraf.Commands;
    using ToyGraf.Engine.Types;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models.Enums;

    [DefaultProperty("Shader1Vertex")]
    public class Trace
    {
        #region Public Interface

        public Trace() => RestoreDefaults();
        public Trace(Scene scene) : this() => Init(scene);

        public Trace Clone()
        {
            var trace = new Trace();
            trace.CopyFrom(this);
            return trace;
        }

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

        public override string ToString() =>
            !string.IsNullOrWhiteSpace(Title)
            ? _Title
            : Index >= 0
            ? $"Trace #{Index + 1}"
            : "New trace";

        #endregion

        #region Browsable Properties

        #region Placement

        [Category(Categories.Placement)]
        [DefaultValue(typeof(Point3F), Defaults.LocationString)]
        [Description("The location of the trace in world co-ordinates.")]
        [DisplayName("Location")]
        [JsonIgnore]
        public Point3F Location { get => _Location; set => Run(new LocationCommand(Index, value)); }

        [Category(Categories.Placement)]
        [DefaultValue(typeof(Euler3F), Defaults.OrientationString)]
        [Description("The orientation of the trace in world co-ordinates (in degrees).")]
        [DisplayName("Orientation°")]
        [JsonIgnore]
        public Euler3F Orientation { get => _Orientation; set => Run(new OrientationCommand(Index, value)); }

        [Category(Categories.Placement)]
        [DefaultValue(typeof(Point3F), Defaults.ScaleString)]
        [Description("The relative size of the trace.")]
        [DisplayName("Scale")]
        [JsonIgnore]
        public Point3F Scale
        {
            get => _Scale;
            set => Run(new ScaleCommand(Index, value));
        }

        [Category(Categories.Placement)]
        [DefaultValue(Defaults.Visible)]
        [Description("Take a wild guess.")]
        [DisplayName("Visible?")]
        [JsonIgnore]
        public YN Visible { get => _Visible; set => Run(new TraceVisibleCommand(Index, value)); }

        #endregion

        #region Read Only / System

        [Category(Categories.SystemRO)]
        [Description("The transformation matrix of the trace.")]
        [DisplayName("Transformation")]
        [JsonIgnore]
        public Matrix4 Transformation
        {
            get => GetTransformation();
            set => Run(new TransformationCommand(Index, value));
        }

        #endregion

        #region Shaders

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader1Vertex)]
        [Description(@"The vertex processor is a programmable unit that operates on incoming vertices and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called vertex shaders.
When a set of vertex shaders are successfully compiled and linked, they result in a vertex shader executable that runs on the vertex processor.
The vertex processor operates on one vertex at a time. It does not replace graphics operations that require knowledge of several vertices at a time.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader #1: Vertex (mandatory)")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader1Vertex
        {
            get => _Shader1Vertex;
            set => Run(new TraceVertexShaderCommand(Index, value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader2TessControl)]
        [Description(@"The tessellation control processor is a programmable unit that operates on a patch of incoming vertices and their associated data, emitting a new output patch. Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation control shaders.
When a set of tessellation control shaders are successfully compiled and linked, they result in a tessellation control shader executable that runs on the tessellation control processor.
The tessellation control shader is invoked for each vertex of the output patch. Each invocation can read the attributes of any vertex in the input or output patches, but can only write per-vertex attributes for the corresponding output patch vertex.
The shader invocations collectively produce a set of per-patch attributes for the output patch. After all tessellation control shader invocations have completed, the output vertices and per-patch attributes are assembled to form a patch to be used by subsequent pipeline stages.
Tessellation control shader invocations run mostly independently, with undefined relative execution order. However, the built-in function barrier() can be used to control execution order by synchronizing invocations, effectively dividing tessellation control shader execution into a set of phases.
Tessellation control shaders will get undefined results if one invocation reads a per-vertex or per-patch attribute written by another invocation at any point during the same phase, or if two invocations attempt to write different values to the same per-patch output in a single phase.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader #2: Tessellation Control")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader2TessControl
        {
            get => _Shader2TessControl;
            set => Run(new TraceTessControlShaderCommand(Index, value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader3TessEvaluation)]
        [Description(@"The tessellation evaluation processor is a programmable unit that evaluates the position and other attributes of a vertex generated by the tessellation primitive generator, using a patch of incoming vertices and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation evaluation shaders.
When a set of tessellation evaluation shaders are successfully compiled and linked, they result in a tessellation evaluation shader executable that runs on the tessellation evaluation processor.
Each invocation of the tessellation evaluation executable computes the position and attributes of a single vertex generated by the tessellation primitive generator.
The executable can read the attributes of any vertex in the input patch, plus the tessellation coordinate, which is the relative location of the vertex in the primitive being tessellated. The executable writes the position and other attributes of the vertex.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader #3: Tessellation Evaluation")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader3TessEvaluation
        {
            get => _Shader3TessEvaluation;
            set => Run(new TraceTessEvaluationShaderCommand(Index, value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader4Geometry)]
        [Description(@"The geometry processor is a programmable unit that operates on data for incoming vertices for a primitive assembled after vertex processing and outputs a sequence of vertices forming output primitives.
Compilation units written in the OpenGL Shading Language to run on this processor are called geometry shaders.
When a set of geometry shaders are successfully compiled and linked, they result in a geometry shader executable that runs on the geometry processor.
A single invocation of the geometry shader executable on the geometry processor will operate on a declared input primitive with a fixed number of vertices.
This single invocation can emit a variable number of vertices that are assembled into primitives of a declared output primitive type and passed to subsequent pipeline stages.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader #4: Geometry")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader4Geometry
        {
            get => _Shader4Geometry;
            set => Run(new TraceGeometryShaderCommand(Index, value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader5Fragment)]
        [Description(@"The fragment processor is a programmable unit that operates on fragment values and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called fragment shaders.
When a set of fragment shaders are successfully compiled and linked, they result in a fragment shader executable that runs on the fragment processor.
A fragment shader cannot change a fragment's (x, y) position. Access to neighboring fragments is not allowed.
The values computed by the fragment shader are ultimately used to update framebuffer memory or texture memory, depending on the current OpenGL state and the OpenGL command that caused the fragments to be generated.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader #5: Fragment (mandatory)")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader5Fragment
        {
            get => _Shader5Fragment;
            set => Run(new TraceFragmentShaderCommand(Index, value));
        }

        [Category(Categories.Shaders)]
        [DefaultValue(Defaults.Shader6Compute)]
        [Description(@"The compute processor is a programmable unit that operates independently from the other shader processors. Compilation units written in the OpenGL Shading Language to run on this processor are called compute shaders.
When a set of compute shaders are successfully compiled and linked, they result in a compute shader executable that runs on the compute processor.
A compute shader has access to many of the same resources as fragment and other shader processors, including textures, buffers, image variables, and atomic counters. It does not have any predefined inputs nor any fixed-function outputs.
It is not part of the graphics pipeline and its visible side effects are through changes to images, storage buffers, and atomic counters.
A compute shader operates on a group of work items called a work group. A work group is a collection of shader invocations that execute the same code, potentially in parallel.
An invocation within a work group may share data with other members of the same work group through shared variables and issue memory and control barriers to synchronize with other members of the same work group.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("Shader #6: Compute")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [JsonIgnore]
        public string Shader6Compute
        {
            get => _Shader6Compute;
            set => Run(new TraceComputeShaderCommand(Index, value));
        }

        #endregion

        #region Trace

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Point3F), Defaults.MaximumString)]
        [JsonIgnore]
        public Point3F Maximum { get => _Maximum; set => Run(new MaximumCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Point3F), Defaults.MinimumString)]
        [JsonIgnore]
        public Point3F Minimum { get => _Minimum; set => Run(new MinimumCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Pattern), Defaults.PatternString)]
        [Description("The pattern applied to the grid of computed points.")]
        [DisplayName("Pattern")]
        [JsonIgnore]
        public Pattern Pattern { get => _Pattern; set => Run(new PatternCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(typeof(Point3), Defaults.StripCountString)]
        [Description("The number of discrete strips into which the trace is divided along each axis.")]
        [DisplayName("Strip Count")]
        [JsonIgnore]
        public Point3 StripCount { get => _StripCount; set => Run(new StripCountCommand(Index, value)); }

        [Category(Categories.Trace)]
        [DefaultValue(Defaults.Title)]
        [Description("A title for this trace.")]
        [DisplayName("Title")]
        [JsonIgnore]
        public string Title { get => _Title; set => Run(new TraceTitleCommand(Index, value)); }

        #endregion

        #endregion

        #region Persistent Fields

        [JsonProperty] internal Point3F _Location;
        [JsonProperty] internal Point3F _Maximum;
        [JsonProperty] internal Point3F _Minimum;
        [JsonProperty] internal Euler3F _Orientation;
        [JsonProperty] internal Pattern _Pattern;
        [JsonProperty] internal Point3F _Scale;
        [JsonProperty] internal string _Shader1Vertex;
        [JsonProperty] internal string _Shader2TessControl;
        [JsonProperty] internal string _Shader3TessEvaluation;
        [JsonProperty] internal string _Shader4Geometry;
        [JsonProperty] internal string _Shader5Fragment;
        [JsonProperty] internal string _Shader6Compute;
        [JsonProperty] internal Point3 _StripCount;
        [JsonProperty] internal string _Title;
        [JsonProperty] internal YN _Visible;

        #endregion

        #region Internal Properties

        internal int Index
        {
            get => Scene?._Traces.IndexOf(this) ?? _Index;
            set => _Index = value;
        }

        internal Scene Scene;

        #endregion

        #region Private Properties

        private CommandProcessor CommandProcessor => Scene?.CommandProcessor;
        private int _Index;

        #endregion

        #region Internal Methods

        internal Matrix4 GetTransformation() => Maths.CreateTransformation(Location, Orientation, Scale);

        internal void Init(Scene scene)
        {
            Scene = scene;
        }

        internal void SetTransformation(Matrix4 transformation)
        {
            SetLocation(transformation.ExtractTranslation());
            SetOrientation(transformation.ExtractRotation());
            SetScale(transformation.ExtractScale());
        }

        #endregion

        #region Private Methods

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
            _Title = Defaults.Title;
            _Visible = Defaults.Visible;
        }

        private void Run(ITracePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        internal void SetLocation(Vector3 location) => Location = location.ToPoint3F();
        internal void SetOrientation(Vector3 orientation) => Orientation = orientation.ToEuler3F();
        internal void SetOrientation(Quaternion orientation) => Orientation = orientation.ToEuler3F();
        internal void SetScale(Vector3 scale) => Scale = scale.ToPoint3F();

        #endregion

        #region Default Shaders

        internal const string
            DefaultVertexShader = @"// Vertex Shader

#version 330 core

layout (location = 0) in vec3 position;
out vec3 colour;

uniform mat4 projectionMatrix;
uniform float timeValue;
uniform mat4 transformationMatrix;
uniform mat4 viewMatrix;

void main()
{
    float
        x = position.x,
        y = position.y,
        z = position.z,
        r = 0,
        g = 0,
        b = 0;

    z = sqrt(x * x + y * y);
    z = cos(20 * z - 10 * time) * exp(-3 * z);
    r = (x + 1) / 2;
    g = (y + 1) / 2;
    b = clamp(abs(5 * z), 0, 1);

    gl_Position = projectionMatrix * viewMatrix * transformationMatrix * vec4(x, y, z, 1.0);
    colour = vec3(r, g, b);
}",
            DefaultFragmentShader = @"// Fragment Shader

#version 330 core

in vec3 colour;
out vec4 FragColor;

void main()
{
    FragColor = vec4(colour, 0.1f);
}";

        #endregion

        #region Private Classes

        private class Categories
        {
            internal const string
                Placement = "Placement",
                Shaders = "Shaders",
                SystemRO = "Read Only / System",
                Trace = "Trace";
        }

        private class Defaults
        {
            internal const Pattern
                Pattern = Engine.Types.Pattern.TriangleStrip;

            internal const YN
                Visible = YN.Yes;

            internal const int
                Index = -1;

            internal static Euler3F
                Orientation = new Euler3F();

            internal static Point3
                StripCount = new Point3();

            internal static Point3F
                Location = new Point3F(),
                Maximum = new Point3F(),
                Minimum = new Point3F(),
                Scale = new Point3F(1, 1, 1);

            internal const string
                LocationString = "0, 0, 0",
                MaximumString = "0, 0, 0",
                MinimumString = "0, 0, 0",
                OrientationString = "0, 0, 0",
                PatternString = "TriangleStrip",
                ScaleString = "1, 1, 1",
                Shader1Vertex = "",
                Shader2TessControl = "",
                Shader3TessEvaluation = "",
                Shader4Geometry = "",
                Shader5Fragment = "",
                Shader6Compute = "",
                StripCountString = "0, 0, 0",
                Title = "";
        }

        #endregion
    }
}
