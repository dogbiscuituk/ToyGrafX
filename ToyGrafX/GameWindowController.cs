namespace ToyGrafX
{
    using OpenTK;
    using ToyGrafX.Engine.Controllers;

    public class GameWindowController : Controller
    {
        public GameWindowController(int width, int height, string title) =>
            GameWindow = new GameWindow(width, height, GraphicsMode, title);

        public GameWindow GameWindow
        {
            get => _GameWindow;
            set
            {
                if (GameWindow != value)
                {
                    if (GameWindow != null)
                    {
                        GameWindow.Load -= GameWindow_Load;
                        GameWindow.RenderFrame -= GameWindow_RenderFrame;
                        GameWindow.Resize -= GameWindow_Resize;
                        GameWindow.Unload -= GameWindow_Unload;
                        GameWindow.UpdateFrame -= GameWindow_UpdateFrame;
                    }
                    _GameWindow = value;
                    if (GameWindow != null)
                    {
                        GameWindow.Load += GameWindow_Load;
                        GameWindow.RenderFrame += GameWindow_RenderFrame;
                        GameWindow.Resize += GameWindow_Resize;
                        GameWindow.Unload += GameWindow_Unload;
                        GameWindow.UpdateFrame += GameWindow_UpdateFrame;
                    }
                }
            }
        }

        #region Private Properties

        private GameWindow _GameWindow;

        #endregion

        #region Private Event Handlers

        private void GameWindow_Load(object sender, System.EventArgs e) => Load();
        private void GameWindow_RenderFrame(object sender, FrameEventArgs e) => RenderFrame();
        private void GameWindow_Resize(object sender, System.EventArgs e) => Resize();
        private void GameWindow_Unload(object sender, System.EventArgs e) => Unload();
        private void GameWindow_UpdateFrame(object sender, FrameEventArgs e) => UpdateFrame();

        protected override int DisplayWidth => GameWindow.Width;
        protected override int DisplayHeight => GameWindow.Height;
        protected override void Exit() => GameWindow.Exit();
        protected override void SwapBuffers() => GameWindow.Context.SwapBuffers();

        #endregion
    }
}
