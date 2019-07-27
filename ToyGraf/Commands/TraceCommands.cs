namespace ToyGraf.Commands
{
    using ToyGraf.Models;

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

    public class TraceVisibleCommand : TracePropertyCommand<bool>
    {
        public TraceVisibleCommand(int index, bool value) : base(index, "Visible",
            value, t => t._Visible, (t, v) => t._Visible = v)
        { }
    }

    public class TraceXmaxCommand : TracePropertyCommand<double>
    {
        public TraceXmaxCommand(int index, double value) : base(index, "Xmax",
            value, t => t._Xmax, (t, v) => t._Xmax = v)
        { }
    }

    public class TraceXminCommand : TracePropertyCommand<double>
    {
        public TraceXminCommand(int index, double value) : base(index, "Xmin",
            value, t => t._Xmin, (t, v) => t._Xmin = v)
        { }
    }

    public class TraceYmaxCommand : TracePropertyCommand<double>
    {
        public TraceYmaxCommand(int index, double value) : base(index, "Ymax",
            value, t => t._Ymax, (t, v) => t._Ymax = v)
        { }
    }

    public class TraceYminCommand : TracePropertyCommand<double>
    {
        public TraceYminCommand(int index, double value) : base(index, "Ymin",
            value, t => t._Ymin, (t, v) => t._Ymin = v)
        { }
    }

    public class TraceZmaxCommand : TracePropertyCommand<double>
    {
        public TraceZmaxCommand(int index, double value) : base(index, "Zmax",
            value, t => t._Zmax, (t, v) => t._Zmax = v)
        { }
    }

    public class TraceZminCommand : TracePropertyCommand<double>
    {
        public TraceZminCommand(int index, double value) : base(index, "Zmin",
            value, t => t._Zmin, (t, v) => t._Zmin = v)
        { }
    }
}
