namespace ToyGrafX
{
    public class StaticShader : Shader
    {
        public StaticShader() : base(VertexPath, FragmentPath)
        {
        }

        const string VertexPath = "shader.vert";
        const string FragmentPath = "shader.frag";

        protected override void BindAttributes()
        {
            BindAttribute(0, "position");
        }
    }
}
