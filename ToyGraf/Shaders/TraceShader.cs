namespace ToyGraf.Shaders
{
    using OpenTK.Graphics.OpenGL;
    using System.Linq;
    using ToyGraf.Engine.Shaders;
    using ToyGraf.Models;

    public class TraceShader : Shader
    {
        public TraceShader(Trace trace) : base()
        {
            Trace = trace;
        }

        protected override void BindAttributes()
        {
            BindAttribute(0, "position");
            BindAttribute(1, "time");
        }

        protected override string GetShaderSource(ShaderType shaderType)
        {
            var source = GetShaderSourceStrings(shaderType);
            return source == null || source.Length < 1
                ? string.Empty
                : source.Aggregate((s, t) => $@"{s}\n{t}");
        }

        private string[] GetShaderSourceStrings(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.ComputeShader:
                    return Trace.ShaderCompute;
                case ShaderType.FragmentShader:
                    return Trace.ShaderFragment;
                case ShaderType.GeometryShader:
                    return Trace.ShaderGeometry;
                case ShaderType.TessControlShader:
                    return Trace.ShaderTessControl;
                case ShaderType.TessEvaluationShader:
                    return Trace.ShaderTessEvaluation;
                case ShaderType.VertexShader:
                    return Trace.ShaderVertex;
            }
            return null;
        }

        private readonly Trace Trace;
    }
}
