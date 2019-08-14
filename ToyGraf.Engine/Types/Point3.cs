namespace ToyGraf.Engine.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Point3TypeConverter))]
    public class Point3
    {
        public Point3() : this(0, 0, 0) { }

        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override bool Equals(object obj) => obj is Point3 p && p.X == X && p.Y == Y && p.Z == Z;
        public override int GetHashCode() => X ^ Y ^ Z;
        public override string ToString() => $"(X: {X}, Y: {Y}, Z: {Z})";

        public static Point3 Parse(string s)
        {
            var t = s.Split(new[] { "(X: ", ", Y: ", ", Z: ", ")" },
                StringSplitOptions.RemoveEmptyEntries);
            return new Point3(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
        }
    }
}
