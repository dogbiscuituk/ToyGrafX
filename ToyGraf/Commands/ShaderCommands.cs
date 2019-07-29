namespace ToyGraf.Commands
{
    using OpenTK.Graphics.OpenGL;

    public class ShaderCommand : TracePropertyCommand<string[]>
    {
        public ShaderCommand(int index, ShaderType shaderType, string[] value)
            : base(index, GetShaderName(shaderType), value,
                  t => t.GetScript(shaderType),
                  (t, v) => t.SetScript(shaderType, value))
        { }

        private static string GetShaderName(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.ComputeShader:
                    return "Compute Shader";
                case ShaderType.FragmentShader:
                    return "Fragment Shader";
                case ShaderType.GeometryShader:
                    return "Geometry Shader";
                case ShaderType.TessControlShader:
                    return "Tessellation Control Shader";
                case ShaderType.TessEvaluationShader:
                    return "Tessellation Evaluation Shader";
                case ShaderType.VertexShader:
                    return "Vertex Shader";
            }
            return string.Empty;
        }
    }

    public class ShaderComputeCommand : ShaderCommand
    {
        public ShaderComputeCommand(int index, string[] value)
            : base(index, ShaderType.ComputeShader, value) { }
    }

    public class ShaderFragmentCommand : ShaderCommand
    {
        public ShaderFragmentCommand(int index, string[] value)
            : base(index, ShaderType.FragmentShader, value) { }
    }

    public class ShaderGeometryCommand : ShaderCommand
    {
        public ShaderGeometryCommand(int index, string[] value)
            : base(index, ShaderType.GeometryShader, value) { }
    }

    public class ShaderTessControlCommand : ShaderCommand
    {
        public ShaderTessControlCommand(int index, string[] value)
            : base(index, ShaderType.TessControlShader, value) { }
    }

    public class ShaderTessEvaluationCommand : ShaderCommand
    {
        public ShaderTessEvaluationCommand(int index, string[] value)
            : base(index, ShaderType.TessEvaluationShader, value) { }
    }

    public class ShaderVertexCommand : ShaderCommand
    {
        public ShaderVertexCommand(int index, string[] value)
            : base(index, ShaderType.VertexShader, value)
        { }
    }
}
