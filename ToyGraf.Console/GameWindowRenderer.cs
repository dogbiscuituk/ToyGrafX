﻿namespace ToyGraf.Console
{
    using OpenTK;
    using OpenTK.Input;
    using System;
    using ToyGraf.Engine;
    using ToyGraf.Engine.Controllers;

    public class GameWindowRenderer : Renderer
    {
        #region Public Interface

        public GameWindowRenderer(int width, int height, string title) =>
            GameWindow = new GameWindow(width, height, GraphicsMode, title);

        public GameWindow GameWindow
        {
            get => _GameWindow;
            private set
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

        #endregion

        #region Overrides

        protected override int DisplayHeight => GameWindow.Height;
        protected override int DisplayWidth => GameWindow.Width;

        protected override void Exit() => GameWindow.Exit();
        protected override void SwapBuffers() => GameWindow.Context.SwapBuffers();

        protected override void RenderFrame(double time)
        {
            base.RenderFrame(time);
            MoveCamera();
        }

        protected override void UpdateFrame(double time)
        {
            base.UpdateFrame(time);
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
                Exit();
        }

        #endregion

        #region Private Properties

        private GameWindow _GameWindow;

        #endregion

        #region Private Event Handlers

        private void GameWindow_Load(object sender, System.EventArgs e) => Load();
        private void GameWindow_RenderFrame(object sender, FrameEventArgs e) => RenderFrame(e.Time);
        private void GameWindow_Resize(object sender, System.EventArgs e) => Resize();
        private void GameWindow_Unload(object sender, System.EventArgs e) => Unload();
        private void GameWindow_UpdateFrame(object sender, FrameEventArgs e) => UpdateFrame(e.Time);

        #endregion

        #region Private Methods

        /// <summary>
        ///             Normal      Shift       Ctrl
        /// -------------------------------------------
        /// Left        -X          +Roll       -Yaw
        /// Right       +X          -Roll       +Yaw
        /// Up          +Y          -Z          -Pitch
        /// Down        -Y          +Z          +Pitch
        /// </summary>
        private void MoveCamera()
        {
            var keyboard = Keyboard.GetState();
            var shiftKeys =
                ((keyboard.IsKeyDown(Key.LShift) || keyboard.IsKeyDown(Key.RShift)) ? ShiftKeys.Shift : 0) |
                ((keyboard.IsKeyDown(Key.LControl) || keyboard.IsKeyDown(Key.RControl)) ? ShiftKeys.Ctrl : 0) |
                ((keyboard.IsKeyDown(Key.LAlt) || keyboard.IsKeyDown(Key.RAlt)) ? ShiftKeys.Alt : 0);
            float r = 1f, s = 0.1f;
            if ((shiftKeys & ShiftKeys.Alt) != 0)
            {
                r *= 10;
                s *= 10;
                shiftKeys &= ~ShiftKeys.Alt;
            }
            if (keyboard.IsKeyDown(Key.Left)) Do(p => p.X -= s, p => p.Roll += r, p => p.Yaw -= r);
            if (keyboard.IsKeyDown(Key.Right)) Do(p => p.X += s, p => p.Roll -= r, p => p.Yaw += r);
            if (keyboard.IsKeyDown(Key.Up)) Do(p => p.Y += s, p => p.Z -= s, p => p.Pitch -= r);
            if (keyboard.IsKeyDown(Key.Down)) Do(p => p.Y -= s, p => p.Z += s, p => p.Pitch += r);

            void Do(Action<Camera> normal, Action<Camera> shift, Action<Camera> ctrl)
            {
                switch (shiftKeys)
                {
                    case ShiftKeys.None: normal(Camera); return;
                    case ShiftKeys.Shift: shift(Camera); return;
                    case ShiftKeys.Ctrl: ctrl(Camera); return;
                    case ShiftKeys.CtrlShift: ctrl(Camera); goto case ShiftKeys.Shift;
                }
            }
        }

        #endregion
    }
}