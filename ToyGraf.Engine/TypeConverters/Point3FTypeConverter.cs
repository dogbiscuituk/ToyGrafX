namespace ToyGraf.Engine.TypeConverters
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.Types;

    public class Point3FTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(Point3F), attributes)
                .Sort(new string[] { "X", "Y", "Z" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
