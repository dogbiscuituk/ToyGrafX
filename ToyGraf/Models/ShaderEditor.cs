namespace ToyGraf.Models
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;
    using ToyGraf.Controllers;

    public class ShaderEditor : UITypeEditor
    {
        #region Public Methods

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Text = value as string ?? string.Empty;
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService service)
            {
                Context = context;
                var editor = new GLProgramController(context.PropertyDescriptor.DisplayName) { Text = Text };
                editor.Apply += Editor_Apply;
                if (editor.Execute(service))
                    Text = editor.Text;
                editor.Apply -= Editor_Apply;
            }
            return Text;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) =>
            UITypeEditorEditStyle.Modal;

        #endregion

        #region Private Properties

        private ITypeDescriptorContext Context;
        private string Text { get; set; }

        #endregion

        #region Private Event Handlers

        private void Editor_Apply(object sender, EditEventArgs e) =>
            Context.PropertyDescriptor.SetValue(Context.Instance, Text = e.Text);

        #endregion
    }
}
