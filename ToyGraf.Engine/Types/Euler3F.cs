namespace ToyGraf.Engine.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Euler3FTypeConverter))]
    public class Euler3F
    {
        public Euler3F() : this(0, 0, 0) { }

        public Euler3F(float pitch, float yaw, float roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }

        public float Pitch { get; set; }
        public float Yaw { get; set; }
        public float Roll { get; set; }

        public override bool Equals(object obj) => obj is Euler3F p &&
            p.Pitch == Pitch && p.Yaw == Yaw && p.Roll == Roll;
        public override int GetHashCode() => Pitch.GetHashCode() ^ Yaw.GetHashCode() ^ Roll.GetHashCode();
        public override string ToString() => $"(Pitch: {Pitch}, Yaw: {Yaw}, Roll: {Roll})";

        public static Euler3F Parse(string s)
        {
            var t = s.Split(new[] { "(Pitch: ", ", Yaw: ", ", Roll: ", ")" },
                StringSplitOptions.RemoveEmptyEntries);
            return new Euler3F(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
        }
    }
}
