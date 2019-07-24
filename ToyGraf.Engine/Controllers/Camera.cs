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

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

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
    }
}
