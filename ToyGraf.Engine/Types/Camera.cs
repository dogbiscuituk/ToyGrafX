namespace ToyGraf.Engine
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;
    using ToyGraf.Engine.Types;

    public class Camera
    {
        #region Constructors

        public Camera() : this(new Point3F(), new Euler3F()) { }

        public Camera(Camera camera) : this(camera.Position, camera.Rotation) { }

        public Camera(Point3F position, Euler3F rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Camera(Camera camera, string fieldName, float value) : this(camera)
        {
            switch (fieldName)
            {
                case "X":
                    Position.X = value;
                    break;
                case "Y":
                    Position.Y = value;
                    break;
                case "Z":
                    Position.Z = value;
                    break;
                case "Pitch":
                    Rotation.Pitch = value;
                    break;
                case "Yaw":
                    Rotation.Yaw = value;
                    break;
                case "Roll":
                    Rotation.Roll = value;
                    break;
            }
        }

        public Camera(float x, float y, float z, float pitch, float yaw, float roll) :
            this(new Point3F(x, y, z), new Euler3F(pitch, yaw, roll))
        { }

        #endregion

        #region Public Properties

        [Description(Descriptions.Position)]
        [TypeConverter(typeof(Point3FTypeConverter))]
        public Point3F Position { get; set; } = new Point3F();

        [Description(Descriptions.Rotation)]
        [TypeConverter(typeof(Euler3FTypeConverter))]
        public Euler3F Rotation { get; set; } = new Euler3F();

        #endregion

        #region Public Methods

        public void Fix()
        {
            HomePosition = Position;
            HomeRotation = Rotation;
        }

        public void Reset()
        {
            Position = HomePosition;
            Rotation = HomeRotation;
        }

        public override string ToString() => $"{Position}, {Rotation}";

        #endregion

        #region Private Classes

        private class Descriptions
        {
            internal const string
                Position = "The vector representing the Camera's position.",
                Rotation = "The rotation representing the Camera's orientation.";
        }

        #endregion

        #region Private Properties

        private Point3F HomePosition;
        private Euler3F HomeRotation;

        #endregion
    }
}
