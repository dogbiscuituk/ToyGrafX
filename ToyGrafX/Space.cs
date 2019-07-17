namespace ToyGrafX
{
    using System;
    using System.Drawing;
    using System.Linq;
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;

    public class Space : GameWindow
    {
        #region Public Interface

        private Loader Loader;
        private Model Model;
        private Renderer Renderer;
        private Shader Shader;

        public Space(int width, int height, string title)
            : base(width, height, GraphicsMode, title)
        {
        }

        private static readonly GraphicsMode GraphicsMode = new GraphicsMode(
            color: new ColorFormat(8, 8, 8, 8),
            depth: 24,
            stencil: 8,
            samples: 0);

        #endregion

        #region Protected Overrides

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.White);

            Loader = new Loader();
            Renderer = new Renderer();
            Shader = new Shader("shader.vert", "shader.frag");

            int xc = 1000, yc = 1000;
            var vertices = Grid.GetVertexCoords(xc, yc).ToArray();

            Model = Loader.LoadToVAO(vertices);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Renderer.Prepare();
            Renderer.Render(Model, Shader);

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
            Shader.Dispose();
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            Loader.Cleanup();

            base.OnUnload(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
                Exit();
            base.OnUpdateFrame(e);
        }

        #endregion
    }
}
