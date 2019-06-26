namespace ToyGrafX
{
    using System;
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.ES20;
    using OpenTK.Input;

    public class Game : GameWindow
    {
        public Game(int width, int height, string title) :
            base(width, height, GraphicsMode.Default, title)
        { }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //Code goes here
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            shader = new Shader("shader.vert", "shader.frag");

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);

            shader.Dispose();

            base.OnUnload(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
                Exit();
            base.OnUpdateFrame(e);
        }

        int VertexBufferObject;
        float[] vertices =
        {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f,  //Bottom-right vertex
            0.0f,  0.5f, 0.0f   //Top vertex
        };

        Shader shader;
    }
}
