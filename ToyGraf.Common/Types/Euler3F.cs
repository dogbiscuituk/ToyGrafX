namespace ToyGraf.Common.Types
{
    using OpenTK;
    using System.ComponentModel;
    using ToyGraf.Common.TypeConverters;

    [TypeConverter(typeof(Euler3fTypeConverter))]
    public class Euler3f
    {
        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Euler3f() : this(0, 0, 0) { }

        /// <summary>
        /// General Constructor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Euler3f(float pitch, float yaw, float roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }

        /// <summary>
        /// Copy Constructor.
        /// </summary>
        /// <param name="p"></param>
        public Euler3f(Euler3f p) : this(p.Pitch, p.Yaw, p.Roll) { }

        /// <summary>
        /// Copy & Modify Constructor.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public Euler3f(Euler3f p, string fieldName, float value) : this(p)
        {
            switch (fieldName)
            {
                case DisplayNames.Pitch: Pitch = value; break;
                case DisplayNames.Yaw: Yaw = value; break;
                case DisplayNames.Roll: Roll = value; break;
            }
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
        public static Euler3f operator *(Euler3f p, float q) => new Euler3f(p.Pitch * q, p.Yaw * q, p.Roll * q);
        public static Euler3f operator *(float p, Euler3f q) => new Euler3f(p * q.Pitch, p * q.Yaw, p * q.Roll);
        public static Euler3f operator /(Euler3f p, float q) => new Euler3f(p.Pitch / q, p.Yaw / q, p.Roll / q);

        public static implicit operator Euler3f(Vector3 p) => new Euler3f(p.X, p.Y, p.Z);
        public static implicit operator Euler3f(Quaternion p) => new Euler3f(p.X, p.Y, p.Z);
        public static implicit operator Vector3(Euler3f p) => new Vector3(p.Pitch, p.Yaw, p.Roll);

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

        #endregion

        #region Nested Classes

        private static class Descriptions
        {
            internal const string
                Pitch = "The component of rotation about the X axis (degrees).",
                Roll = "The component of rotation about the Z axis (degrees).",
                Yaw = "The component of rotation about the Y axis (degrees).";
        }

        public static class DisplayNames
        {
            public const string
                Pitch = "Pitch°",
                Roll = "Roll°",
                Yaw = "Yaw°";
        }

        #endregion
    }
}
