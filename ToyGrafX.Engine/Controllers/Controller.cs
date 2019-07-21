namespace ToyGrafX.Engine.Controllers
{
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using ToyGrafX.Engine.Entities;
    using ToyGrafX.Engine.Shaders;
    using ToyGrafX.Engine.Utility;

    public abstract class Controller
    {
        #region Public Interface

        public void AddEntity(Entity entity) => Entities.Add(entity);

        #endregion

        #region Protected Interface

        protected virtual GraphicsMode GraphicsMode => new GraphicsMode(
            color: new ColorFormat(8, 8, 8, 8),
            depth: 24,
            stencil: 8,
            samples: 0);

        protected virtual void Load()
        {
            GL.ClearColor(Color.White);
            Shader = new StaticShader();
            Renderer = new Renderer(Shader);

            int xc = 100, yc = 100;
            var vertices = Grid.GetVertexCoords(xc, yc).ToArray();
            var indices = Grid.GetTriangleIndices(xc, yc).ToArray();

            var model = new Model(vertices, indices);
            Models.Add(model);

            Entities.Add(new Entity(model, new Vector3(0, 0, -2), new Vector3(0, 0, 0), 1));
            Entities.Add(new Entity(model, new Vector3(-3, 0, 0), new Vector3(0, 0, 0), 1));
            Entities.Add(new Entity(model, new Vector3(+3, 0, 0), new Vector3(0, 0, 0), 1));
        }

        protected virtual void RenderFrame(double time)
        {
            Time += time;
            Camera.Move();
            Renderer.Prepare();

            Shader.Start();

            GL.VertexAttrib1(1, (float)Time);

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
        }

        protected virtual void UpdateFrame(double time)
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

        private readonly List<Entity> Entities = new List<Entity>();
        private readonly List<Model> Models = new List<Model>();

        private double Time;
        private Camera Camera = new Camera();
        private Renderer Renderer;
        private Shader Shader;

        #endregion
    }
}
