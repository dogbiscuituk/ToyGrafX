namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Vector3fTypeConverter))]
    public class Vector3f
    {
        #region Constructors

        public Vector3f() : this(0, 0, 0) { }

        public Vector3f(Vector3f p) : this(p.X, p.Y, p.Z) { }

        public Vector3f(Vector3f p, string fieldName, float value) : this(p)
        {
            switch (fieldName)
            {
                case DisplayNames.X: X = value; break;
                case DisplayNames.Y: Y = value; break;
                case DisplayNames.Z: Z = value; break;
            }
        }

        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Public Properties

        [DefaultValue(0f)]
        [Description(Descriptions.X)]
        [DisplayName(DisplayNames.X)]
        public float X { get; set; }

        [DefaultValue(0f)]
        [Description(Descriptions.Y)]
        [DisplayName(DisplayNames.Y)]
        public float Y { get; set; }

        [DefaultValue(0f)]
        [Description(Descriptions.Z)]
        [DisplayName(DisplayNames.Z)]
        public float Z { get; set; }

        public static Vector3f Zero = new Vector3f();

        #endregion

        #region Public Operators

        public static bool operator ==(Vector3f p, Vector3f q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Vector3f p, Vector3f q) => !(p == q);
        public static Vector3f operator -(Vector3f p) => new Vector3f(-p.X, -p.Y, -p.Z);
        public static Vector3f operator +(Vector3f p, Vector3f q) => new Vector3f(p.X + q.X, p.Y + q.Y, p.Z + q.Z);
        public static Vector3f operator -(Vector3f p, Vector3f q) => new Vector3f(p.X - q.X, p.Y - q.Y, p.Z - q.Z);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Vector3f p && p.X == X && p.Y == Y && p.Z == Z;
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        public override string ToString() => $"{X}, {Y}, {Z}";

        public static Vector3f Parse(string s)
        {
            var t = s.Split(',');
            return new Vector3f(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
        }

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            public const string
                X = "The X component of the vector.",
                Y = "The Y component of the vector.",
                Z = "The Z component of the vector.";
        }

        internal static class DisplayNames
        {
            public const string
                X = "X",
                Y = "Y",
                Z = "Z";
        }

        #endregion
    }
}
