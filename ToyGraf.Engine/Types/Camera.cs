namespace ToyGraf.Engine
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;
    using ToyGraf.Engine.Types;

    [TypeConverter(typeof(CameraTypeConverter))]
    public class Camera
    {
        #region Constructors

        public Camera() : this(new Point3F(), new Euler3F()) { }

        public Camera(Camera camera) : this(camera.Position, camera.Rotation) { }

        public Camera(Point3F position, Euler3F rotation)
        {
            Position = new Point3F(position);
            Rotation = new Euler3F(rotation);
        }

        public Camera(Camera camera, string field, object value) : this(camera)
        {
            switch (field)
            {
                case DisplayNames.Position:
                    Position = (Point3F)value;
                    return;
                case DisplayNames.Rotation:
                    Rotation = (Euler3F)value;
                    return;
            }
            var v = (float)value;
            var fields = field.Split('.');
            switch (fields[0])
            {
                case DisplayNames.Position:
                    switch (fields[1])
                    {
                        case Point3F.DisplayNames.X: Position.X = v; break;
                        case Point3F.DisplayNames.Y: Position.Y = v; break;
                        case Point3F.DisplayNames.Z: Position.Z = v; break;
                    }
                    break;
                case DisplayNames.Rotation:
                    switch (fields[1])
                    {
                        case Euler3F.DisplayNames.Pitch: Rotation.Pitch = v; break;
                        case Euler3F.DisplayNames.Yaw: Rotation.Yaw = v; break;
                        case Euler3F.DisplayNames.Roll: Rotation.Roll = v; break;
                    }
                    break;
            }
        }

        public Camera(float x, float y, float z, float pitch, float yaw, float roll) :
            this(new Point3F(x, y, z), new Euler3F(pitch, yaw, roll))
        { }

        #endregion

        #region Public Properties

        [Description(Descriptions.Position)]
        [DisplayName(DisplayNames.Position)]
        [TypeConverter(typeof(Point3FTypeConverter))]
        public Point3F Position { get; set; } = new Point3F();

        [Description(Descriptions.Rotation)]
        [DisplayName(DisplayNames.Rotation)]
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

        public static Camera Parse(string s)
        {
            var t = s.Split(',');
            return new Camera(
                new Point3F(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2])),
                new Euler3F(float.Parse(t[3]), float.Parse(t[4]), float.Parse(t[5])));
        }

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            internal const string
                Position = "The vector representing the Camera's position.",
                Rotation = "The rotation representing the Camera's orientation.";
        }

        internal static class DisplayNames
        {
            internal const string
                Position = "Position",
                Rotation = "Rotation°";
        }

        #endregion

        #region Private Properties

        private Point3F HomePosition;
        private Euler3F HomeRotation;

        #endregion
    }
}
