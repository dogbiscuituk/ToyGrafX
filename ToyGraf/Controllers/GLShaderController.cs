namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyGraf.Controls;

    public class GLShaderController
    {
        public GLShaderController(GLShaderEditor editor)
        {
            Editor = editor;
            SnippetControllers.Clear();
            Add(editor.tbInitHeader);
            Add(editor.tbInit);
            Add(editor.tbMainHeader);
            Add(editor.tbMain);
            Add(editor.tbCaseHeader);
            Add(editor.tbCase);
            Add(editor.tbFooter);
            AdjustHeight();
        }

        private GLShaderEditor Editor;
        private readonly List<GLSnippetController> SnippetControllers =
            new List<GLSnippetController>();

        private void Add(FastColoredTextBox textBox)
        {
            SnippetControllers.Add(new GLSnippetController(textBox));
            textBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (FastColoredTextBox)sender;
            textBox.Height = 14 * Math.Max(textBox.LinesCount, 1);
            AdjustHeight();
        }

        private void AdjustHeight()
        {
            var h = SnippetControllers.Sum(p => p.TextBox.Height);
            Editor.LayoutPanel.Height = Editor.Height = h;
        }
    }
}
