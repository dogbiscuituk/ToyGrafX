﻿namespace ToyGraf.Common.TypeConverters
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using ToyGraf.Common.Types;

    public class CameraTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            value is string s ? Camera.Parse(s) : base.ConvertFrom(context, culture, value);

        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(Camera), attributes)
                .Sort(new string[] { "Position", "Rotation" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
