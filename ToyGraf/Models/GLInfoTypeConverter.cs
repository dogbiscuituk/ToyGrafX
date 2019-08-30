// <copyright file="GLInfoTypeConverter.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;

    public class GLInfoTypeConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(
            ITypeDescriptorContext context, object value, Attribute[] attributes) =>
            TypeDescriptor.GetProperties(typeof(GLInfo), attributes)
                .Sort(new string[] { "Number", "Major", "Minor", "Shader", "Vendor", "Renderer", "Extensions" });

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}
