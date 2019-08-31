namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(CameraTypeConverter))]
    public class Camera
    {
        #region Constructors

        public Camera() : this(new Vector3f(), new Euler3f()) { }

        public Camera(Camera camera) : this(camera.Position, camera.Rotation) { }

        public Camera(Vector3f position, Euler3f rotation)
        {
            Position = new Vector3f(position);
            Rotation = new Euler3f(rotation);
        }

        public Camera(Camera camera, string field, object value) : this(camera)
        {
            switch (field)
            {
                case DisplayNames.Position:
                    Position = (Vector3f)value;
                    return;
                case DisplayNames.Rotation:
                    Rotation = (Euler3f)value;
                    return;
            }
            var v = (float)value;
            var fields = field.Split('.');
            switch (fields[0])
            {
                case DisplayNames.Position:
                    switch (fields[1])
                    {
                        case Vector3f.DisplayNames.X: Position.X = v; break;
                        case Vector3f.DisplayNames.Y: Position.Y = v; break;
                        case Vector3f.DisplayNames.Z: Position.Z = v; break;
                    }
                    break;
                case DisplayNames.Rotation:
                    switch (fields[1])
                    {
                        case Euler3f.DisplayNames.Pitch: Rotation.Pitch = v; break;
                        case Euler3f.DisplayNames.Yaw: Rotation.Yaw = v; break;
                        case Euler3f.DisplayNames.Roll: Rotation.Roll = v; break;
                    }
                    break;
            }
        }

        public Camera(float x, float y, float z, float pitch, float yaw, float roll) :
            this(new Vector3f(x, y, z), new Euler3f(pitch, yaw, roll))
        { }

        #endregion

        #region Public Properties

        [Description(Descriptions.Position)]
        [DisplayName(DisplayNames.Position)]
        [TypeConverter(typeof(Vector3fTypeConverter))]
        public Vector3f Position { get; set; } = new Vector3f();

        [Description(Descriptions.Rotation)]
        [DisplayName(DisplayNames.Rotation)]
        [TypeConverter(typeof(Euler3fTypeConverter))]
        public Euler3f Rotation { get; set; } = new Euler3f();

        #endregion

        #region Public Operators

        public static bool operator ==(Camera p, Camera q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Camera p, Camera q) => !(p == q);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) =>
            obj is Camera c && c.Position == Position && c.Rotation == Rotation;

        public void Fix()
        {
            HomePosition = Position;
            HomeRotation = Rotation;
        }

        public override int GetHashCode() => Position.GetHashCode() ^ Rotation.GetHashCode();

        public static Camera Parse(string s)
        {
            var t = s.Split(',');
            return new Camera(
                new Vector3f(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2])),
                new Euler3f(float.Parse(t[3]), float.Parse(t[4]), float.Parse(t[5])));
        }

        public void Reset()
        {
            Position = HomePosition;
            Rotation = HomeRotation;
        }

        public override string ToString() => $"{Position}, {Rotation}";

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            internal const string
                Position = "A vector representing the Camera's position.",
                Rotation = "A rotation representing the Camera's orientation.";
        }

        internal static class DisplayNames
        {
            internal const string
                Position = "Position",
                Rotation = "Rotation°";
        }

        #endregion

        #region Private Properties

        private Vector3f HomePosition;
        private Euler3f HomeRotation;

        #endregion
    }
}
