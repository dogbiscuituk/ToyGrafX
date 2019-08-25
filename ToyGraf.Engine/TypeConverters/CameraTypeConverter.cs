namespace ToyGraf.Engine.TypeConverters
{
    using System;
    using System.ComponentModel;

    public class CameraTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(Camera), attributes)
                .Sort(new string[] { "Position", "Rotation" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
