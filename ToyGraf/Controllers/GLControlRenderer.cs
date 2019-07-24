namespace ToyGraf.Controllers
{
    using OpenTK;
    using System;
    using ToyGraf.Engine.Controllers;

    public class GLControlRenderer : Renderer
    {
        #region Internal Interface

        internal GLControlRenderer(GLControl control) : base() => Control = control;

        #endregion

        #region Overrides

        protected override int DisplayWidth => Control.ClientSize.Width;
        protected override int DisplayHeight => Control.ClientSize.Height;
        protected override void Load() { Control.MakeCurrent(); base.Load(); }
        protected override void Exit() { }
        protected override void SwapBuffers() => Control.SwapBuffers();

        protected override void RenderFrame(double time)
        {
            Control.MakeCurrent();
            base.RenderFrame(time);
        }

        protected override void Resize()
        {
            Control.MakeCurrent();
            base.Resize();
        }

        protected override void Unload()
        {
            Control.MakeCurrent();
            base.Unload();
        }

        protected override void UpdateFrame(double time)
        {
            Control.MakeCurrent();
            base.UpdateFrame(time);
        }

        #endregion

        #region Private Properties

        private GLControl Control
        {
            get => _Control;
            set
            {
                if (Control == value)
                    return;
                if (Control != null)
                {
                    Control.Load -= Control_Load;
                    Control.Paint -= Control_Paint;
                    Control.Resize -= Control_Resize;
                }
                _Control = value;
                if (Control != null)
                {
                    Control.Load += Control_Load;
                    Control.Paint += Control_Paint;
                    Control.Resize += Control_Resize;
                }
            }
        }

        private GLControl _Control;
        private DateTime LastTime = DateTime.MinValue;

        #endregion

        #region Private Event Handlers

        private void Control_Load(object sender, System.EventArgs e) => Load();
        private void Control_Paint(object sender, System.Windows.Forms.PaintEventArgs e) => Paint();
        private void Control_Resize(object sender, System.EventArgs e) => Resize();

        #endregion

        #region Private Methods

        internal void Paint()
        {
            var now = DateTime.Now;
            if (LastTime != DateTime.MinValue)
                RenderFrame((now - LastTime).TotalSeconds);
            LastTime = now;
        }

        #endregion
    }
}
