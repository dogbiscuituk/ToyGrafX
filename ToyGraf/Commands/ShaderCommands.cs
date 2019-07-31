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

    public class ComputeShaderCommand : ShaderCommand
    {
        public ComputeShaderCommand(int index, string[] value)
            : base(index, ShaderType.ComputeShader, value) { }
    }

    public class FragmentShaderCommand : ShaderCommand
    {
        public FragmentShaderCommand(int index, string[] value)
            : base(index, ShaderType.FragmentShader, value) { }
    }

    public class GeometryShaderCommand : ShaderCommand
    {
        public GeometryShaderCommand(int index, string[] value)
            : base(index, ShaderType.GeometryShader, value) { }
    }

    public class TessControlShaderCommand : ShaderCommand
    {
        public TessControlShaderCommand(int index, string[] value)
            : base(index, ShaderType.TessControlShader, value) { }
    }

    public class TessEvaluationShaderCommand : ShaderCommand
    {
        public TessEvaluationShaderCommand(int index, string[] value)
            : base(index, ShaderType.TessEvaluationShader, value) { }
    }

    public class VertexShaderCommand : ShaderCommand
    {
        public VertexShaderCommand(int index, string[] value)
            : base(index, ShaderType.VertexShader, value)
        { }
    }
}
