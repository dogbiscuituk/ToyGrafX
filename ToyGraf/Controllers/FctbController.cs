namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using ToyGraf.Common.Types;

    /// <summary>
    /// FastColoredTextBox controller class.
    /// Adds GLSL to list of supported languages.
    /// </summary>
    internal class FctbController
    {
        #region Constructor

        internal FctbController(FastColoredTextBox textBox)
        {
            TextBox = textBox ?? throw new NullReferenceException("textBox cannot be null.");
            Lingo = "GLSL";
            TextBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (Lingo)
            {
                case "GLSL":
                    SyntaxHighlightGLSL(e);
                    break;
            }
            if (TextBox.Text.Trim().StartsWith("<?xml"))
            {
                TextBox.Language = Language.XML;
                TextBox.ClearStylesBuffer();
                TextBox.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                TextBox.OnSyntaxHighlight(new TextChangedEventArgs(TextBox.Range));
            }
        }

        #endregion

        internal string Lingo
        {
            get => _Lingo;
            set => SetLingo(value);
        }

        private void SetLingo(string lingo)
        {
            if (Lingo == lingo)
                return;
            _Lingo = lingo;
            TextBox.ClearStylesBuffer();
            TextBox.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            switch (Lingo)
            {
                case "GLSL":
                    TextBox.Language = Language.Custom;
                    TextBox.CommentPrefix = "//";
                    TextBox.OnTextChanged();
                    break;
                case "C#": TextBox.Language = Language.CSharp; break;
                case "VB": TextBox.Language = Language.VB; break;
                case "HTML": TextBox.Language = Language.HTML; break;
                case "XML": TextBox.Language = Language.XML; break;
                case "SQL": TextBox.Language = Language.SQL; break;
                case "PHP": TextBox.Language = Language.PHP; break;
                case "JS": TextBox.Language = Language.JS; break;
                case "Lua": TextBox.Language = Language.Lua; break;
            }
            TextBox.OnSyntaxHighlight(new TextChangedEventArgs(TextBox.Range));
        }

        private readonly FastColoredTextBox TextBox;

        #region Private Properties

        private string _Lingo;

        #endregion

        #region Private Styles

        private static readonly MarkerStyle
            SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private static readonly TextStyle
            BlueStyle = NewTextStyle(Brushes.Blue),
            BoldStyle = NewTextStyle(null, FontStyle.Bold | FontStyle.Underline),
            BrownStyle = NewTextStyle(Brushes.Brown, FontStyle.Italic),
            GrayStyle = NewTextStyle(Brushes.Gray),
            GreenStyle = NewTextStyle(Brushes.Green, FontStyle.Italic),
            MagentaStyle = NewTextStyle(Brushes.Magenta),
            MaroonStyle = NewTextStyle(Brushes.Maroon),
            RedStyle = NewTextStyle(Brushes.Red);

        #endregion

        #region Private Methods

        private void InitStylesPriority() => TextBox.AddStyle(SameWordsStyle);

        private static TextStyle NewTextStyle(Brush brush, FontStyle style = 0) =>
            new TextStyle(brush, null, style);

        private void SyntaxHighlightGLSL(TextChangedEventArgs e)
        {
            TextBox.LeftBracket = '(';
            TextBox.RightBracket = ')';
            TextBox.LeftBracket2 = '\x0';
            TextBox.RightBracket2 = '\x0';

            e.ChangedRange.ClearStyle(
                BlueStyle,
                BoldStyle,
                BrownStyle,
                GrayStyle,
                GreenStyle,
                MagentaStyle,
                MaroonStyle,
                RedStyle);

            e.ChangedRange.SetStyle(BrownStyle, GLSL.StringPattern);
            e.ChangedRange.SetStyle(GreenStyle, GLSL.CommentPattern1, RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, GLSL.CommentPattern2, RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, GLSL.CommentPattern3, RegexOptions.Singleline | RegexOptions.RightToLeft);
            e.ChangedRange.SetStyle(MagentaStyle, GLSL.NumberPattern);
            e.ChangedRange.SetStyle(BlueStyle, GLSL.KeywordPattern);
            e.ChangedRange.SetStyle(RedStyle, GLSL.ReservedWordPattern);
            e.ChangedRange.SetStyle(MaroonStyle, GLSL.DirectivePattern);
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");
        }

        #endregion
    }
}
