namespace ToyGrafX
{
    using System;
    using System.Collections.Generic;
    using OpenTK;
    using OpenTK.Graphics;
    using OpenTK.Graphics.ES30;
    using OpenTK.Input;

    public class Space : GameWindow
    {
        #region Public Interface

        public Space(int width, int height, string title)
            : base(width, height, GraphicsMode, title) { }

        private static readonly GraphicsMode GraphicsMode = new GraphicsMode(
            color: new ColorFormat(8, 8, 8, 8),
            depth: 24,
            stencil: 8,
            samples: 0);

        #endregion

        #region Protected Overrides

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            VBO = GL.GenBuffer();
            Shader = new Shader("shader.vert", "shader.frag");

            GL.BindVertexArray(VAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            //EBO = GL.GenBuffer();
            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            //GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(uint), Indices, BufferUsageHint.StaticDraw);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Shader.Use();
            GL.BindVertexArray(VAO);

            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.DrawArrays(PrimitiveType.LineStrip, 0, Vertices.Length / 3);
            //GL.DrawElements(PrimitiveType.LineStrip, Indices.Length, DrawElementsType.UnsignedInt, (IntPtr)0);

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
            GL.DeleteBuffer(VBO);

            Shader.Dispose();

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

        #region Private Properties

        private int VAO, VBO, EBO;

        const double
            radius = 10,
            omega = (float)(2 * Math.PI * 2 / 10),
            minT = -10,
            maxT = +10,
            deltaT = 0.01;

        private float[] Vertices
        {
            get
            {
                return BuildFloor(100, 100);
                /*var result = new List<float>();
                double t;
                for (t = minT; t < maxT; t += deltaT)
                    AddVertex(result, t);
                t += deltaT;
                AddVertex(result, t);
                t += deltaT;
                AddVertex(result, t);
                return result.ToArray();*/
            }
        }

        private void AddVertex(List<float> result, double t)
        {
            double
                x = 0 /* radius * Math.Cos(omega * t) */,
                y = 0 /* radius * Math.Sin(omega * t) */ ;
            result.Add((float)t / 12);
            result.Add((float)x / 12);
            result.Add((float)y / 12);
        }

        /*private uint[] Indices
        {
            get
            {
                var result = new List<uint>();
                uint index = 0;
                for (var t = minT; t < maxT; t += deltaT)
                {
                    result.Add(index++);
                    result.Add(index);
                    result.Add(index + 1);
                }
                return result.ToArray();
            }
        }*/

        private Shader Shader;

        #endregion

        #region Private Methods

        private float[] BuildFloor(int xStepCount, int yStepCount)
        {
            var result = new List<float>();
            for (int xIndex = 0; xIndex <= xStepCount; xIndex++)
            {
                var x = -1 + 2f * xIndex / xStepCount;
                for (int yIndex = 0; yIndex <= xStepCount; yIndex++)
                {
                    var y = 2f * yIndex / yStepCount - 1;
                    result.AddRange(new[] { x, y, 0 });
                }
            }
            return result.ToArray();
        }

        #endregion
    }
}
