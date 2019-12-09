namespace ToyGraf.Controls
{
    using System;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;

    public partial class GLSLShaderEditor : UserControl
    {
        public GLSLShaderEditor()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            var textBox = (FastColoredTextBox)sender;
            var h = Height - textBox.Height;
            textBox.Parent.Height = 14 * Math.Max(textBox.LinesCount, 1);
            h += textBox.Height;
            Height = h;
        }
    }
}
