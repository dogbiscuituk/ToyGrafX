namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using ToyGraf.Controllers;
    using ToyGraf.Views;

    public class ShaderEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            string text = value as string;
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService service && text != null)
                using (FctbForm dialog = new FctbForm())
                {
                    new FctbController(dialog.TextBox);
                    dialog.Text = context.PropertyDescriptor.DisplayName;
                    dialog.TextBox.Text = text;
                    if (service.ShowDialog(dialog) == DialogResult.OK)
                        text = dialog.TextBox.Text;
                }
            return text;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) =>
            UITypeEditorEditStyle.Modal;
    }
}
