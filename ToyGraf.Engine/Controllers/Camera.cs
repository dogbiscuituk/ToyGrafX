namespace ToyGraf.Engine
{
    using OpenTK;

    public class Camera
    {
        public Vector3 Orientation
        {
            get => new Vector3(Pitch, Yaw, Roll);
            set { Pitch = value.X; Yaw = value.Y; Roll = value.Z; }
        }

        public Vector3 Position
        {
            get => new Vector3(X, Y, Z);
            set { X = value.X; Y = value.Y; Z = value.Z; }
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Pitch
        {
            get => _Pitch;
            set => _Pitch = value % 360.0f;
        }

        public float Yaw
        {
            get => _Yaw;
            set => _Yaw = value % 360.0f;
        }

        public float Roll
        {
            get => _Roll;
            set => _Roll = value % 360.0f;
        }

        public void Reset()
        {
            Position = HomePosition;
            Orientation = HomeOrientation;
        }

        public void Fix()
        {
            HomePosition = Position;
            HomeOrientation = Orientation;
        }

        #region Private Properties

        private float _Pitch, _Yaw, _Roll;

        private Vector3 HomePosition = Vector3.Zero;
        private Vector3 HomeOrientation = Vector3.Zero;

        #endregion
    }
}
