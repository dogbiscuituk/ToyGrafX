namespace ToyGraf.Engine.TypeConverters
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;

    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type) : base(type) { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || TypeDescriptor.GetConverter(typeof(Enum)).CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            value is string
            ? GetValue(EnumType, (string)value)
            : value is Enum
            ? GetDescription((Enum)value)
            : base.ConvertFrom(context, culture, value);

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type type) =>
            value is Enum && type == typeof(string)
            ? GetDescription((Enum)value)
            : value is string && type == typeof(string)
            ? GetDescription(EnumType, (string)value)
            : base.ConvertTo(context, culture, value, type);

        public static string GetDescription(Enum value)
        {
            var attrs = value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Any()
                ? ((DescriptionAttribute)attrs[0]).Description
                : value.ToString();
        }

        public static string GetDescription(Type value, string name)
        {
            var attrs = value
                .GetField(name)
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return
                attrs.Any()
                ? ((DescriptionAttribute)attrs[0]).Description
                : name;
        }

        public static object GetValue(Type value, string description)
        {
            var fields = value.GetFields();
            foreach (var field in fields)
            {
                var attrs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Any() && ((DescriptionAttribute)attrs[0]).Description == description)
                    return field.GetValue(field.Name);
                if (field.Name == description)
                    return field.GetValue(field.Name);
            }
            return description;
        }
    }
}
