using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ToyGraf.Engine.Shaders
{
    public class StaticShader : Shader
    {
        #region Public Interface

        public StaticShader() : this(@"Shaders\shader.vert", "", @"Shaders\shader.frag") { }

        public StaticShader(string vertexPath, string geometryPath, string fragmentPath)
        {
            VertexPath = vertexPath;
            GeometryPath = geometryPath;
            FragmentPath = fragmentPath;
            CreateProgram();
        }

        #endregion

        #region Protected Implementation

        protected override void BindAttributes()
        {
            BindAttribute(0, "position");
            BindAttribute(1, "time");
        }

        protected override string GetShaderSource(ShaderType shaderType)
        {
            using (var reader = new StreamReader(GetSourcePath(shaderType), Encoding.UTF8))
                return reader.ReadToEnd();
        }

        #endregion

        #region Private Properties

        private string
            VertexPath,
            GeometryPath,
            FragmentPath;

        #endregion

        #region Private Methods

        private string GetSourcePath(ShaderType shaderType)
        {
            switch (shaderType)
            {
                case ShaderType.VertexShader:
                    return VertexPath;
                case ShaderType.GeometryShader:
                    return GeometryPath;
                case ShaderType.FragmentShader:
                    return FragmentPath;
            }
            throw new InvalidEnumArgumentException();
        }

        #endregion
    }
}
