namespace ToyGrafX
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.IO;
    using System.Text;

    public class Shader
    {
        #region Public Interface

        public Shader(string vertexPath, string fragmentPath)
        {
            int vertexShaderID = LoadShader(vertexPath, ShaderType.VertexShader),
                fragmentShaderID = LoadShader(fragmentPath, ShaderType.FragmentShader);
            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertexShaderID);
            GL.AttachShader(Handle, fragmentShaderID);
            BindAttributes();
            GL.LinkProgram(Handle);
            GL.ValidateProgram(Handle);
            GetAllUniformLocations();
#if DEBUG
            WriteProgramLog(Handle);
#endif
            GL.DetachShader(Handle, vertexShaderID);
            GL.DetachShader(Handle, fragmentShaderID);
            GL.DeleteShader(vertexShaderID);
            GL.DeleteShader(fragmentShaderID);
        }

        #endregion

        protected virtual void BindAttributes()
        {
        }

        protected void LoadFloat(int location, float value) => GL.Uniform1(location, value);
        protected void LoadVector(int location, Vector3 vector) => GL.Uniform3(location, vector);
        protected void LoadBoolean(int location, bool value) => GL.Uniform1(location, value ? 1f : 0f);
        protected void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);

        protected int GetUniformLocation(string uniformName)
        {
            return GL.GetUniformLocation(Handle, uniformName);
        }

        private int location_projectionMatrix;
        private int location_transformationMatrix;
        private int location_viewMatrix;

        protected virtual void GetAllUniformLocations()
        {
            location_projectionMatrix = GetUniformLocation("projectionMatrix");
            location_transformationMatrix = GetUniformLocation("transformationMatrix");
            location_viewMatrix = GetUniformLocation("viewMatrix");
        }

        public void LoadProjectionMatrix(Matrix4 matrix) => LoadMatrix(location_projectionMatrix, matrix);
        public void LoadTransformationMatrix(Matrix4 matrix) => LoadMatrix(location_transformationMatrix, matrix);
        public void LoadViewMatrix(Camera camera) => LoadMatrix(location_viewMatrix, Maths.CreateViewMatrix(camera));

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
