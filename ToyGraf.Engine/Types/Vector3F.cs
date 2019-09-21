namespace ToyGraf.Engine.Types
{
    using OpenTK;
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Vector3fTypeConverter))]
    public class Vector3f
    {
        #region Constructors

        public Vector3f() : this(0, 0, 0) { }

        public Vector3f(Vector3f p) : this(p.X, p.Y, p.Z) { }

        public Vector3f(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3f(Vector3f p, string fieldName, float value) : this(p)
        {
            switch (fieldName)
            {
                case DisplayNames.X: X = value; break;
                case DisplayNames.Y: Y = value; break;
                case DisplayNames.Z: Z = value; break;
            }
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

        [Browsable(false)]
        public float Norm => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        #endregion

        #region Public Operators

        public static bool operator ==(Vector3f p, Vector3f q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Vector3f p, Vector3f q) => !(p == q);

        public static Vector3f operator -(Vector3f p) => new Vector3f(-p.X, -p.Y, -p.Z);
        public static Vector3f operator +(Vector3f p, Vector3f q) => new Vector3f(p.X + q.X, p.Y + q.Y, p.Z + q.Z);
        public static Vector3f operator -(Vector3f p, Vector3f q) => new Vector3f(p.X - q.X, p.Y - q.Y, p.Z - q.Z);
        public static Vector3f operator *(Vector3f p, float q) => new Vector3f(p.X * q, p.Y * q, p.Z * q);
        public static Vector3f operator *(float p, Vector3f q) => new Vector3f(p * q.X, p * q.Y, p * q.Z);
        public static Vector3f operator /(Vector3f p, float q) => new Vector3f(p.X / q, p.Y / q, p.Z / q);

        public static implicit operator Vector3(Vector3f p) => new Vector3(p.X, p.Y, p.Z);
        public static implicit operator Vector3f(Vector3 p) => new Vector3f(p.X, p.Y, p.Z);

        #endregion

        #region Public Methods

        public Vector3f Cross(Vector3f p) =>
            new Vector3f(Y * p.Z - Z * p.Y, Z * p.X - X * p.Z, X * p.Y - Y * p.X);

        public float Dot(Vector3f p) => X * p.X + Y * p.Y + Z * p.Z;

        public override bool Equals(object obj) => obj is Vector3f p && p.X == X && p.Y == Y && p.Z == Z;

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

        public Vector3f Normalize()
        {
            if (X == 0 && Y == 0 && Z == 0)
                return new Vector3f(this);
            var length = Norm;
            return new Vector3f(X / length, Y / length, Z / length);
        }

        public static Vector3f Parse(string s)
        {
            var t = s.Split(',');
            return new Vector3f(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
        }

        public override string ToString() => $"{X}, {Y}, {Z}";

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
