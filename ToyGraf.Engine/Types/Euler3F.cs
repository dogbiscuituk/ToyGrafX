namespace ToyGraf.Engine.Types
{
    using OpenTK;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Euler3fTypeConverter))]
    public class Euler3f
    {
        #region Constructors

        public Euler3f() : this(0, 0, 0) { }

        public Euler3f(Euler3f p) : this(p.Pitch, p.Yaw, p.Roll) { }

        public Euler3f(Euler3f p, string fieldName, float value) : this(p)
        {
            switch (fieldName)
            {
                case DisplayNames.Pitch: Pitch = value; break;
                case DisplayNames.Yaw: Yaw = value; break;
                case DisplayNames.Roll: Roll = value; break;
            }
        }

        public Euler3f(float pitch, float yaw, float roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }

        #endregion

        #region Public Properties

        [DefaultValue(0f)]
        [Description(Descriptions.Pitch)]
        [DisplayName(DisplayNames.Pitch)]
        public float Pitch { get; set; }

        [DefaultValue(0f)]
        [Description(Descriptions.Yaw)]
        [DisplayName(DisplayNames.Yaw)]
        public float Yaw { get; set; }

        [DefaultValue(0f)]
        [Description(Descriptions.Roll)]
        [DisplayName(DisplayNames.Roll)]
        public float Roll { get; set; }

        #endregion

        #region Public Operators

        public static bool operator ==(Euler3f p, Euler3f q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Euler3f p, Euler3f q) => !(p == q);

        public static Euler3f operator -(Euler3f p) => new Euler3f(-p.Pitch, -p.Yaw, -p.Roll);
        public static Euler3f operator +(Euler3f p, Euler3f q) => new Euler3f(p.Pitch + q.Pitch, p.Yaw + q.Yaw, p.Roll + q.Roll);
        public static Euler3f operator -(Euler3f p, Euler3f q) => new Euler3f(p.Pitch - q.Pitch, p.Yaw - q.Yaw, p.Roll - q.Roll);

        public static implicit operator Euler3f(Vector3 p) => new Euler3f(p.X, p.Y, p.Z);
        public static implicit operator Euler3f(Quaternion p) => new Euler3f(p.X, p.Y, p.Z);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Euler3f p &&
            p.Pitch == Pitch && p.Yaw == Yaw && p.Roll == Roll;

        public override int GetHashCode() => Pitch.GetHashCode() ^ Yaw.GetHashCode() ^ Roll.GetHashCode();

        public static Euler3f Parse(string s)
        {
            var t = s.Split(',');
            return new Euler3f(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
        }

        public override string ToString() => $"{Pitch}, {Yaw}, {Roll}";

        public Vector3 ToVector3() => new Vector3(Pitch, Yaw, Roll);

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            internal const string
                Pitch = "The component of rotation about the X axis.",
                Roll = "The component of rotation about the Z axis.",
                Yaw = "The component of rotation about the Y axis.";
        }

        internal static class DisplayNames
        {
            internal const string
                Pitch = "Pitch°",
                Roll = "Roll°",
                Yaw = "Yaw°";
        }

        #endregion
    }
}
