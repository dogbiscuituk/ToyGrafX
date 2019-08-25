namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Point3TypeConverter))]
    public class Point3
    {
        #region Constructors

        public Point3() : this(0, 0, 0) { }

        public Point3(Point3 p) : this(p.X, p.Y, p.Z) { }

        public Point3(Point3 p, string fieldName, int value) : this(p)
        {
            switch (fieldName)
            {
                case "X": X = value; break;
                case "Y": Y = value; break;
                case "Z": Z = value; break;
            }
        }

        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Public Properties

        [DefaultValue(0)]
        [Description(Descriptions.X)]
        public int X { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Y)]
        public int Y { get; set; }

        [DefaultValue(0)]
        [Description(Descriptions.Z)]
        public int Z { get; set; }

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Point3 p && p.X == X && p.Y == Y && p.Z == Z;
        public override int GetHashCode() => X ^ Y ^ Z;
        public override string ToString() => $"{X}, {Y}, {Z}";

        public static Point3 Parse(string s)
        {
            var t = s.Split(',');
            return new Point3(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
        }

        #endregion

        #region Private Classes

        private class Descriptions
        {
            public const string
                X = "The X component of the vector.",
                Y = "The Y component of the vector.",
                Z = "The Z component of the vector.";
        }

        #endregion
    }
}
