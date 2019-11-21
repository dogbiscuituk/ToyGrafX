namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;
    using ToyGraf.Controls;
    using Languages = FastColoredTextBoxNS.Language;

    /// <summary>
    /// FastColoredTextBox controller class.
    /// Adds GLSL to list of supported languages.
    /// </summary>
    internal class TextStyleController
    {
        #region Constructor

        internal TextStyleController(FastColoredTextBox textBox)
        {
            _TextBox = textBox ?? throw new NullReferenceException($"{nameof(textBox)} cannot be null.");
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

        internal static void ApplyOptions()
        {
            var styles = AppController.Options.SyntaxHighlightStyles;
            ApplyStyle(styles.Comments, CommentStyle);
            ApplyStyle(styles.Directives, DirectiveStyle);
            ApplyStyle(styles.Functions, FunctionStyle);
            ApplyStyle(styles.Keywords, KeywordStyle);
            ApplyStyle(styles.Numbers, NumberStyle);
            ApplyStyle(styles.ReservedWords, ReservedWordStyle);
            ApplyStyle(styles.Strings, StringStyle);
        }

        #endregion

        #region Private Fields

        private string _Language;
        private readonly FastColoredTextBox _TextBox;

        #endregion

        #region Private Event Handlers

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Language == "GLSL")
                SyntaxHighlightGLSL(e);
            if (_TextBox.Text.Trim().StartsWith("<?xml"))
            {
                _TextBox.Language = Languages.XML;
                _TextBox.ClearStylesBuffer();
                _TextBox.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                _TextBox.OnSyntaxHighlight(new TextChangedEventArgs(_TextBox.Range));
            }
        }

        #endregion

        #region Private Methods

        private static void ApplyStyle(TextStyleInfo info, TextStyle style)
        {
            if (((SolidBrush)style.ForeBrush).Color != info.Foreground)
                style.ForeBrush = info.Foreground.ToBrush();
            if (((SolidBrush)style.BackgroundBrush).Color != info.Background)
                style.BackgroundBrush = info.Background.ToBrush();
            style.FontStyle = info.FontStyle;
        }

        private static TextStyle CreateTextStyle() => 
            new TextStyle(Brushes.Black, Brushes.Transparent, 0);

        private Languages GetLanguage()
        {
            switch (Language)
            {
                case "C#": return Languages.CSharp;
                case "GLSL": return Languages.Custom;
                case "HTML": return Languages.HTML;
                case "JS": return Languages.JS;
                case "Lua": return Languages.Lua;
                case "PHP": return Languages.PHP;
                case "SQL": return Languages.SQL;
                case "VB": return Languages.VB;
                case "XML": return Languages.XML;
                default: return Languages.Custom;
            }
        }

        private void InitStylesPriority() => _TextBox.AddStyle(SameWordsStyle);

        private void SetLanguage(string language)
        {
            if (Language == language)
                return;
            _Language = language;
            _TextBox.ClearStylesBuffer();
            _TextBox.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            _TextBox.Language = GetLanguage();
            if (Language == "GLSL")
            {
                _TextBox.CommentPrefix = "//";
                _TextBox.OnTextChanged();
            }
            _TextBox.OnSyntaxHighlight(new TextChangedEventArgs(_TextBox.Range));
        }

        private void SyntaxHighlightGLSL(TextChangedEventArgs e)
        {
            _TextBox.LeftBracket = '(';
            _TextBox.RightBracket = ')';
            _TextBox.LeftBracket2 = '\x0';
            _TextBox.RightBracket2 = '\x0';
            var range = e.ChangedRange;
            range.ClearStyle(
                CommentStyle,
                DirectiveStyle,
                FunctionStyle,
                KeywordStyle,
                NumberStyle,
                ReservedWordStyle,
                StringStyle);
            range.SetStyle(StringStyle, GLSL.Strings);
            range.SetStyle(CommentStyle, GLSL.Comments1, RegexOptions.Multiline);
            range.SetStyle(CommentStyle, GLSL.Comments2, RegexOptions.Singleline);
            range.SetStyle(CommentStyle, GLSL.Comments3, RegexOptions.Singleline | RegexOptions.RightToLeft);
            range.SetStyle(NumberStyle, GLSL.Numbers);
            range.SetStyle(FunctionStyle, GLSL.Functions);
            range.SetStyle(KeywordStyle, GLSL.Keywords);
            range.SetStyle(ReservedWordStyle, GLSL.ReservedWords);
            range.SetStyle(DirectiveStyle, GLSL.Directives);
            range.ClearFoldingMarkers();
            range.SetFoldingMarkers("{", "}");
            range.SetFoldingMarkers(@"/\*", @"\*/");
        }

        #endregion

        #region Private Styles

        private static readonly MarkerStyle
            SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private static readonly TextStyle
            CommentStyle = CreateTextStyle(),
            DirectiveStyle = CreateTextStyle(),
            FunctionStyle = CreateTextStyle(),
            KeywordStyle = CreateTextStyle(),
            NumberStyle = CreateTextStyle(),
            ReservedWordStyle = CreateTextStyle(),
            StringStyle = CreateTextStyle();

        #endregion
    }
}
