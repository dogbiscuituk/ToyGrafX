namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;

    public class GLModeTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(GLMode), attributes).Sort(new[]
            {
                "Index",
                "ColourFormat",
                "AccumColourFormat",
                "Buffers",
                "Depth",
                "SampleCount",
                "Stencil",
                "Stereo"
            });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
