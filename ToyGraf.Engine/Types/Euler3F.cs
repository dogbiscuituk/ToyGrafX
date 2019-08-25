namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(Euler3FTypeConverter))]
    public class Euler3F
    {
        #region Constructors

        public Euler3F() : this(0, 0, 0) { }

        public Euler3F(Euler3F p) : this(p.Pitch, p.Yaw, p.Roll) { }

        public Euler3F(Euler3F p, string fieldName, float value) : this(p)
        {
            switch (fieldName)
            {
                case "Pitch": Pitch = value; break;
                case "Yaw": Yaw = value; break;
                case "Roll": Roll = value; break;
            }
        }

        public Euler3F(float pitch, float yaw, float roll)
        {
            Pitch = pitch;
            Yaw = yaw;
            Roll = roll;
        }

        #endregion

        #region Public Properties

        [DefaultValue(0f)]
        [Description(Descriptions.Pitch)]
        public float Pitch { get; set; }

        [DefaultValue(0f)]
        [Description(Descriptions.Yaw)]
        public float Yaw { get; set; }

        [DefaultValue(0f)]
        [Description(Descriptions.Roll)]
        public float Roll { get; set; }

        public static Euler3F Zero = new Euler3F();

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Euler3F p &&
            p.Pitch == Pitch && p.Yaw == Yaw && p.Roll == Roll;
        public override int GetHashCode() => Pitch.GetHashCode() ^ Yaw.GetHashCode() ^ Roll.GetHashCode();
        public override string ToString() => $"{Pitch}, {Yaw}, {Roll}";

        public static Euler3F Parse(string s)
        {
            var t = s.Split(',');
            return new Euler3F(float.Parse(t[0]), float.Parse(t[1]), float.Parse(t[2]));
        }

        #endregion

        #region Private Classes

        private class Descriptions
        {
            public const string
                Pitch = "The component of rotation about the X axis.",
                Roll = "The component of rotation about the Z axis.",
                Yaw = "The component of rotation about the Y axis.";
        }

        #endregion
    }
}
