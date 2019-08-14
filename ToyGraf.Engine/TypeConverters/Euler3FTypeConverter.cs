namespace ToyGraf.Engine.TypeConverters
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.Types;

    public class Euler3FTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(Euler3F), attributes)
                .Sort(new string[] { "Pitch", "Yaw", "Roll" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
