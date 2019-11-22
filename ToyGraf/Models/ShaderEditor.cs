namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using ToyGraf.Controllers;

    public class ShaderEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            string text = value as string;
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService service && text != null)
            {
                var controller = new FctbController();
                var dialog = controller.Editor;
                //new TextStyleController(dialog.TextBox);
                dialog.Text = context.PropertyDescriptor.DisplayName;
                dialog.SecondaryTextBox.Text = text;
                if (service.ShowDialog(dialog) == DialogResult.OK)
                    text = dialog.SecondaryTextBox.Text;
            }
            return text;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) =>
            UITypeEditorEditStyle.Modal;
    }
}
