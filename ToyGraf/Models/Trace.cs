namespace ToyGraf.Models
{
    using Newtonsoft.Json;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;
    using System.Linq;
    using ToyGraf.Commands;
    using ToyGraf.Engine.Entities;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models.Enums;
    using ToyGraf.Shaders;

    [DefaultProperty("VertexShader")]
    public class Trace : ITrace, IEntity
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

        public string[] GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return _VertexShader;
                case ShaderType.TessControlShader:
                    return _TessControlShader;
                case ShaderType.TessEvaluationShader:
                    return _TessEvaluationShader;
                case ShaderType.GeometryShader:
                    return _GeometryShader;
                case ShaderType.FragmentShader:
                    return _FragmentShader;
                case ShaderType.ComputeShader:
                    return _ComputeShader;
            }
            return new string[0];
        }

        public void MoveBy(float dx, float dy, float dz) => Location += new Vector3(dx, dy, dz);
        public void MoveTo(float x, float y, float z) => Location += new Vector3(x, y, z);
        public void RotateBy(float dx, float dy, float dz) => Rotation += new Vector3(dx, dy, dz);
        public void RotateTo(float x, float y, float z) => Rotation += new Vector3(x, y, z);
        public void ScaleBy(float scale) => Scale *= scale;
        public void ScaleTo(float scale) => Scale = scale;

        public void SetScript(ShaderType shaderType, string[] script)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    _VertexShader = script;
                    break;
                case ShaderType.TessControlShader:
                    _TessControlShader = script;
                    break;
                case ShaderType.TessEvaluationShader:
                    _TessEvaluationShader = script;
                    break;
                case ShaderType.GeometryShader:
                    _GeometryShader = script;
                    break;
                case ShaderType.FragmentShader:
                    _FragmentShader = script;
                    break;
                case ShaderType.ComputeShader:
                    _ComputeShader = script;
                    break;
            }
            if (Shader != null)
                Shader.CreateProgram();
        }

        #endregion

        #region Editable Properties

        #region Domain & Range

        [Category("Domain && Range")]
        [DefaultValue(+1.0)]
        [JsonIgnore]
        public double Xmax { get => _Xmax; set => Run(new TraceXmaxCommand(Index, value)); }

        [Category("Domain && Range")]
        [DefaultValue(-1.0)]
        [JsonIgnore]
        public double Xmin { get => _Xmin; set => Run(new TraceXminCommand(Index, value)); }

        [Category("Domain && Range")]
        [DefaultValue(+1.0)]
        [JsonIgnore]
        public double Ymax { get => _Ymax; set => Run(new TraceYmaxCommand(Index, value)); }

        [Category("Domain && Range")]
        [DefaultValue(-1.0)]
        [JsonIgnore]
        public double Ymin { get => _Ymin; set => Run(new TraceYminCommand(Index, value)); }

        [Category("Domain && Range")]
        [DefaultValue(+1.0)]
        [JsonIgnore]
        public double Zmax { get => _Zmax; set => Run(new TraceZmaxCommand(Index, value)); }

        [Category("Domain && Range")]
        [DefaultValue(-1.0)]
        [JsonIgnore]
        public double Zmin { get => _Zmin; set => Run(new TraceZminCommand(Index, value)); }

        #endregion

        #region Placement

        [Browsable(false)]
        [Category("Placement")]
        [Description("The location of the trace in world co-ordinates.")]
        [DisplayName("Location")]
        [JsonIgnore]
        public Vector3 Location
        {
            get => GetLocation();
            set => Run(new EntityLocationCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(0f)]
        [Description("The X component of the trace location in world co-ordinates.")]
        [DisplayName("Location X")]
        [JsonIgnore]
        public float LocationX
        {
            get => _LocationX;
            set => Run(new EntityLocationXCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(0f)]
        [Description("The Y component of the trace location in world co-ordinates.")]
        [DisplayName("Location Y")]
        [JsonIgnore]
        public float LocationY
        {
            get => _LocationY;
            set => Run(new EntityLocationYCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(0f)]
        [Description("The Z component of the trace location in world co-ordinates.")]
        [DisplayName("Location Z")]
        [JsonIgnore]
        public float LocationZ
        {
            get => _LocationZ;
            set => Run(new EntityLocationZCommand(Index, value));
        }

        [Browsable(false)]
        [Category("Placement")]
        [Description("The rotation of the trace in world co-ordinates (in degrees).")]
        [DisplayName("Rotation°")]
        [JsonIgnore]
        public Vector3 Rotation
        {
            get => GetRotation();
            set => Run(new EntityRotationCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(0f)]
        [Description("The X component of the trace rotation in world co-ordinates (in degrees).")]
        [DisplayName("Rotation X°")]
        [JsonIgnore]
        public float RotationX
        {
            get => _RotationX;
            set => Run(new EntityRotationXCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(0f)]
        [Description("The Y component of the trace rotation in world co-ordinates (in degrees).")]
        [DisplayName("Rotation Y°")]
        [JsonIgnore]
        public float RotationY
        {
            get => _RotationY;
            set => Run(new EntityRotationYCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(0f)]
        [Description("The Z component of the trace rotation in world co-ordinates (in degrees).")]
        [DisplayName("Rotation Z°")]
        [JsonIgnore]
        public float RotationZ
        {
            get => _RotationZ;
            set => Run(new EntityRotationZCommand(Index, value));
        }

        [Category("Placement")]
        [DefaultValue(1f)]
        [Description("The relative size of the trace.")]
        [DisplayName("Scale")]
        [JsonIgnore]
        public float Scale
        {
            get => _Scale;
            set => Run(new EntityScaleCommand(Index, value));
        }

        #endregion

        #region Shaders

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description(@"The vertex processor is a programmable unit that operates on incoming vertices and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called vertex shaders.
When a set of vertex shaders are successfully compiled and linked, they result in a vertex shader executable that runs on the vertex processor.
The vertex processor operates on one vertex at a time. It does not replace graphics operations that require knowledge of several vertices at a time.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("1. Vertex Shader (mandatory)")]
        [JsonIgnore]
        public string[] VertexShader
        {
            get => _VertexShader;
            set => Run(new VertexShaderCommand(Index, value));
        }

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description(@"The tessellation control processor is a programmable unit that operates on a patch of incoming vertices and their associated data, emitting a new output patch. Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation control shaders.
When a set of tessellation control shaders are successfully compiled and linked, they result in a tessellation control shader executable that runs on the tessellation control processor.
The tessellation control shader is invoked for each vertex of the output patch. Each invocation can read the attributes of any vertex in the input or output patches, but can only write per-vertex attributes for the corresponding output patch vertex.
The shader invocations collectively produce a set of per-patch attributes for the output patch. After all tessellation control shader invocations have completed, the output vertices and per-patch attributes are assembled to form a patch to be used by subsequent pipeline stages.
Tessellation control shader invocations run mostly independently, with undefined relative execution order. However, the built-in function barrier() can be used to control execution order by synchronizing invocations, effectively dividing tessellation control shader execution into a set of phases.
Tessellation control shaders will get undefined results if one invocation reads a per-vertex or per-patch attribute written by another invocation at any point during the same phase, or if two invocations attempt to write different values to the same per-patch output in a single phase.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("2. Tessellation Control Shader")]
        [JsonIgnore]
        public string[] TessControlShader
        {
            get => _TessControlShader;
            set => Run(new TessControlShaderCommand(Index, value));
        }

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description(@"The tessellation evaluation processor is a programmable unit that evaluates the position and other attributes of a vertex generated by the tessellation primitive generator, using a patch of incoming vertices and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation evaluation shaders.
When a set of tessellation evaluation shaders are successfully compiled and linked, they result in a tessellation evaluation shader executable that runs on the tessellation evaluation processor.
Each invocation of the tessellation evaluation executable computes the position and attributes of a single vertex generated by the tessellation primitive generator.
The executable can read the attributes of any vertex in the input patch, plus the tessellation coordinate, which is the relative location of the vertex in the primitive being tessellated. The executable writes the position and other attributes of the vertex.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("3. Tessellation Evaluation Shader")]
        [JsonIgnore]
        public string[] TessEvaluationShader
        {
            get => _TessEvaluationShader;
            set => Run(new TessEvaluationShaderCommand(Index, value));
        }

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description(@"The geometry processor is a programmable unit that operates on data for incoming vertices for a primitive assembled after vertex processing and outputs a sequence of vertices forming output primitives.
Compilation units written in the OpenGL Shading Language to run on this processor are called geometry shaders.
When a set of geometry shaders are successfully compiled and linked, they result in a geometry shader executable that runs on the geometry processor.
A single invocation of the geometry shader executable on the geometry processor will operate on a declared input primitive with a fixed number of vertices.
This single invocation can emit a variable number of vertices that are assembled into primitives of a declared output primitive type and passed to subsequent pipeline stages.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("4. Geometry Shader")]
        [JsonIgnore]
        public string[] GeometryShader
        {
            get => _GeometryShader;
            set => Run(new GeometryShaderCommand(Index, value));
        }

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description(@"The fragment processor is a programmable unit that operates on fragment values and their associated data. Compilation units written in the OpenGL Shading Language to run on this processor are called fragment shaders.
When a set of fragment shaders are successfully compiled and linked, they result in a fragment shader executable that runs on the fragment processor.
A fragment shader cannot change a fragment's (x, y) position. Access to neighboring fragments is not allowed.
The values computed by the fragment shader are ultimately used to update framebuffer memory or texture memory, depending on the current OpenGL state and the OpenGL command that caused the fragments to be generated.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("5. Fragment Shader (mandatory)")]
        [JsonIgnore]
        public string[] FragmentShader
        {
            get => _FragmentShader;
            set => Run(new FragmentShaderCommand(Index, value));
        }

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description(@"The compute processor is a programmable unit that operates independently from the other shader processors. Compilation units written in the OpenGL Shading Language to run on this processor are called compute shaders.
When a set of compute shaders are successfully compiled and linked, they result in a compute shader executable that runs on the compute processor.
A compute shader has access to many of the same resources as fragment and other shader processors, including textures, buffers, image variables, and atomic counters. It does not have any predefined inputs nor any fixed-function outputs.
It is not part of the graphics pipeline and its visible side effects are through changes to images, storage buffers, and atomic counters.
A compute shader operates on a group of work items called a work group. A work group is a collection of shader invocations that execute the same code, potentially in parallel.
An invocation within a work group may share data with other members of the same work group through shared variables and issue memory and control barriers to synchronize with other members of the same work group.

Source: The OpenGL® Shading Language, Version 4.60.7. Copyright © 2008-2018 The Khronos Group Inc. All Rights Reserved. For more information, please refer to [Help|OpenGL® Shading Language].")]
        [DisplayName("6. Compute Shader")]
        [JsonIgnore]
        public string[] ComputeShader
        {
            get => _ComputeShader;
            set => Run(new ComputeShaderCommand(Index, value));
        }

        [Category("Shaders")]
        [DefaultValue(null)]
        [Description("The status of the most recent shader compilation action. An empty value indicates successful compilation.")]
        [DisplayName("Shader Status")]
        [JsonIgnore]
        public string[] ShaderStatus
        {
            get => _ShaderStatus;
            set => _ShaderStatus = value;
        }

        #endregion

        #region Terrain

        [Category("Terrain")]
        [DefaultValue(0)]
        [Description("The number of discrete strips into which the trace is divided in the X direction.")]
        [DisplayName("Strip Count X")]
        [JsonIgnore]
        public int StripCountX { get => _StripCountX; set => Run(new TerrainStripCountXCommand(Index, value)); }

        [Category("Terrain")]
        [DefaultValue(0)]
        [Description("The number of discrete strips into which the trace is divided in the Y direction.")]
        [DisplayName("Strip Count Y")]
        [JsonIgnore]
        public int StripCountY { get => _StripCountY; set => Run(new TerrainStripCountYCommand(Index, value)); }

        [Category("Terrain")]
        [DefaultValue(0)]
        [Description("The number of discrete strips into which the trace is divided in the Z direction.")]
        [DisplayName("Strip Count Z")]
        [JsonIgnore]
        public int StripCountZ { get => _StripCountZ; set => Run(new TerrainStripCountZCommand(Index, value)); }

        #endregion

        #region Trace

        [Category("Trace")]
        [DefaultValue(typeof(YN), "Yes")]
        [Description("Take a wild guess.")]
        [DisplayName("Visible?")]
        [JsonIgnore]
        public YN Visible { get => _Visible; set => Run(new TraceVisibleCommand(Index, value)); }

        #endregion

        #endregion

        #region Persistent Fields

        // Domain & Range
        [JsonProperty]
        internal double
            _Xmin,
            _Xmax,
            _Ymin,
            _Ymax,
            _Zmin,
            _Zmax;

        // Placement
        [JsonProperty]
        internal float
            _LocationX,
            _LocationY,
            _LocationZ,
            _RotationX,
            _RotationY,
            _RotationZ,
            _Scale;

        // Shaders
        [JsonProperty]
        internal string[]
            _VertexShader,
            _TessControlShader,
            _TessEvaluationShader,
            _GeometryShader,
            _FragmentShader,
            _ComputeShader,
            _ShaderStatus;

        // Terrain
        [JsonProperty]
        internal int
            _StripCountX,
            _StripCountY,
            _StripCountZ;

        // Trace
        [JsonProperty]
        internal YN
            _Visible;

        #endregion

        #region Non-Public Properties

        private ICommandProcessor CommandProcessor => Scene?.CommandProcessor;
        internal int Index => Scene?._Traces.IndexOf(this) ?? 0;

        internal Scene Scene;
        private TraceShader Shader;

        #endregion

        #region Non-Public Methods

        internal Vector3 GetLocation() => new Vector3(_LocationX, _LocationY, _LocationZ);
        internal Vector3 GetRotation() => new Vector3(_RotationX, _RotationY, _RotationZ);

        internal void Init(Scene scene)
        {
            Scene = scene;
            Shader = new TraceShader(this);
        }

        private void RestoreDefaults()
        {
            // Trace Domain & Range

            _Xmin = Defaults.Xmin;
            _Xmax = Defaults.Xmax;
            _Ymin = Defaults.Ymin;
            _Ymax = Defaults.Ymax;
            _Zmin = Defaults.Zmin;
            _Zmax = Defaults.Zmax;

            // Trace Placement

            _LocationX = Defaults.LocationX;
            _LocationY = Defaults.LocationY;
            _LocationZ = Defaults.LocationZ;
            _RotationX = Defaults.RotationX;
            _RotationY = Defaults.RotationY;
            _RotationZ = Defaults.RotationZ;
            _Scale = Defaults.Scale;

            // Trace Shaders

            VertexShader = Defaults.VertexShader;
            TessControlShader = Defaults.TessControlShader;
            TessEvaluationShader = Defaults.TessEvaluationShader;
            GeometryShader = Defaults.GeometryShader;
            FragmentShader = Defaults.FragmentShader;
            ComputeShader = Defaults.ComputeShader;
            ShaderStatus = Defaults.ShaderStatus;

            // Trace Terrain

            StripCountX = Defaults.StripCountX;
            StripCountY = Defaults.StripCountY;
            StripCountZ = Defaults.StripCountZ;

            // Trace Miscellaneous

            Visible = Defaults.Visible;
        }

        private void Run(ITracePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        internal void SetLocation(Vector3 location)
        {
            _LocationX = location.X;
            _LocationY = location.Y;
            _LocationZ = location.Z;
        }

        internal void SetRotation(Vector3 rotation)
        {
            _RotationX = rotation.X;
            _RotationY = rotation.Y;
            _RotationZ = rotation.Z;
        }

        #endregion

        #region Default Shaders

        internal const string
            DefaultVertexShader = @"// Vertex Shader

#version 330 core

layout (location = 0) in vec3 position;
layout (location = 1) in float time;
out vec3 colour;

uniform mat4 transformationMatrix;
uniform mat4 projectionMatrix;
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

        [JsonIgnore]
        public Prototype Prototype
        {
            get => GetPrototype();
            set { }
        }

        private Prototype GetPrototype()
        {
            int xc = StripCountX, yc = StripCountY;
            var vertices = Grids.GetVertexCoords(xc, yc).ToArray();
            var indices = Grids.GetTriangleIndices(xc, yc).ToArray();

            return new Prototype(vertices, indices);
        }
    }
}
