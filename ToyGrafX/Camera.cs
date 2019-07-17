namespace ToyGrafX
{
    using OpenTK;
    using OpenTK.Input;

    public class Camera
    {
        private Vector3 Position;

        public float Pitch { get; private set; }
        public float Yaw { get; private set; }
        public float Roll { get; private set; }

        public Camera() { }

        public Vector3 GetPosition()
        {
            return Position;
        }

        public void Move()
        {
            var input = Keyboard.GetState();
            if (input.IsKeyDown(Key.W))
                Position.Z -= 0.02f;
            if (input.IsKeyDown(Key.D))
                Position.X += 0.02f;
            if (input.IsKeyDown(Key.A))
                Position.X -= 0.02f;
        }
    }
}
