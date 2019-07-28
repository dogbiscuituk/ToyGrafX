namespace ToyGraf.Commands
{
    public class ShaderComputeCommand : TracePropertyCommand<string[]>
    {
        public ShaderComputeCommand(int index, string[] value) : base(index, "ShaderCompute",
            value, t => t._ShaderCompute, (t, v) => t._ShaderCompute = v)
        { }
    }

    public class ShaderFragmentCommand : TracePropertyCommand<string[]>
    {
        public ShaderFragmentCommand(int index, string[] value) : base(index, "ShaderFragment",
            value, t => t._ShaderFragment, (t, v) => t._ShaderFragment = v)
        { }
    }

    public class ShaderGeometryCommand : TracePropertyCommand<string[]>
    {
        public ShaderGeometryCommand(int index, string[] value) : base(index, "ShaderGeometry",
            value, t => t._ShaderGeometry, (t, v) => t._ShaderGeometry = v)
        { }
    }

    public class ShaderTessControlCommand : TracePropertyCommand<string[]>
    {
        public ShaderTessControlCommand(int index, string[] value) : base(index, "ShaderTessControl",
            value, t => t._ShaderTessControl, (t, v) => t._ShaderTessControl = v)
        { }
    }

    public class ShaderTessEvaluationCommand : TracePropertyCommand<string[]>
    {
        public ShaderTessEvaluationCommand(int index, string[] value) : base(index, "ShaderTessEvaluation",
            value, t => t._ShaderTessEvaluation, (t, v) => t._ShaderTessEvaluation = v)
        { }
    }

    public class ShaderVertexCommand : TracePropertyCommand<string[]>
    {
        public ShaderVertexCommand(int index, string[] value) : base(index, "ShaderVertex",
            value, t => t._ShaderVertex, (t, v) => t._ShaderVertex = v)
        { }
    }
}
