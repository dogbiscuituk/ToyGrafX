namespace ToyGrafX
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

    public class Renderer
    {
        public Renderer(Shader shader)
        {
            CreateProjectionMatrix();

            shader.Start();
            shader.LoadProjectionMatrix(ProjectionMatrix);
            shader.Stop();
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
        private float
            FOVy = 70, // degrees
            Znear = 0.1f,
            Zfar = 1000;

        /// <summary>
        /// Create a Projection Matrix given values: aspect ratio = A, field of view = FOVy radians,
        /// near plane = Znear, and far plane = Zfar. Then the frustrum length is zm = Zfar - Znear.
        /// Also, let zp = Zfar + Znear. Then we have the following matrix formula:
        /// 
        /// [ x_scale     0      0       0                 ]
        /// [    0     y_scale   0       0                 ]
        /// [    0        0     -zp/zm  -(2*Zfar*Znear)/zm ]
        /// [    0        0     -1       0                 ]
        /// 
        /// where y_scale = cot(FOVy/2), and x_scale = y_scale/A.
        /// </summary>
        private void CreateProjectionMatrix()
        {
            ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(FOVy), 1920f / 1080f, Znear, Zfar);
        }
    }
}
