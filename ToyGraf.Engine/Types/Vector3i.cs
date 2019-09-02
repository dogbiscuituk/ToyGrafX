namespace ToyGraf.Engine.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Vector3iTypeConverter))]
    public class Vector3i
    {
        #region Constructors

        public Vector3i() : this(0, 0, 0) { }

        public Vector3i(Vector3i p) : this(p.X, p.Y, p.Z) { }

        public Vector3i(Vector3i p, string fieldName, int value) : this(p)
        {
            switch (fieldName)
            {
                case DisplayNames.X: X = value; break;
                case DisplayNames.Y: Y = value; break;
                case DisplayNames.Z: Z = value; break;
            }
        }

        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Public Properties

        [DefaultValue(0)]
        [Description(Descriptions.X)]
        [DisplayName(DisplayNames.X)]
        public int X { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Y)]
        [DisplayName(DisplayNames.Y)]
        public int Y { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Z)]
        [DisplayName(DisplayNames.Z)]
        public int Z { get; set; }

        [Browsable(false)]
        public float Length => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        #endregion

        #region Public Operators

        public static bool operator ==(Vector3i p, Vector3i q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Vector3i p, Vector3i q) => !(p == q);

        public static Vector3i operator -(Vector3i p) => new Vector3i(-p.X, -p.Y, -p.Z);
        public static Vector3i operator +(Vector3i p, Vector3i q) => new Vector3i(p.X + q.X, p.Y + q.Y, p.Z + q.Z);
        public static Vector3i operator -(Vector3i p, Vector3i q) => new Vector3i(p.X - q.X, p.Y - q.Y, p.Z - q.Z);
        public static Vector3i operator *(Vector3i p, int q) => new Vector3i(p.X * q, p.Y * q, p.Z * q);
        public static Vector3i operator *(int p, Vector3i q) => new Vector3i(p * q.X, p * q.Y, p * q.Z);

        public static implicit operator Vector3f(Vector3i p) => new Vector3f(p.X, p.Y, p.Z);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Vector3i p && p.X == X && p.Y == Y && p.Z == Z;
        public override int GetHashCode() => X ^ Y ^ Z;

        public Vector3f Normalize()
        {
            if (X == 0 && Y == 0 && Z == 0)
                return new Vector3f(this);
            var length = Length;
            return new Vector3f(X / length, Y / length, Z / length);
        }

        public static Vector3i Parse(string s)
        {
            var t = s.Split(',');
            return new Vector3i(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
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
