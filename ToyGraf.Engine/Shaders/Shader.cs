namespace ToyGraf.Engine.Shaders
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using ToyGraf.Engine.Controllers;
    using ToyGraf.Engine.Utility;

    public abstract class Shader
    {
        #region Public Interface

        public void Start() => GL.UseProgram(ProgramID);
        public void Stop() => GL.UseProgram(0);

        #endregion

        protected void BindAttribute(int attributeIndex, string variableName) =>
            GL.BindAttribLocation(ProgramID, attributeIndex, variableName);

        protected abstract void BindAttributes();

        public virtual void CreateProgram()
        {
            VertexShaderID = CreateShader(ShaderType.VertexShader);
            FragmentShaderID = CreateShader(ShaderType.FragmentShader);
            ProgramID = GL.CreateProgram();
            GL.AttachShader(ProgramID, VertexShaderID);
            GL.AttachShader(ProgramID, FragmentShaderID);
            BindAttributes();
            GL.LinkProgram(ProgramID);
            GL.ValidateProgram(ProgramID);
            GetAllUniformLocations();
#if DEBUG
            WriteProgramLog(ProgramID);
#endif
            GL.DetachShader(ProgramID, VertexShaderID);
            GL.DetachShader(ProgramID, FragmentShaderID);
            GL.DeleteShader(VertexShaderID);
            GL.DeleteShader(FragmentShaderID);
        }

        protected int GetUniformLocation(string uniformName) => GL.GetUniformLocation(ProgramID, uniformName);
        protected void LoadFloat(int location, float value) => GL.Uniform1(location, value);
        protected void LoadVector(int location, Vector3 vector) => GL.Uniform3(location, vector);
        protected void LoadBoolean(int location, bool value) => GL.Uniform1(location, value ? 1f : 0f);
        protected void LoadMatrix(int location, Matrix4 value) => GL.UniformMatrix4(location, false, ref value);

        #region Private Properties
        private int ProgramID;
        private int VertexShaderID;
        private readonly int GeometryShaderID;
        private int FragmentShaderID;
        private int
            location_projectionMatrix,
            location_transformationMatrix,
            location_viewMatrix;

        #endregion

        protected virtual int CreateShader(ShaderType shaderType)
        {
            var shaderSource = GetScript(shaderType);
            if (string.IsNullOrWhiteSpace(shaderSource))
                return 0;
            var shaderID = GL.CreateShader(shaderType);
            GL.ShaderSource(shaderID, shaderSource);
            GL.CompileShader(shaderID);
#if DEBUG
            WriteShaderLog(shaderID);
#endif
            return shaderID;
        }

        protected virtual void GetAllUniformLocations()
        {
            location_projectionMatrix = GetUniformLocation("projectionMatrix");
            location_transformationMatrix = GetUniformLocation("transformationMatrix");
            location_viewMatrix = GetUniformLocation("viewMatrix");
        }

        public void LoadProjectionMatrix(Matrix4 matrix) => LoadMatrix(location_projectionMatrix, matrix);
        public void LoadTransformationMatrix(Matrix4 matrix) => LoadMatrix(location_transformationMatrix, matrix);
        public void LoadViewMatrix(Camera camera) => LoadMatrix(location_viewMatrix, Maths.CreateViewMatrix(camera));

        protected abstract string GetScript(ShaderType shaderType);

        public void Cleanup()
        {
            GL.DetachShader(ProgramID, VertexShaderID);
            GL.DeleteShader(VertexShaderID);
            if (GeometryShaderID != 0)
            {
                GL.DetachShader(ProgramID, GeometryShaderID);
                GL.DeleteShader(GeometryShaderID);
            }
            GL.DetachShader(ProgramID, FragmentShaderID);
            GL.DeleteShader(FragmentShaderID);
            GL.DeleteProgram(ProgramID);
        }

#if DEBUG
        private static void WriteLog(string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
                System.Diagnostics.Debug.WriteLine(s);
        }

        private static void WriteProgramLog(int programID) => WriteLog(GL.GetProgramInfoLog(programID));
        private static void WriteShaderLog(int shaderID) => WriteLog(GL.GetShaderInfoLog(shaderID));
#endif
    }
}
