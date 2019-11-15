namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;
    using ToyGraf.Controls;

    /// <summary>
    /// FastColoredTextBox controller class.
    /// Adds GLSL to list of supported languages.
    /// </summary>
    internal class FctbController
    {
        #region Constructor

        internal FctbController(FastColoredTextBox textBox)
        {
            UpdateStyles();
            _TextBox = textBox ?? throw new NullReferenceException("textBox cannot be null.");
            Language = "GLSL";
            _TextBox.TextChanged += TextBox_TextChanged;
        }

        #endregion

        #region Internal Properties

        internal string Language
        {
            get => _Language;
            set => SetLanguage(value);
        }

        #endregion

        #region Internal Methods

        internal static void UpdateStyles()
        {
            var styles = AppController.Options.SyntaxHighlightStyles;
            CommentStyle = NewTextStyle(styles.Comments);
            DirectiveStyle = NewTextStyle(styles.Directives);
            FunctionStyle = NewTextStyle(styles.Functions);
            KeywordStyle = NewTextStyle(styles.Keywords);
            NumberStyle = NewTextStyle(styles.Numbers);
            ReservedWordStyle = NewTextStyle(styles.ReservedWords);
            StringStyle = NewTextStyle(styles.Strings);
        }

        #endregion

        #region Private Fields

        private string _Language;
        private readonly FastColoredTextBox _TextBox;

        #endregion

        #region Private Event Handlers

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (Language)
            {
                case "GLSL":
                    SyntaxHighlightGLSL(e);
                    break;
            }
            if (_TextBox.Text.Trim().StartsWith("<?xml"))
            {
                _TextBox.Language = FastColoredTextBoxNS.Language.XML;
                _TextBox.ClearStylesBuffer();
                _TextBox.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                _TextBox.OnSyntaxHighlight(new TextChangedEventArgs(_TextBox.Range));
            }
        }

        #endregion

        #region Private Methods

        private void InitStylesPriority() => _TextBox.AddStyle(SameWordsStyle);

        private static TextStyle NewTextStyle(TextStyleInfo style) =>
            new TextStyle(style.Foreground.ToBrush(), style.Background.ToBrush(), style.FontStyle);

        private void SetLanguage(string language)
        {
            if (Language == language)
                return;
            _Language = language;
            _TextBox.ClearStylesBuffer();
            _TextBox.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            switch (Language)
            {
                case "GLSL":
                    _TextBox.Language = FastColoredTextBoxNS.Language.Custom;
                    _TextBox.CommentPrefix = "//";
                    _TextBox.OnTextChanged();
                    break;
                case "C#": _TextBox.Language = FastColoredTextBoxNS.Language.CSharp; break;
                case "VB": _TextBox.Language = FastColoredTextBoxNS.Language.VB; break;
                case "HTML": _TextBox.Language = FastColoredTextBoxNS.Language.HTML; break;
                case "XML": _TextBox.Language = FastColoredTextBoxNS.Language.XML; break;
                case "SQL": _TextBox.Language = FastColoredTextBoxNS.Language.SQL; break;
                case "PHP": _TextBox.Language = FastColoredTextBoxNS.Language.PHP; break;
                case "JS": _TextBox.Language = FastColoredTextBoxNS.Language.JS; break;
                case "Lua": _TextBox.Language = FastColoredTextBoxNS.Language.Lua; break;
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
                CommentStyle,
                DirectiveStyle,
                FunctionStyle,
                KeywordStyle,
                NumberStyle,
                ReservedWordStyle,
                StringStyle);

            e.ChangedRange.SetStyle(StringStyle, GLSL.Strings);
            e.ChangedRange.SetStyle(CommentStyle, GLSL.Comments1, RegexOptions.Multiline);
            e.ChangedRange.SetStyle(CommentStyle, GLSL.Comments2, RegexOptions.Singleline);
            e.ChangedRange.SetStyle(CommentStyle, GLSL.Comments3, RegexOptions.Singleline | RegexOptions.RightToLeft);
            e.ChangedRange.SetStyle(NumberStyle, GLSL.Numbers);
            e.ChangedRange.SetStyle(FunctionStyle, GLSL.Functions);
            e.ChangedRange.SetStyle(KeywordStyle, GLSL.Keywords);
            e.ChangedRange.SetStyle(ReservedWordStyle, GLSL.ReservedWords);
            e.ChangedRange.SetStyle(DirectiveStyle, GLSL.Directives);
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");
        }

        #endregion

        #region Private Styles

        private static readonly MarkerStyle
            SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private static TextStyle
            CommentStyle,
            DirectiveStyle,
            FunctionStyle,
            KeywordStyle,
            NumberStyle,
            ReservedWordStyle,
            StringStyle;

        #endregion
    }
}
