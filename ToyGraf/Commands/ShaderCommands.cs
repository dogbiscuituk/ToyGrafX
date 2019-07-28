namespace ToyGraf.Commands
{
    public class TraceShaderComputeCommand : TracePropertyCommand<string[]>
    {
        public TraceShaderComputeCommand(int index, string[] value) : base(index, "ShaderCompute",
            value, t => t._ShaderCompute, (t, v) => t._ShaderCompute = v)
        { }
    }

    public class TraceShaderFragmentCommand : TracePropertyCommand<string[]>
    {
        public TraceShaderFragmentCommand(int index, string[] value) : base(index, "ShaderFragment",
            value, t => t._ShaderFragment, (t, v) => t._ShaderFragment = v)
        { }
    }

    public class TraceShaderGeometryCommand : TracePropertyCommand<string[]>
    {
        public TraceShaderGeometryCommand(int index, string[] value) : base(index, "ShaderGeometry",
            value, t => t._ShaderGeometry, (t, v) => t._ShaderGeometry = v)
        { }
    }

    public class TraceShaderTessellationControlCommand : TracePropertyCommand<string[]>
    {
        public TraceShaderTessellationControlCommand(int index, string[] value) : base(index, "ShaderTessellationControl",
                value, t => t._ShaderTessellationControl, (t, v) => t._ShaderTessellationControl = v)
        { }
    }

    public class TraceShaderTessellationEvaluationCommand : TracePropertyCommand<string[]>
    {
        public TraceShaderTessellationEvaluationCommand(int index, string[] value) : base(index, "ShaderTessellationEvaluation",
                value, t => t._ShaderTessellationEvaluation, (t, v) => t._ShaderTessellationEvaluation = v)
        { }
    }

    public class TraceShaderVertexCommand : TracePropertyCommand<string[]>
    {
        public TraceShaderVertexCommand(int index, string[] value) : base(index, "ShaderVertex",
            value, t => t._ShaderVertex, (t, v) => t._ShaderVertex = v)
        { }
    }
}
