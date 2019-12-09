namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;

    internal class GLSLSnippetController
    {
        internal GLSLSnippetController(GLSLController glslController, FastColoredTextBox textBox)
        {
            GLSLController = glslController;
            TextBox = textBox;
            TextBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox.Height = 14 * Math.Max(TextBox.LinesCount, 1);
        }

        private GLSLController GLSLController;
        private FastColoredTextBox TextBox;
    }
}
