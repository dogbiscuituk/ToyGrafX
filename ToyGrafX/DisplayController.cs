namespace ToyGrafX
{
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public abstract class DisplayController
    {
        #region Protected Interface

        protected virtual GraphicsMode GraphicsMode => new GraphicsMode(
            color: new ColorFormat(8, 8, 8, 8),
            depth: 24,
            stencil: 8,
            samples: 0);

        protected virtual void Load()
        {
            GL.ClearColor(Color.White);
            Loader = new Loader();
            Shader = new StaticShader();
            Renderer = new Renderer(Shader);
            int xc = 1000, yc = 1000;
            var vertices = Grid.GetVertexCoords(xc, yc).ToArray();
            var indices = Grid.GetTriangleIndices(xc, yc).ToArray();
            Model = Loader.LoadToVAO(vertices, indices);
            Entities.Add(new Entity(Model, new Vector3(0, 0, 0), 0, 0, 0, 1));
            Entities.Add(new Entity(Model, new Vector3(-3, 0, 0), 0, 0, 0, 1));
            Entities.Add(new Entity(Model, new Vector3(+3, 0, 0), 0, 0, 0, 1));
        }

        protected virtual void RenderFrame()
        {
            Camera.Move();
            Renderer.Prepare();
            Shader.Start();
            Shader.LoadViewMatrix(Camera);
            foreach (var entity in Entities)
            {
                entity.MoveBy(0, 0, -0.01f);
                entity.RotateBy(1, 2, 3);
                Renderer.Render(entity, Shader);
            }
            Shader.Stop();
            SwapBuffers();
        }

        protected virtual void Resize() => GL.Viewport(0, 0, DisplayWidth, DisplayHeight);
        
        protected virtual void Unload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            Shader.Cleanup();
            Loader.Cleanup();
        }

        protected virtual void UpdateFrame()
        {
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
                Exit();
        }

        #endregion

        #region Protected Virtual Interface

        protected abstract int DisplayWidth { get; }
        protected abstract int DisplayHeight { get; }
        protected abstract void Exit();
        protected abstract void SwapBuffers();

        #endregion

        #region Private Properties

        private Camera Camera = new Camera();
        private readonly List<Entity> Entities = new List<Entity>();
        private Loader Loader;
        private Model Model;
        private Renderer Renderer;
        private Shader Shader;

        #endregion
    }
}
