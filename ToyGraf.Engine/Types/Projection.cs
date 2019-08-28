namespace ToyGraf.Engine.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(ProjectionTypeConverter))]
    public class Projection
    {
        #region Constructors

        public Projection(ProjectionType projectionType, float fieldOfView, Point3F frustrumMin, Point3F frustrumMax)
        {
            ProjectionType = projectionType;
            FieldOfView = fieldOfView;
            FrustrumMin = new Point3F(frustrumMin);
            FrustrumMax = new Point3F(frustrumMax);
        }

        public Projection(Projection projection) :
            this(projection.ProjectionType, projection.FieldOfView, projection.FrustrumMin, projection.FrustrumMax)
        { }

        public Projection(float width, float height, float near, float far)
        {
            ProjectionType = ProjectionType.Orthographic;
            Width = width;
            Height = height;
            Near = near;
            Far = far;
        }

        public Projection(float fieldOfView, float width, float height, float near, float far)
        {
            ProjectionType = ProjectionType.Perspective;
            FieldOfView = fieldOfView;
            Width = width;
            Height = height;
            Near = near;
            Far = far;
        }

        public Projection(ProjectionType projectionType, float left, float right, float bottom, float top, float near, float far)
        {
            ProjectionType = projectionType;
            FrustrumMin = new Point3F(left, bottom, near);
            FrustrumMax = new Point3F(right, top, far);
        }

        public Projection(Projection projection, string field, object value) : this(projection)
        {
            switch (field)
            {
                case DisplayNames.ProjectionType:
                    ProjectionType = (ProjectionType)value;
                    return;
                case DisplayNames.FieldOfView:
                    FieldOfView = (float)value;
                    return;
                case DisplayNames.FrustrumMin:
                    FrustrumMin = (Point3F)value;
                    return;
                case DisplayNames.FrustrumMax:
                    FrustrumMax = (Point3F)value;
                    return;
            }
            var v = (float)value;
            var fields = field.Split('.');
            switch (fields[0])
            {
                case DisplayNames.FrustrumMin:
                    switch (fields[1])
                    {
                        case Point3F.DisplayNames.X: FrustrumMin.X = v; break;
                        case Point3F.DisplayNames.Y: FrustrumMin.Y = v; break;
                        case Point3F.DisplayNames.Z: FrustrumMin.Z = v; break;
                    }
                    break;
                case DisplayNames.FrustrumMax:
                    switch (fields[1])
                    {
                        case Point3F.DisplayNames.X: FrustrumMax.X = v; break;
                        case Point3F.DisplayNames.Y: FrustrumMax.Y = v; break;
                        case Point3F.DisplayNames.Z: FrustrumMax.Z = v; break;
                    }
                    break;
            }

            Point3F p = fields[0] == DisplayNames.FrustrumMin ? FrustrumMin : FrustrumMax;
            switch (fields[1])
            {
                case Point3F.DisplayNames.X: p.X = v; break;
                case Point3F.DisplayNames.Y: p.Y = v; break;
                case Point3F.DisplayNames.Z: p.Z = v; break;
            }
            switch (fields[0])
            {
                case DisplayNames.FrustrumMin:
                    FrustrumMin = p;
                    break;
                case DisplayNames.FrustrumMax:
                    FrustrumMax = p;
                    break;
            }
        }

        #endregion

        #region Public Properties

        [Description(Descriptions.FieldOfView)]
        [DisplayName(DisplayNames.FieldOfView)]
        public float FieldOfView { get; set; }

        [Description(Descriptions.FrustrumMax)]
        [DisplayName(DisplayNames.FrustrumMax)]
        public Point3F FrustrumMax { get; set; } = new Point3F();

        [Description(Descriptions.FrustrumMin)]
        [DisplayName(DisplayNames.FrustrumMin)]
        public Point3F FrustrumMin { get; set; } = new Point3F();

        [Description(Descriptions.ProjectionType)]
        [DisplayName(DisplayNames.ProjectionType)]
        public ProjectionType ProjectionType { get; set; }

        [Browsable(false)] public float Bottom { get => FrustrumMin.Y; set => FrustrumMin.Y = value; }
        [Browsable(false)] public float Depth { get => Far - Near; set { Far = Near + value; } }
        [Browsable(false)] public float Far { get => FrustrumMax.Z; set => FrustrumMax.Z = value; }
        [Browsable(false)] public float Height { get => Top - Bottom; set { Top = value / 2; Bottom = -Top; } }
        [Browsable(false)] public float Left { get => FrustrumMin.X; set => FrustrumMin.X = value; }
        [Browsable(false)] public float Near { get => FrustrumMin.Z; set => FrustrumMin.Z = value; }
        [Browsable(false)] public float Right { get => FrustrumMax.X; set => FrustrumMax.X = value; }
        [Browsable(false)] public float Top { get => FrustrumMax.Y; set => FrustrumMax.Y = value; }
        [Browsable(false)] public float Width { get => Right - Left; set { Right = value / 2; Left = -Right; } }

        #endregion

        #region Public Methods

        public override string ToString() => $"{ProjectionType}, {FieldOfView}, {FrustrumMin}, {FrustrumMax}";

        public static Projection Parse(string s)
        {
            var t = s.Split(',');
            return new Projection(
                (ProjectionType)Enum.Parse(typeof(ProjectionType), t[0]),
                float.Parse(t[1]),
                new Point3F(float.Parse(t[2]), float.Parse(t[3]), float.Parse(t[4])),
                new Point3F(float.Parse(t[5]), float.Parse(t[6]), float.Parse(t[7])));
        }

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            internal const string
                FieldOfView = "Field of View (total yaw, in degrees)",
                FrustrumMax = "A vector representing the far top right corner of the frustrum.",
                FrustrumMin = "A vector representing the near bottom left corner of the frustrum.",
                ProjectionType = "The type of projection to use.";
        }

        internal static class DisplayNames
        {
            internal const string
                FieldOfView = "Field of View Yaw°",
                FrustrumMax = "Frustrum Max",
                FrustrumMin = "Frustrum Min",
                ProjectionType = "Projection Type";
        }

        #endregion
    }
}
