namespace ToyGrafX
{
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.IO;
    using System.Text;

    public class Shader
    {
        public Shader(string vertexPath, string fragmentPath)
        {
            int VertexShader, FragmentShader;

            string VertexShaderSource;
            using (var reader = new StreamReader(vertexPath, Encoding.UTF8))
                VertexShaderSource = reader.ReadToEnd();
            VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);
            GL.CompileShader(VertexShader);
#if DEBUG
            WriteShaderLog(VertexShader);
#endif
            string FragmentShaderSource;
            using (var reader = new StreamReader(fragmentPath, Encoding.UTF8))
                FragmentShaderSource = reader.ReadToEnd();
            FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);
            GL.CompileShader(FragmentShader);
#if DEBUG
            WriteShaderLog(FragmentShader);
#endif
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, VertexShader);
            GL.AttachShader(Handle, FragmentShader);
            GL.LinkProgram(Handle);
#if DEBUG
            WriteProgramLog(Handle);
#endif
            GL.DetachShader(Handle, VertexShader);
            GL.DetachShader(Handle, FragmentShader);
            GL.DeleteShader(FragmentShader);
            GL.DeleteShader(VertexShader);
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
