namespace ToyGraf.Engine.Controllers
{
    using OpenTK;
    using OpenTK.Input;
    using System;

    public class Camera
    {
        public Vector3 Position
        {
            get => new Vector3(X, Y, Z);
            set { X = value.X; Y = value.Y; Z = value.Z; }
        }

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        private float _Pitch;
        public float Pitch
        {
            get => _Pitch;
            set => _Pitch = value % 360.0f;
        }

        private float _Yaw;
        public float Yaw
        {
            get => _Yaw;
            set => _Yaw = value % 360.0f;
        }

        private float _Roll;
        public float Roll
        {
            get => _Roll;
            set => _Roll = value % 360.0f;
        }

        /// <summary>
        ///             Normal      Shift       Ctrl
        /// -------------------------------------------
        /// Left        -X          +Roll       -Yaw
        /// Right       +X          -Roll       +Yaw
        /// Up          +Y          -Z          -Pitch
        /// Down        -Y          +Z          +Pitch
        /// </summary>
        public void Move()
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
                    case ShiftKeys.None: normal(this); return;
                    case ShiftKeys.Shift: shift(this); return;
                    case ShiftKeys.Ctrl: ctrl(this); return;
                    case ShiftKeys.CtrlShift: ctrl(this); goto case ShiftKeys.Shift;
                }
            }
        }
    }
}
