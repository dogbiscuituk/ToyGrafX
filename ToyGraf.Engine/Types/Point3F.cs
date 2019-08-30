namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Point3FTypeConverter))]
    public class Point3F
    {
        #region Constructors

        public Point3F() : this(0, 0, 0) { }

        public Point3F(Point3F p) : this(p.X, p.Y, p.Z) { }

        public Point3F(Point3F p, string fieldName, float value) : this(p)
        {
            switch (fieldName)
            {
                case DisplayNames.X: X = value; break;
                case DisplayNames.Y: Y = value; break;
                case DisplayNames.Z: Z = value; break;
            }
        }

        public Point3F(float x, float y, float z)
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

        public static Point3F Zero = new Point3F();

        #endregion

        #region Public Operators

        public static bool operator ==(Point3F p, Point3F q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Point3F p, Point3F q) => !(p == q);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Point3F p && p.X == X && p.Y == Y && p.Z == Z;
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        public override string ToString() => $"{X}, {Y}, {Z}";

        public static Point3F Parse(string s)
        {
            var t = s.Split(',');
            return new Point3F(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
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
