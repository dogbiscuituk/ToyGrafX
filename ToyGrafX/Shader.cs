namespace ToyGrafX
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.IO;
    using System.Text;

    public class Shader
    {
        #region Public Interface

        public Shader(string vertexPath, string fragmentPath)
        {
            var vertexShader = LoadShader(vertexPath, ShaderType.VertexShader);
            var fragmentShader = LoadShader(fragmentPath, ShaderType.FragmentShader);
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);
            GL.LinkProgram(Handle);
#if DEBUG
            WriteProgramLog(Handle);
#endif
            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }

        #endregion

        private int LoadShader(string shaderPath, ShaderType shaderType)
        {
            string shaderSource;
            using (var reader = new StreamReader(shaderPath, Encoding.UTF8))
                shaderSource = reader.ReadToEnd();
            var shader = GL.CreateShader(shaderType);
            GL.ShaderSource(shader, shaderSource);
            GL.CompileShader(shader);
#if DEBUG
            WriteShaderLog(shader);
#endif
            return shader;
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        private int Handle;

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(Handle);
                disposedValue = true;
            }
        }

        ~Shader() => GL.DeleteProgram(Handle);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

#if DEBUG
        private static void WriteLog(string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
                System.Diagnostics.Debug.WriteLine(s);
        }

        private static void WriteProgramLog(int program) => WriteLog(GL.GetProgramInfoLog(program));
        private static void WriteShaderLog(int shader) => WriteLog(GL.GetShaderInfoLog(shader));
#endif
    }
}
