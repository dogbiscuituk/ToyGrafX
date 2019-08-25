namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(ProjectionTypeConverter))]
    public class Projection
    {
        #region Constructors

        #endregion

        #region Public Properties

        [Description(Descriptions.FarPlane)]
        [DisplayName(DisplayNames.FarPlane)]
        public float FarPlane { get; set; }

        [Description(Descriptions.FieldOfView)]
        [DisplayName(DisplayNames.FieldOfView)]
        public float FieldOfView { get; set; }

        [Description(Descriptions.NearPlane)]
        [DisplayName(DisplayNames.NearPlane)]
        public float NearPlane { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Classes

        private class Descriptions
        {
            internal const string
                FarPlane = "Far Plane",
                FieldOfView = "Field of View",
                NearPlane = "Near Plane";
        }

        private class DisplayNames
        {
            internal const string
                FarPlane = "Far Plane",
                FieldOfView = "Field of View",
                NearPlane = "Near Plane";
        }

        #endregion
    }
}
