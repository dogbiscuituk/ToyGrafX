namespace ToyGraf.Engine.TypeConverters
{
    using System;
    using System.ComponentModel;
    using ToyGraf.Engine.Types;

    public class ColourFormatTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(ColourFormat), attributes)
                .Sort(new string[] { "Red", "Green", "Blue", "Alpha" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
