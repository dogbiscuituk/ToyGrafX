namespace ToyGrafX.Engine.Shaders
{
    public class StaticShader : Shader
    {
        public StaticShader() : base(VertexPath, FragmentPath)
        { }

        const string VertexPath = @"Shaders\shader.vert";
        const string FragmentPath = @"Shaders\shader.frag";

        protected override void BindAttributes()
        {
            BindAttribute(0, "position");
        }
    }
}
