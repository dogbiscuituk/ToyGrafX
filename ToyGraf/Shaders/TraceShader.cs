namespace ToyGraf.Shaders
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Linq;
    using System.Text;
    using ToyGraf.Engine.Shaders;
    using ToyGraf.Engine.Utility;
    using ToyGraf.Models;

    public class TraceShader : Shader
    {
        public TraceShader(Trace trace) : base()
        {
            Trace = trace;
        }

        private StringBuilder ShaderLog = new StringBuilder();

        public override void CreateProgram()
        {
            ShaderLog.Clear();
            VertexShaderID = CreateShader(ShaderType.VertexShader);
            TessControlShaderID = CreateShader(ShaderType.TessControlShader);
            TessEvaluationShaderID = CreateShader(ShaderType.TessEvaluationShader);
            GeometryShaderID = CreateShader(ShaderType.GeometryShader);
            FragmentShaderID = CreateShader(ShaderType.FragmentShader);
            ComputeShaderID = CreateShader(ShaderType.ComputeShader);

            Trace._ShaderStatus = ShaderLog.ToString().ToStringArray(StringSplitOptions.RemoveEmptyEntries);
        }

        protected override int CreateShader(ShaderType shaderType)
        {
            var shaderSource = GetScript(shaderType);
            if (string.IsNullOrWhiteSpace(shaderSource))
                return 0;
            var shaderID = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderID, shaderSource);
            GL.CompileShader(shaderID);
            var shaderLog = GL.GetShaderInfoLog(shaderID);
            if (!string.IsNullOrWhiteSpace(shaderLog))
            {
                ShaderLog.AppendLine($"Creating {shaderType}:");
                ShaderLog.AppendLine(shaderLog);
            }
            return shaderID;
        }

        protected override void BindAttributes()
        {
            BindAttribute(0, "position");
            BindAttribute(1, "time");
        }

        protected override string GetScript(ShaderType shaderType)
        {
            var source = Trace.GetScript(shaderType);
            return source == null || source.Length < 1
                ? string.Empty
                : source.Aggregate((s, t) => $@"{s}\n{t}");
        }

        private readonly Trace Trace;

        private int
            VertexShaderID,
            TessControlShaderID,
            TessEvaluationShaderID,
            GeometryShaderID,
            FragmentShaderID,
            ComputeShaderID;
    }
}
