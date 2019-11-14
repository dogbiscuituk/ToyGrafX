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
            _TextBox = textBox ?? throw new NullReferenceException("textBox cannot be null.");
            Lingo = "GLSL";
            _TextBox.TextChanged += TextBox_TextChanged;
        }

        #endregion

        #region Internal Properties

        internal string Lingo
        {
            get => _Lingo;
            set => SetLingo(value);
        }

        #endregion

        #region Private Fields

        private string _Lingo;
        private readonly FastColoredTextBox _TextBox;

        #endregion

        #region Private Event Handlers

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (Lingo)
            {
                case "GLSL":
                    SyntaxHighlightGLSL(e);
                    break;
            }
            if (_TextBox.Text.Trim().StartsWith("<?xml"))
            {
                _TextBox.Language = Language.XML;
                _TextBox.ClearStylesBuffer();
                _TextBox.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                _TextBox.OnSyntaxHighlight(new TextChangedEventArgs(_TextBox.Range));
            }
        }

        #endregion

        #region Private Methods

        private void InitStylesPriority() => _TextBox.AddStyle(SameWordsStyle);

        private static TextStyle NewTextStyle(Brush brush, FontStyle style = 0) =>
            new TextStyle(brush, null, style);

        private void SetLingo(string lingo)
        {
            if (Lingo == lingo)
                return;
            _Lingo = lingo;
            _TextBox.ClearStylesBuffer();
            _TextBox.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            switch (Lingo)
            {
                case "GLSL":
                    _TextBox.Language = Language.Custom;
                    _TextBox.CommentPrefix = "//";
                    _TextBox.OnTextChanged();
                    break;
                case "C#": _TextBox.Language = Language.CSharp; break;
                case "VB": _TextBox.Language = Language.VB; break;
                case "HTML": _TextBox.Language = Language.HTML; break;
                case "XML": _TextBox.Language = Language.XML; break;
                case "SQL": _TextBox.Language = Language.SQL; break;
                case "PHP": _TextBox.Language = Language.PHP; break;
                case "JS": _TextBox.Language = Language.JS; break;
                case "Lua": _TextBox.Language = Language.Lua; break;
            }
            _TextBox.OnSyntaxHighlight(new TextChangedEventArgs(_TextBox.Range));
        }

        private void SyntaxHighlightGLSL(TextChangedEventArgs e)
        {
            _TextBox.LeftBracket = '(';
            _TextBox.RightBracket = ')';
            _TextBox.LeftBracket2 = '\x0';
            _TextBox.RightBracket2 = '\x0';

            e.ChangedRange.ClearStyle(
                BlueStyle,
                // BoldStyle,
                BrownStyle,
                CyanStyle,
                // GrayStyle,
                GreenStyle,
                MagentaStyle,
                MaroonStyle,
                RedStyle);

            e.ChangedRange.SetStyle(BrownStyle, GLSL.Strings);
            e.ChangedRange.SetStyle(GreenStyle, GLSL.Comments1, RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, GLSL.Comments2, RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, GLSL.Comments3, RegexOptions.Singleline | RegexOptions.RightToLeft);
            e.ChangedRange.SetStyle(MagentaStyle, GLSL.Numbers);
            e.ChangedRange.SetStyle(CyanStyle, GLSL.Functions);
            e.ChangedRange.SetStyle(BlueStyle, GLSL.Keywords);
            e.ChangedRange.SetStyle(RedStyle, GLSL.ReservedWords);
            e.ChangedRange.SetStyle(MaroonStyle, GLSL.Directives);
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");
        }

        #endregion

        #region Private Styles

        private static readonly MarkerStyle
            SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private static readonly TextStyle
            BlueStyle = NewTextStyle(Brushes.Blue),
            // BoldStyle = NewTextStyle(null, FontStyle.Bold | FontStyle.Underline),
            BrownStyle = NewTextStyle(Brushes.Brown, FontStyle.Italic),
            CyanStyle = NewTextStyle(Brushes.Cyan),
            // GrayStyle = NewTextStyle(Brushes.Gray),
            GreenStyle = NewTextStyle(Brushes.Green, FontStyle.Italic),
            MagentaStyle = NewTextStyle(Brushes.Magenta),
            MaroonStyle = NewTextStyle(Brushes.Maroon),
            RedStyle = NewTextStyle(Brushes.Red);

        #endregion
    }
}
