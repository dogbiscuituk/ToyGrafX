namespace ToyGraf.Common.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Common.TypeConverters;

    [TypeConverter(typeof(ProjectionTypeConverter))]
    public class Projection
    {
        #region Constructors

        public Projection(ProjectionType projectionType, float fieldOfView, Vector3f frustumMin, Vector3f frustumMax)
        {
            ProjectionType = projectionType;
            FieldOfView = fieldOfView;
            FrustumMin = new Vector3f(frustumMin);
            FrustumMax = new Vector3f(frustumMax);
        }

        public Projection(Projection projection) :
            this(projection.ProjectionType, projection.FieldOfView, projection.FrustumMin, projection.FrustumMax)
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
            FrustumMin = new Vector3f(left, bottom, near);
            FrustumMax = new Vector3f(right, top, far);
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
                case DisplayNames.FrustumMin:
                    FrustumMin = new Vector3f((Vector3f)value);
                    return;
                case DisplayNames.FrustumMax:
                    FrustumMax = new Vector3f((Vector3f)value);
                    return;
            }
            var v = (float)value;
            var fields = field.Split('.');
            var p = fields[0] == DisplayNames.FrustumMin ? FrustumMin : FrustumMax;
            switch (fields[1])
            {
                case Vector3f.DisplayNames.X: p.X = v; break;
                case Vector3f.DisplayNames.Y: p.Y = v; break;
                case Vector3f.DisplayNames.Z: p.Z = v; break;
            }
            switch (fields[0])
            {
                case DisplayNames.FrustumMin:
                    FrustumMin = p;
                    break;
                case DisplayNames.FrustumMax:
                    FrustumMax = p;
                    break;
            }
        }

        #endregion

        #region Public Properties

        [Description(Descriptions.FieldOfView)]
        [DisplayName(DisplayNames.FieldOfView)]
        public float FieldOfView { get; set; }

        [Description(Descriptions.FrustumMax)]
        [DisplayName(DisplayNames.FrustumMax)]
        public Vector3f FrustumMax { get; set; } = new Vector3f();

        [Description(Descriptions.FrustumMin)]
        [DisplayName(DisplayNames.FrustumMin)]
        public Vector3f FrustumMin { get; set; } = new Vector3f();

        [Description(Descriptions.ProjectionType)]
        [DisplayName(DisplayNames.ProjectionType)]
        public ProjectionType ProjectionType { get; set; }

        [Browsable(false)] public float Bottom { get => FrustumMin.Y; set => FrustumMin.Y = value; }
        [Browsable(false)] public float Depth { get => Far - Near; set { Far = Near + value; } }
        [Browsable(false)] public float Far { get => FrustumMax.Z; set => FrustumMax.Z = value; }
        [Browsable(false)] public float Height { get => Top - Bottom; set { Top = value / 2; Bottom = -Top; } }
        [Browsable(false)] public float Left { get => FrustumMin.X; set => FrustumMin.X = value; }
        [Browsable(false)] public float Near { get => FrustumMin.Z; set => FrustumMin.Z = value; }
        [Browsable(false)] public float Right { get => FrustumMax.X; set => FrustumMax.X = value; }
        [Browsable(false)] public float Top { get => FrustumMax.Y; set => FrustumMax.Y = value; }
        [Browsable(false)] public float Width { get => Right - Left; set { Right = value / 2; Left = -Right; } }

        #endregion

        #region Public Operators

        public static bool operator ==(Projection p, Projection q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Projection p, Projection q) => !(p == q);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Projection p
            && p.ProjectionType == ProjectionType
            && p.FieldOfView == FieldOfView
            && p.FrustumMin == FrustumMin
            && p.FrustumMax == FrustumMax;

        public override int GetHashCode() =>
            (int)ProjectionType ^ FieldOfView.GetHashCode() ^ FrustumMin.GetHashCode() ^ FrustumMax.GetHashCode();

        public static Projection Parse(string s)
        {
            var t = s.Split(',');
            return new Projection(
                (ProjectionType)Enum.Parse(typeof(ProjectionType), t[0]),
                float.Parse(t[1]),
                new Vector3f(float.Parse(t[2]), float.Parse(t[3]), float.Parse(t[4])),
                new Vector3f(float.Parse(t[5]), float.Parse(t[6]), float.Parse(t[7])));
        }

        public override string ToString() => $"{ProjectionType}, {FieldOfView}, {FrustumMin}, {FrustumMax}";

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            internal const string
                FieldOfView = @"Field of View (total yaw, in degrees). Used only in the Perspective projection type. 
This value is combined with the current display aspect ratio, and the Near and Far planes (Z components of the Frustum Min/Max), to generate the projection frustum.",
                FrustumMax = @"A vector representing the far top right corner of the projection frustum. 
The X and Y components are used in all projection types except Perspective. The Z component is used in all projection types, and always represents the Far plane.",
                FrustumMin = @"A vector representing the near bottom left corner of the projection frustum. 
The X and Y components are used in all projection types except Perspective. The Z component is used in all projection types, and always represents the Near plane.",
                ProjectionType = @"The type of projection frustum in use. The way this is constructed, and its final shape, depend on the Projection Type as follows:
* Orthographic: the cuboidal frustum width and height are derived from the X and Y differences respectively between Frustum Min/Max. As always, the Z components determine the Near and Far planes. 
* Orthographic Offset: the Frustum Min/Max alone determine the extents of the frustum, which is cuboidal. 
* Perspective: the Field of View (total yaw, in degrees) is combined with the current display aspect ratio, and the Near and Far planes (Z components of the Frustum Min/Max). 
* Perspective Offset: the Frustum Min/Max alone determine the extents of the frustum.";
        }

        internal static class DisplayNames
        {
            internal const string
                FieldOfView = "Field of View Yaw°",
                FrustumMax = "Frustum Max",
                FrustumMin = "Frustum Min",
                ProjectionType = "Projection Type";
        }

        #endregion
    }
}
