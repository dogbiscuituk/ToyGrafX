namespace ToyGraf.Engine.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Point3FTypeConverter))]
    public class Point3F
    {
        public Point3F() : this(0, 0, 0) { }

        public Point3F(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public override bool Equals(object obj) => obj is Point3F p && p.X == X && p.Y == Y && p.Z == Z;
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        public override string ToString() => $"(X: {X}, Y: {Y}, Z: {Z})";

        public static Point3F Parse(string s)
        {
            var t = s.Split(new[] { "(X: ", ", Y: ", ", Z: ", ")" },
                StringSplitOptions.RemoveEmptyEntries);
            return new Point3F(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
        }
    }
}
