﻿namespace ToyGraf.Engine.Controllers
{
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using ToyGraf.Engine.Entities;
    using ToyGraf.Engine.Shaders;
    using ToyGraf.Engine.Utility;

    public abstract class Renderer
    {
        #region Public Interface

        public Camera Camera = new Camera();

        public void AddEntity(Entity entity) => Entities.Add(entity);

        #endregion

        #region Virtuals

        protected virtual GraphicsMode GraphicsMode => new GraphicsMode(
            color: new ColorFormat(8, 8, 8, 8),
            depth: 24,
            stencil: 8,
            samples: 0);

        protected virtual void Load()
        {
            GL.ClearColor(Color.White);
            Shader = new StaticShader();

            lock (this)
                UpdateProjectionMatrix();
            Shader.Start();
            lock (this)
                LoadProjectionMatrix();
            Shader.Stop();

            int xc = 100, yc = 100;
            var vertices = Grid.GetVertexCoords(xc, yc).ToArray();
            var indices = Grid.GetTriangleIndices(xc, yc).ToArray();

            var prototype = new Prototype(vertices, indices);
            Prototypes.Add(prototype);

            Entities.Add(new Entity(prototype, new Vector3(0, 0, -2), new Vector3(45, 45, 0), 1));
            Entities.Add(new Entity(prototype, new Vector3(-3, 0, 0), new Vector3(0, 0, 0), 1));
            Entities.Add(new Entity(prototype, new Vector3(+3, 0, 0), new Vector3(0, 0, 0), 1));
        }

        protected virtual void RenderFrame(double time)
        {
            Time += time;
            Camera.Move();

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Shader.Start();

            lock (this)
                if (OldProjectionMatrix != NewProjectionMatrix)
                {
                    OldProjectionMatrix = NewProjectionMatrix;
                    LoadProjectionMatrix();
                }

            GL.VertexAttrib1(1, (float)Time);

            Shader.LoadViewMatrix(Camera);
            foreach (var entity in Entities)
            {
                var prototype = entity.Prototype;
                GL.BindVertexArray(prototype.VaoID);
                GL.EnableVertexAttribArray(0);
                var transformationMatrix = Maths.CreateTransformationMatrix(
                    entity.Position, entity.Rotation, entity.Scale);
                Shader.LoadTransformationMatrix(transformationMatrix);

                //GL.DrawArrays(PrimitiveType.LineStrip, 0, prototype.VertexCount);
                GL.DrawElements(BeginMode.Triangles, prototype.VertexCount, DrawElementsType.UnsignedInt, 0);

                GL.DisableVertexAttribArray(0);
                GL.BindVertexArray(0);
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

        #region Abstracts

        protected abstract int DisplayWidth { get; }
        protected abstract int DisplayHeight { get; }
        protected abstract void Exit();
        protected abstract void SwapBuffers();

        #endregion

        #region Private Properties

        private readonly List<Entity> Entities = new List<Entity>();
        private readonly List<Prototype> Prototypes = new List<Prototype>();

        private Shader Shader;
        private double Time;

        #endregion

        #region Projection Matrix

        #region Public Properties

        public float FarPlaneDistance
        {
            get => _FarPlaneDistance;
            set
            {
                if (FarPlaneDistance != value)
                {
                    _FarPlaneDistance = value;
                    lock (this)
                        UpdateProjectionMatrix();
                }
            }
        }

        public float FieldOfViewDegreesY
        {
            get => _FieldOfViewDegreesY;
            set
            {
                if (FieldOfViewDegreesY != value)
                {
                    _FieldOfViewDegreesY = value;
                    lock (this)
                        UpdateProjectionMatrix();
                }
            }
        }

        public float NearPlaneDistance
        {
            get => _NearPlaneDistance;
            set
            {
                if (NearPlaneDistance != value)
                {
                    _NearPlaneDistance = value;
                    lock (this)
                        UpdateProjectionMatrix();
                }
            }
        }

        #endregion

        #region Private Properties

        private float
            _FieldOfViewDegreesY = 70,
            _NearPlaneDistance = 0.1f,
            _FarPlaneDistance = 1000;

        private Matrix4
            NewProjectionMatrix,
            OldProjectionMatrix;

        #endregion

        #region Private Methods

        private void LoadProjectionMatrix() => Shader.LoadProjectionMatrix(NewProjectionMatrix);

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
        private void UpdateProjectionMatrix()
        {
            var fieldOfViewRadiansY = MathHelper.DegreesToRadians(FieldOfViewDegreesY);
            var aspectRatio = 1920f / 1080f;
            NewProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                fieldOfViewRadiansY,
                aspectRatio,
                NearPlaneDistance,
                FarPlaneDistance);
        }

        #endregion

        #endregion
    }
}