﻿namespace ToyGraf.Models
{
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;
    using ToyGraf.Commands;
    using ToyGraf.Shaders;

    public class Trace
    {
        #region Public Interface

        public Trace()
        {
            Shader = new TraceShader(this);
        }

        public Trace(Scene scene) : this() => Scene = scene;

        public string[] GetScript(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return _ShaderVertex;
                case ShaderType.TessControlShader:
                    return _ShaderTessControl;
                case ShaderType.TessEvaluationShader:
                    return _ShaderTessEvaluation;
                case ShaderType.GeometryShader:
                    return _ShaderGeometry;
                case ShaderType.FragmentShader:
                    return _ShaderFragment;
                case ShaderType.ComputeShader:
                    return _ShaderCompute;
            }
            return new string[0];
        }

        public void SetScript(ShaderType shaderType, string[] script)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    _ShaderVertex = script;
                    break;
                case ShaderType.TessControlShader:
                    _ShaderTessControl = script;
                    break;
                case ShaderType.TessEvaluationShader:
                    _ShaderTessEvaluation = script;
                    break;
                case ShaderType.GeometryShader:
                    _ShaderGeometry = script;
                    break;
                case ShaderType.FragmentShader:
                    _ShaderFragment = script;
                    break;
                case ShaderType.ComputeShader:
                    _ShaderCompute = script;
                    break;
            }
            Shader.CreateProgram();
        }

        #endregion

        #region Persistent Properties

        [Category("Shaders")]
        [Description(@"The vertex processor is a programmable unit that operates on incoming vertices and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called vertex shaders.
When a set of vertex shaders are successfully compiled and linked, they result in a vertex shader executable that runs on the vertex processor.
The vertex processor operates on one vertex at a time.
It does not replace graphics operations that require knowledge of several vertices at a time.
Please refer to [Help|OpenGL® Shading Language] for more information.")]
        [DisplayName("1. Vertex Shader")]
        public string[] ShaderVertex
        {
            get => _ShaderVertex;
            set => Run(new ShaderVertexCommand(Index, value));
        }

        [Category("Shaders")]
        [Description(@"The tessellation control processor is a programmable unit that operates on a patch of incoming vertices and their associated data, emitting a new output patch.
Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation control shaders.
When a set of tessellation control shaders are successfully compiled and linked, they result in a tessellation control shader executable that runs on the tessellation control processor.
The tessellation control shader is invoked for each vertex of the output patch.
Each invocation can read the attributes of any vertex in the input or output patches, but can only write per-vertex attributes for the corresponding output patch vertex.
The shader invocations collectively produce a set of per-patch attributes for the output patch.
After all tessellation control shader invocations have completed, the output vertices and per-patch attributes are assembled to form a patch to be used by subsequent pipeline stages.
Tessellation control shader invocations run mostly independently, with undefined relative execution order.
However, the built-in function barrier() can be used to control execution order by synchronizing invocations, effectively dividing tessellation control shader execution into a set of phases.
Tessellation control shaders will get undefined results if one invocation reads a per-vertex or per-patch attribute written by another invocation at any point during the same phase, or if two invocations attempt to write different values to the same per-patch output in a single phase.
Please refer to [Help|OpenGL® Shading Language] for more information.")]
        [DisplayName("2. Tessellation Control Shader")]
        public string[] ShaderTessControl
        {
            get => _ShaderTessControl;
            set => Run(new ShaderTessControlCommand(Index, value));
        }

        [Category("Shaders")]
        [Description(@"The tessellation evaluation processor is a programmable unit that evaluates the position and other attributes of a vertex generated by the tessellation primitive generator, using a patch of incoming vertices and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called tessellation evaluation shaders.
When a set of tessellation evaluation shaders are successfully compiled and linked, they result in a tessellation evaluation shader executable that runs on the tessellation evaluation processor.
Each invocation of the tessellation evaluation executable computes the position and attributes of a single vertex generated by the tessellation primitive generator.
The executable can read the attributes of any vertex in the input patch, plus the tessellation coordinate, which is the relative location of the vertex in the primitive being tessellated.
The executable writes the position and other attributes of the vertex.
Please refer to [Help|OpenGL® Shading Language] for more information.")]
        [DisplayName("3. Tessellation Evaluation Shader")]
        public string[] ShaderTessEvaluation
        {
            get => _ShaderTessEvaluation;
            set => Run(new ShaderTessEvaluationCommand(Index, value));
        }

        [Category("Shaders")]
        [Description(@"The geometry processor is a programmable unit that operates on data for incoming vertices for a primitive assembled after vertex processing and outputs a sequence of vertices forming output primitives.
Compilation units written in the OpenGL Shading Language to run on this processor are called geometry shaders.
When a set of geometry shaders are successfully compiled and linked, they result in a geometry shader executable that runs on the geometry processor.
A single invocation of the geometry shader executable on the geometry processor will operate on a declared input primitive with a fixed number of vertices.
This single invocation can emit a variable number of vertices that are assembled into primitives of a declared output primitive type and passed to subsequent pipeline stages.
Please refer to [Help|OpenGL® Shading Language] for more information.")]
        [DisplayName("4. Geometry Shader")]
        public string[] ShaderGeometry
        {
            get => _ShaderGeometry;
            set => Run(new ShaderGeometryCommand(Index, value));
        }

        [Category("Shaders")]
        [Description(@"The fragment processor is a programmable unit that operates on fragment values and their associated data.
Compilation units written in the OpenGL Shading Language to run on this processor are called fragment shaders.
When a set of fragment shaders are successfully compiled and linked, they result in a fragment shader executable that runs on the fragment processor.
A fragment shader cannot change a fragment's (x, y) position.
Access to neighboring fragments is not allowed.
The values computed by the fragment shader are ultimately used to update framebuffer memory or texture memory, depending on the current OpenGL state and the OpenGL command that caused the fragments to be generated.
Please refer to [Help|OpenGL® Shading Language] for more information.")]
        [DisplayName("5. Fragment Shader")]
        public string[] ShaderFragment
        {
            get => _ShaderFragment;
            set => Run(new ShaderFragmentCommand(Index, value));
        }

        [Category("Shaders")]
        [Description(@"The compute processor is a programmable unit that operates independently from the other shader processors.
Compilation units written in the OpenGL Shading Language to run on this processor are called compute shaders.
When a set of compute shaders are successfully compiled and linked, they result in a compute shader executable that runs on the compute processor.
A compute shader has access to many of the same resources as fragment and other shader processors, including textures, buffers, image variables, and atomic counters.
It does not have any predefined inputs nor any fixed-function outputs.
It is not part of the graphics pipeline and its visible side effects are through changes to images, storage buffers, and atomic counters.
A compute shader operates on a group of work items called a work group.
A work group is a collection of shader invocations that execute the same code, potentially in parallel.
An invocation within a work group may share data with other members of the same work group through shared variables and issue memory and control barriers to synchronize with other members of the same work group.
Please refer to [Help|OpenGL® Shading Language] for more information.")]
        [DisplayName("6. Compute Shader")]
        public string[] ShaderCompute
        {
            get => _ShaderCompute;
            set => Run(new ShaderComputeCommand(Index, value));
        }

        [Category("Shaders")]
        [Description("The status of the most recent shader compilation action. An empty value indicates successful compilation.")]
        [DisplayName("Shader Status")]
        public string[] ShaderStatus
        {
            get => _ShaderStatus;
        }

        [Category("Domain && Range")]
        public double Xmax { get => _Xmax; set => Run(new TraceXmaxCommand(Index, value)); }

        [Category("Domain && Range")]
        public double Xmin { get => _Xmin; set => Run(new TraceXminCommand(Index, value)); }

        [Category("Domain && Range")]
        public double Ymax { get => _Ymax; set => Run(new TraceYmaxCommand(Index, value)); }

        [Category("Domain && Range")]
        public double Ymin { get => _Ymin; set => Run(new TraceYminCommand(Index, value)); }

        [Category("Domain && Range")]
        public double Zmax { get => _Zmax; set => Run(new TraceZmaxCommand(Index, value)); }

        [Category("Domain && Range")]
        public double Zmin { get => _Zmin; set => Run(new TraceZminCommand(Index, value)); }

        [Category("Trace")]
        [Description("Take a wild guess.")]
        public bool Visible { get => _Visible; set => Run(new TraceVisibleCommand(Index, value)); }

        #endregion

        #region Private Properties

        internal bool _Visible;
        internal double _Xmax, _Xmin, _Ymax, _Ymin, _Zmax, _Zmin;
        internal string[]
            _ShaderVertex,
            _ShaderTessControl,
            _ShaderTessEvaluation,
            _ShaderGeometry,
            _ShaderFragment,
            _ShaderCompute,
            _ShaderStatus;

        private ICommandProcessor CommandProcessor => Scene?.CommandProcessor;
        private int Index => Scene?._Traces.IndexOf(this) ?? 0;
        internal Scene Scene;
        private TraceShader Shader;

        #endregion

        #region Default Shaders

        internal const string
            DefaultShaderVertex = @"// Vertex Shader

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
            DefaultShaderFragment = @"// Fragment Shader

#version 330 core

in vec3 colour;
out vec4 FragColor;

void main()
{
    FragColor = vec4(colour, 0.1f);
}";

        #endregion

        #region Private Methods

        private void Run(ITracePropertyCommand command)
        {
            if (CommandProcessor != null)
                CommandProcessor.Run(command);
            else
                command.RunOn(this);
        }

        #endregion
    }
}
