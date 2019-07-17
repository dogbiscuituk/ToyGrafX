namespace ToyGrafX
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public class Renderer
    {
        public Renderer(Shader shader)
        {
            CreateProjectionMatrix();

            //shader.Start();
            shader.Use();

            shader.LoadProjectionMatrix(ProjectionMatrix);

            //shader.Stop();
        }

        public void Prepare()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void Render(Entity entity, Shader shader)
        {
            var model = entity.Model;
            shader.Use();
            GL.BindVertexArray(model.VaoID);
            GL.EnableVertexAttribArray(0);

            var transformationMatrix = Maths.CreateTransformationMatrix(
                entity.Position, entity.RotX, entity.RotY, entity.RotZ, entity.Scale);
            shader.LoadTransformationMatrix(transformationMatrix);

            //GL.DrawArrays(PrimitiveType.LineStrip, 0, model.VertexCount);
            GL.DrawElements(BeginMode.Triangles, model.VertexCount, DrawElementsType.UnsignedInt, 0);

            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);
        }

        private Matrix4 ProjectionMatrix;
        private float FOV = 70;
        private float NearPlane = 1;
        private float FarPlane = 1000;

        private void CreateProjectionMatrix()
        {
            ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(FOV), 1920f / 1080f, NearPlane, FarPlane);
        }
    }
}
