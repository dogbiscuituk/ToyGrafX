namespace ToyGraf.Engine.TypeConverters
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.Types;

    public class ProjectionTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(Projection), attributes)
                .Sort(new string[] { "ProjectionType", "FieldOfView", "FrustrumMin", "FrustrumMax" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
