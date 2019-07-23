namespace ToyGrafXwin.Controllers
{
    using OpenTK;
    using System;
    using System.Windows.Forms;
    using ToyGrafX.Engine.Controllers;

    public class GLControlRenderer : Renderer
    {
        #region Public Interface

        public GLControlRenderer(GLControl control) : base() { Control = control; }

        public GLControl Control
        {
            get => _Control;
            private set
            {
                if (Control == value)
                    return;
                if (Control != null)
                {
                    Control.Load -= Control_Load;
                    Control.Paint -= Control_Paint;
                    Control.Resize -= Control_Resize;
                    Application.Idle -= Application_Idle;
                }
                _Control = value;
                if (Control != null)
                {
                    Control.Load += Control_Load;
                    Control.Paint += Control_Paint;
                    Control.Resize += Control_Resize;
                    Application.Idle += Application_Idle;
                }
            }
        }

        #endregion

        #region Overrides

        protected override int DisplayWidth => Control.ClientSize.Width;
        protected override int DisplayHeight => Control.ClientSize.Height;
        protected override void Load() { Control.MakeCurrent(); base.Load(); }
        protected override void Exit() { }
        protected override void SwapBuffers() => Control.SwapBuffers();

        #endregion

        #region Private Properties

        private GLControl _Control;
        private DateTime LastTime = DateTime.MinValue;

        #endregion

        #region Private Event Handlers

        private void Application_Idle(object sender, EventArgs e) => Idle();
        private void Control_Load(object sender, System.EventArgs e) => Load();
        private void Control_Paint(object sender, System.Windows.Forms.PaintEventArgs e) => Paint();
        private void Control_Resize(object sender, System.EventArgs e) => Resize();

        #endregion

        #region Private Methods

        private void Idle()
        {
            while (Control.IsIdle)
                Paint();
        }

        private void Paint()
        {
            var now = DateTime.Now;
            if (LastTime != DateTime.MinValue)
                RenderFrame((now - LastTime).TotalSeconds);
            LastTime = now;
        }

        #endregion
    }
}
