namespace ToyGraf.Engine.Types
{
    using System.ComponentModel;
    using ToyGraf.Engine.TypeConverters;

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ProjectionType
    {
        [Description("Orthographic")]
        Orthographic,
        [Description("Orthographic (Offset)")]
        OrthographicOffset,
        [Description("Perspective")]
        Perspective,
        [Description("Perspective (Offset)")]
        PerspectiveOffset
    }
}
