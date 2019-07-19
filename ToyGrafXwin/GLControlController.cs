namespace ToyGrafXwin
{
    using OpenTK;
    using ToyGrafX.Engine.Controllers;

    public class GLControlController : Controller
    {
        public GLControlController(GLControl control) : base()
        {
            Control = control;
        }

        protected override void Load()
        {
            Control.MakeCurrent();
            base.Load();
        }

        private GLControl _Control;
        public GLControl Control
        {
            get => _Control;
            set
            {
                if (Control != value)
                {
                    if (Control != null)
                    {
                        Control.Load -= Control_Load;
                    }
                    _Control = value;
                    if (Control != null)
                    {
                        Control.Load += Control_Load;
                    }
                }
            }
        }

        private void Control_Load(object sender, System.EventArgs e) => Load();

        protected override int DisplayWidth => Control.ClientSize.Width;
        protected override int DisplayHeight => Control.ClientSize.Height;

        protected override void Exit()
        {
            throw new System.NotImplementedException();
        }

        protected override void SwapBuffers() => Control.SwapBuffers();
    }
}
