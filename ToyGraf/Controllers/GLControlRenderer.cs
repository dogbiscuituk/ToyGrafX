namespace ToyGraf.Controllers
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using ToyGraf.Engine.Controllers;
    using ToyGraf.Engine.Entities;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public class GLControlRenderer : Renderer
    {
        #region Internal Interface

        internal GLControlRenderer(SceneController sceneController) : base() => SceneController = sceneController;

        #endregion

        #region Overrides

        protected override int DisplayWidth => Control.ClientSize.Width;
        protected override int DisplayHeight => Control.ClientSize.Height;

        protected override void Load()
        {
            MakeCurrent(true);

            GL.ClearColor(Color.White);

            /*
            Shader = new StaticShader();

            lock (this)
                UpdateProjectionMatrix();
            Shader.Start();
            lock (this)
                LoadProjectionMatrix();
            Shader.Stop();

            Entities.Clear();
            Entities.AddRange(GetEntities());
            */
            MakeCurrent(false);
        }

        protected override void Exit() { }
        protected override void SwapBuffers() => Control.SwapBuffers();
        protected override void RenderFrame(double time) { MakeCurrent(true); base.RenderFrame(time); MakeCurrent(false); }
        protected override void Resize() { MakeCurrent(true); base.Resize(); MakeCurrent(false); }
        protected override void Unload() { MakeCurrent(true); base.Unload(); MakeCurrent(false); }
        protected override void UpdateFrame(double time) { MakeCurrent(true); base.UpdateFrame(time); MakeCurrent(false); }

        #endregion

        #region Private Properties

        private SceneController _SceneController;
        private SceneController SceneController
        {
            get => _SceneController;
            set
            {
                if (SceneController == value)
                    return;
                if (SceneController != null)
                {
                    Control.Load -= Control_Load;
                    Control.Paint -= Control_Paint;
                    Control.Resize -= Control_Resize;
                }
                _SceneController = value;
                if (SceneController != null)
                {
                    Control.Load += Control_Load;
                    Control.Paint += Control_Paint;
                    Control.Resize += Control_Resize;
                }
            }
        }

        private GLControl Control => SceneForm.GLControl;
        private SceneForm SceneForm => SceneController.SceneForm;

        private DateTime LastTime = DateTime.MinValue;

        #endregion

        #region Private Event Handlers

        private void Control_Load(object sender, System.EventArgs e) => Load();
        private void Control_Paint(object sender, System.Windows.Forms.PaintEventArgs e) => Render();
        private void Control_Resize(object sender, System.EventArgs e) => Resize();

        #endregion

        #region Private Methods

        internal void MakeCurrent(bool current)
        {
            if (current)
                Control.MakeCurrent();
            else
                Control.Context.MakeCurrent(null);
        }

        internal void Render()
        {
            var now = DateTime.Now;
            if (LastTime != DateTime.MinValue)
                RenderFrame((now - LastTime).TotalSeconds);
            LastTime = now;
        }

        private Scene Scene => SceneController.Scene;
        private List<Trace> Traces => Scene._Traces;

        protected override IEnumerable<IEntity> GetEntities()
        {
            yield break;
            //foreach (var trace in Traces)
            //    yield return trace;

            /*
            int xc = 1000, yc = 1000;
            var vertices = Grid.GetVertexCoords(xc, yc).ToArray();
            var indices = Grid.GetTriangleIndices(xc, yc).ToArray();

            var prototype = new Prototype(vertices, indices);
            //Prototypes.Add(prototype);

            yield return new Entity(prototype, new Vector3(0, 0, -2), new Vector3(45, 45, 0), 1);

            //Entities.Add(new Entity(prototype, new Vector3(0, 0, -2), new Vector3(45, 45, 0), 1));
            //Entities.Add(new Entity(prototype, new Vector3(-3, 0, 0), new Vector3(0, 0, 0), 1));
            //Entities.Add(new Entity(prototype, new Vector3(+3, 0, 0), new Vector3(0, 0, 0), 1));
            */
        }

        #endregion
    }
}
