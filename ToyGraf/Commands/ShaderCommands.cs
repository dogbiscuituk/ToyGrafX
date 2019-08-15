namespace ToyGraf.Commands
{
    using OpenTK.Graphics.OpenGL;

    internal static class ShaderNames
    {
        internal static string GetShaderName(this ShaderType shaderType)
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

    internal class SceneShaderCommand : ScenePropertyCommand<string>
    {
        internal SceneShaderCommand(ShaderType shaderType, string value)
            : base(shaderType.GetShaderName(), value,
                  s => s.GetScript(shaderType),
                  (s, v) => s.SetScript(shaderType, v))
        { }
    }

    internal class TraceShaderCommand : TracePropertyCommand<string>
    {
        internal TraceShaderCommand(int index, ShaderType shaderType, string value)
            : base(index, shaderType.GetShaderName(), value,
                  t => t.GetScript(shaderType),
                  (t, v) => t.SetScript(shaderType, v))
        { }
    }

    internal class SceneComputeShaderCommand : SceneShaderCommand
    {
        internal SceneComputeShaderCommand(string value) : base(ShaderType.ComputeShader, value) { }
    }

    internal class SceneFragmentShaderCommand : SceneShaderCommand
    {
        internal SceneFragmentShaderCommand(string value) : base(ShaderType.FragmentShader, value) { }
    }

    internal class SceneGeometryShaderCommand : SceneShaderCommand
    {
        internal SceneGeometryShaderCommand(string value) : base(ShaderType.GeometryShader, value) { }
    }

    internal class SceneTessControlShaderCommand : SceneShaderCommand
    {
        internal SceneTessControlShaderCommand(string value) : base(ShaderType.TessControlShader, value) { }
    }

    internal class SceneTessEvaluationShaderCommand : SceneShaderCommand
    {
        internal SceneTessEvaluationShaderCommand(string value) : base(ShaderType.TessEvaluationShader, value) { }
    }

    internal class SceneVertexShaderCommand : SceneShaderCommand
    {
        internal SceneVertexShaderCommand(string value) : base(ShaderType.VertexShader, value) { }
    }

    internal class TraceComputeShaderCommand : TraceShaderCommand
    {
        internal TraceComputeShaderCommand(int index, string value) : base(index, ShaderType.ComputeShader, value) { }
    }

    internal class TraceFragmentShaderCommand : TraceShaderCommand
    {
        internal TraceFragmentShaderCommand(int index, string value) : base(index, ShaderType.FragmentShader, value) { }
    }

    internal class TraceGeometryShaderCommand : TraceShaderCommand
    {
        internal TraceGeometryShaderCommand(int index, string value) : base(index, ShaderType.GeometryShader, value) { }
    }

    internal class TraceTessControlShaderCommand : TraceShaderCommand
    {
        internal TraceTessControlShaderCommand(int index, string value) : base(index, ShaderType.TessControlShader, value) { }
    }

    internal class TraceTessEvaluationShaderCommand : TraceShaderCommand
    {
        internal TraceTessEvaluationShaderCommand(int index, string value) : base(index, ShaderType.TessEvaluationShader, value) { }
    }

    internal class TraceVertexShaderCommand : TraceShaderCommand
    {
        internal TraceVertexShaderCommand(int index, string value) : base(index, ShaderType.VertexShader, value) { }
    }

}
