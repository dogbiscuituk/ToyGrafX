namespace ToyGraf.Engine.Types
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(ProjectionTypeConverter))]
    public class Projection
    {
        #region Constructors

        public Projection(ProjectionType projectionType, float fieldOfView, Vector3f frustrumMin, Vector3f frustrumMax)
        {
            ProjectionType = projectionType;
            FieldOfView = fieldOfView;
            FrustrumMin = new Vector3f(frustrumMin);
            FrustrumMax = new Vector3f(frustrumMax);
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
            FrustrumMin = new Vector3f(left, bottom, near);
            FrustrumMax = new Vector3f(right, top, far);
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
                    FrustrumMin = (Vector3f)value;
                    return;
                case DisplayNames.FrustrumMax:
                    FrustrumMax = (Vector3f)value;
                    return;
            }
            var v = (float)value;
            var fields = field.Split('.');
            switch (fields[0])
            {
                case DisplayNames.FrustrumMin:
                    switch (fields[1])
                    {
                        case Vector3f.DisplayNames.X: FrustrumMin.X = v; break;
                        case Vector3f.DisplayNames.Y: FrustrumMin.Y = v; break;
                        case Vector3f.DisplayNames.Z: FrustrumMin.Z = v; break;
                    }
                    break;
                case DisplayNames.FrustrumMax:
                    switch (fields[1])
                    {
                        case Vector3f.DisplayNames.X: FrustrumMax.X = v; break;
                        case Vector3f.DisplayNames.Y: FrustrumMax.Y = v; break;
                        case Vector3f.DisplayNames.Z: FrustrumMax.Z = v; break;
                    }
                    break;
            }

            Vector3f p = fields[0] == DisplayNames.FrustrumMin ? FrustrumMin : FrustrumMax;
            switch (fields[1])
            {
                case Vector3f.DisplayNames.X: p.X = v; break;
                case Vector3f.DisplayNames.Y: p.Y = v; break;
                case Vector3f.DisplayNames.Z: p.Z = v; break;
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
        public Vector3f FrustrumMax { get; set; } = new Vector3f();

        [Description(Descriptions.FrustrumMin)]
        [DisplayName(DisplayNames.FrustrumMin)]
        public Vector3f FrustrumMin { get; set; } = new Vector3f();

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

        #region Public Operators

        public static bool operator ==(Projection p, Projection q) => p is null ? q is null : p.Equals(q);
        public static bool operator !=(Projection p, Projection q) => !(p == q);

        #endregion

        #region Public Methods

        public override bool Equals(object obj) => obj is Projection p
            && p.ProjectionType == ProjectionType
            && p.FieldOfView == FieldOfView
            && p.FrustrumMin == FrustrumMin
            && p.FrustrumMax == FrustrumMax;

        public override int GetHashCode() =>
            (int)ProjectionType ^ FieldOfView.GetHashCode() ^ FrustrumMin.GetHashCode() ^ FrustrumMax.GetHashCode();

        public static Projection Parse(string s)
        {
            var t = s.Split(',');
            return new Projection(
                (ProjectionType)Enum.Parse(typeof(ProjectionType), t[0]),
                float.Parse(t[1]),
                new Vector3f(float.Parse(t[2]), float.Parse(t[3]), float.Parse(t[4])),
                new Vector3f(float.Parse(t[5]), float.Parse(t[6]), float.Parse(t[7])));
        }

        public override string ToString() => $"{ProjectionType}, {FieldOfView}, {FrustrumMin}, {FrustrumMax}";

        #endregion

        #region Internal Classes

        internal static class Descriptions
        {
            internal const string
                FieldOfView = @"Field of View (total yaw, in degrees). Used only in the Perspective projection type. 
This value is combined with the current display aspect ratio, and the Near and Far planes (Z components of the Frustrum Min/Max), to generate the projection frustrum.",
                FrustrumMax = @"A vector representing the far top right corner of the projection frustrum. 
The X and Y components are used in all projection types except Perspective. The Z component is used in all projection types, and always represents the Far plane.",
                FrustrumMin = @"A vector representing the near bottom left corner of the projection frustrum. 
The X and Y components are used in all projection types except Perspective. The Z component is used in all projection types, and always represents the Near plane.",
                ProjectionType = @"The type of projection frustrum in use. The way this is constructed, and its final shape, depend on the Projection Type as follows:
* Orthographic: the cuboidal frustrum width and height are derived from the X and Y differences respectively between Frustrum Min/Max. As always, the Z components determine the Near and Far planes. 
* Orthographic Offset: the Frustrum Min/Max alone determine the extents of the frustrum, which is cuboidal. 
* Perspective: the Field of View (total yaw, in degrees) is combined with the current display aspect ratio, and the Near and Far planes (Z components of the Frustrum Min/Max). 
* Perspective Offset: the Frustrum Min/Max alone determine the extents of the frustrum.";
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
