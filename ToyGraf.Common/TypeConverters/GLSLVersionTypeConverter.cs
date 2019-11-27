namespace ToyGraf.Common.TypeConverters
{
    using System.ComponentModel;

    public class GLSLVersionTypeConverter : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) =>
            new StandardValuesCollection(new[]
            {
                "330",
                "400",
                "410",
                "420",
                "430",
                "440",
                "450",
                "460"
            });

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => false;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
    }
}
