namespace ToyGraf.Common.Types
{
    using Newtonsoft.Json;
    using System.ComponentModel;
    using ToyGraf.Common.TypeConverters;

    [TypeConverter(typeof(CameraTypeConverter))]
    public class Camera
    {
        #region Constructors

        public Camera() : this(Defaults.Position, Defaults.Focus) { }
        public Camera(Camera camera) : this(camera.Position, camera.Focus) { }

        public Camera(Vector3f position, Vector3f focus)
        {
            Position = new Vector3f(position);
            Focus = new Vector3f(focus);
        }

        public Camera(Camera camera, string field, object value) : this(camera)
        {
            switch (field)
            {
                case DisplayNames.Focus:
                    Focus = (Vector3f)value;
                    return;
                case DisplayNames.Position:
                    Position = (Vector3f)value;
                    return;
            }
            var v = (float)value;
            var fields = field.Split('.');
            switch (fields[0])
            {
                case DisplayNames.Focus:
                    switch (fields[1])
                    {
                        case Vector3f.DisplayNames.X: Focus.X = v; break;
                        case Vector3f.DisplayNames.Y: Focus.Y = v; break;
                        case Vector3f.DisplayNames.Z: Focus.Z = v; break;
                    }
                    break;
                case DisplayNames.Position:
                    switch (fields[1])
                    {
                        case Vector3f.DisplayNames.X: Position.X = v; break;
                        case Vector3f.DisplayNames.Y: Position.Y = v; break;
                        case Vector3f.DisplayNames.Z: Position.Z = v; break;
                    }
                    break;
            }
        }

        public Camera(float x, float y, float z, float u, float v, float w) :
            this(new Vector3f(x, y, z), new Vector3f(u, v, w))
        { }

        #endregion

        #region Public Properties

        [Description(Descriptions.Focus)]
        [DisplayName(DisplayNames.Focus)]
        [TypeConverter(typeof(Vector3fTypeConverter))]
        public Vector3f Focus { get; set; } = new Vector3f();

        [Description(Descriptions.Position)]
        [DisplayName(DisplayNames.Position)]
        [TypeConverter(typeof(Vector3fTypeConverter))]
        public Vector3f Position { get; set; } = new Vector3f();

        [Browsable(false)]
        [JsonIgnore]
        public Vector3f Ufront => (Focus - Position).Normalize();

        [Browsable(false)]
        [JsonIgnore]
        public Vector3f Uright => Ufront.Cross(Uup).Normalize();

        [Browsable(false)]
        [JsonIgnore]
        public Vector3f Uup => new Vector3f(0, 1, 0);

        #endregion

        #region Public Operators

        public static bool operator ==(Camera p, Camera q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Camera p, Camera q) => !(p == q);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Camera c && c.Position == Position && c.Focus == Focus;

        public void Fix()
        {
            HomeFocus = Focus;
            HomePosition = Position;
        }

        public override int GetHashCode() => Focus.GetHashCode() ^ Position.GetHashCode();

        public static Camera Parse(string s)
        {
            var t = s.Split(',');
            return new Camera(
                new Vector3f(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2])),
                new Vector3f(float.Parse(t[3]), float.Parse(t[4]), float.Parse(t[5])));
        }

        public void Reset()
        {
            Focus = HomeFocus;
            Position = HomePosition;
        }

        public override string ToString() => $"{Position}, {Focus}";

        #endregion

        #region Nested Classes

        public static class Defaults
        {
            public static Vector3f
                Focus = new Vector3f(),
                Position = new Vector3f(0, 0, 2);
        }

        internal static class Descriptions
        {
            internal const string
                Focus = "A vector representing the fixed point target of the camera",
                Position = "A vector representing the camera's position.";
        }

        internal static class DisplayNames
        {
            internal const string
                Focus = "Focus",
                Position = "Position";
        }

        #endregion

        #region Private Properties

        private Vector3f
            HomeFocus,
            HomePosition;

        #endregion
    }
}
