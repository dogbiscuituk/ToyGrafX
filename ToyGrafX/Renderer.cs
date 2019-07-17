namespace ToyGrafX
{
    using OpenTK.Graphics.OpenGL;

    public class Renderer
    {
        public void Prepare()
        {
            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void Render(Model model, Shader shader)
        {
            shader.Use();
            GL.BindVertexArray(model.VaoID);
            GL.EnableVertexAttribArray(0);
            GL.DrawArrays(PrimitiveType.LineStrip, 0, model.VertexCount);
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }
    }
}
