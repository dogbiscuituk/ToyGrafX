namespace ToyGraf.Commands
{
    using OpenTK.Graphics.OpenGL;

    internal class ShaderCommand : TracePropertyCommand<string>
    {
        internal ShaderCommand(int index, ShaderType shaderType, string value)
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

    internal class ComputeShaderCommand : ShaderCommand
    {
        internal ComputeShaderCommand(int index, string value) : base(index, ShaderType.ComputeShader, value) { }
    }

    internal class FragmentShaderCommand : ShaderCommand
    {
        internal FragmentShaderCommand(int index, string value) : base(index, ShaderType.FragmentShader, value) { }
    }

    internal class GeometryShaderCommand : ShaderCommand
    {
        internal GeometryShaderCommand(int index, string value) : base(index, ShaderType.GeometryShader, value) { }
    }

    internal class TessControlShaderCommand : ShaderCommand
    {
        internal TessControlShaderCommand(int index, string value) : base(index, ShaderType.TessControlShader, value) { }
    }

    internal class TessEvaluationShaderCommand : ShaderCommand
    {
        internal TessEvaluationShaderCommand(int index, string value) : base(index, ShaderType.TessEvaluationShader, value) { }
    }

    internal class VertexShaderCommand : ShaderCommand
    {
        internal VertexShaderCommand(int index, string value) : base(index, ShaderType.VertexShader, value) { }
    }
}
