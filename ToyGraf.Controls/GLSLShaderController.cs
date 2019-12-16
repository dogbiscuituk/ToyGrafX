namespace ToyGraf.Controls
{
    using FastColoredTextBoxNS;
    using System;

    internal class GLSLShaderController
    {
        internal GLSLShaderController(GLSLShaderEditor editor)
        {
            Add(editor.tbInitHeader);
            Add(editor.tbInit);
            Add(editor.tbMainHeader);
            Add(editor.tbMain);
            Add(editor.tbCaseHeader);
            Add(editor.tbCase);
            Add(editor.tbFooter);
        }

        private void Add(FastColoredTextBox textBox) =>
            textBox.TextChanged += TextBox_TextChanged;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (FastColoredTextBox)sender;
            textBox.Height = 14 * Math.Max(textBox.LinesCount, 1);
        }
    }
}
