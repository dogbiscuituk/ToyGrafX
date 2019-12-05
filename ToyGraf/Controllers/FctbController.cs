﻿namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using ToyGraf.Common.Types;
    using ToyGraf.Common.Utility;
    using ToyGraf.Controls;
    using Languages = FastColoredTextBoxNS.Language;

    /// <summary>
    /// FastColoredTextBox controller class.
    /// Adds GLSL to list of supported languages.
    /// </summary>
    internal class FctbController
    {
        #region Constructor

        internal FctbController(FastColoredTextBox textBox)
        {
            TextBox = textBox ?? throw new NullReferenceException($"{nameof(textBox)} cannot be null.");
            Language = "GLSL";
            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.PaintLine += TextBox_PaintLine;
            TextBox.TextChanged += TextBox_TextChanged;
            TextBox.TextChanging += TextBox_TextChanging;
            CreateAutocompleteMenu();
        }

        #endregion

        #region Internal Properties

        internal string Language
        {
            get => TextBoxLanguage;
            set => SetLanguage(value);
        }

        #endregion

        #region Internal Methods

        internal void AddReadOnlyRange(Range range)
        {
            var rangeAll = TextBox.Range;
            if (range.End.iLine > rangeAll.End.iLine)
                range.End = rangeAll.End;
            range.SetStyle(ReadOnlyStyle);
            range.SetStyle(ReadOnlyTextStyle);
        }

        internal static void ApplyOptions()
        {
            var styles = AppController.Options.SyntaxHighlightStyles;
            InitStyle(styles.Comments, CommentStyle);
            InitStyle(styles.Directives, DirectiveStyle);
            InitStyle(styles.Functions, FunctionStyle);
            InitStyle(styles.Keywords, KeywordStyle);
            InitStyle(styles.Numbers, NumberStyle);
            InitStyle(styles.ReadOnly, ReadOnlyTextStyle);
            InitStyle(styles.ReservedWords, ReservedWordStyle);
            InitStyle(styles.Strings, StringStyle);
        }

        internal List<Range> GetEditableRanges()
        {
            var ranges = new List<Range>();
            var inRange = false;
            for (var lineIndex = 0; lineIndex < TextBox.LinesCount; lineIndex++)
            {
                var range = TextBox.GetLine(lineIndex);
                if (!range.ReadOnly)
                {
                    if (!inRange)
                    {
                        ranges.Add(range);
                        inRange = true;
                    }
                    else
                    {
                        var rangeIndex = ranges.Count - 1;
                        ranges[rangeIndex] = ranges[rangeIndex].GetUnionWith(range);
                    }
                }
                else
                    inRange = false;
            }
            return ranges;
        }

        #endregion

        #region Private Fields

        private AutocompleteMenu AutocompleteMenu;
        private readonly FastColoredTextBox TextBox;
        private string TextBoxLanguage;

        #endregion

        #region Private Event Handlers

        private void TextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.K:
                    // forced show (MinFragmentLength will be ignored)
                    AutocompleteMenu.Show(true);
                    e.Handled = true;
                    break;
            }
        }

        private void TextBox_PaintLine(object sender, PaintLineEventArgs e)
        {
            if (new Range(TextBox, e.LineIndex).ReadOnly)
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.LineRect);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Language == "GLSL")
                SyntaxHighlightGLSL(e);
            if (TextBox.Text.Trim().StartsWith("<?xml"))
            {
                TextBox.Language = Languages.XML;
                TextBox.ClearStylesBuffer();
                TextBox.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                TextBox.OnSyntaxHighlight(new TextChangedEventArgs(TextBox.Range));
            }
        }

        private void TextBox_TextChanging(object sender, TextChangingEventArgs e)
        {
            var selection = TextBox.Selection;
            e.Cancel = selection.IsReadOnlyLeftChar() || selection.IsReadOnlyRightChar();
        }

        #endregion

        #region Private Methods

        private void CreateAutocompleteMenu()
        {
            AutocompleteMenu = new AutocompleteMenu(TextBox)
            {
                MinFragmentLength = 2,
                SearchPattern = "[#\\w\\.]" // Directives begin with '#'.
            };
            AutocompleteMenu.Items.SetAutocompleteItems(GLSL.AutocompleteItems);
            AutocompleteMenu.Items.MaximumSize = new System.Drawing.Size(200, 300);
            AutocompleteMenu.Items.Width = 200;
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

        private static void InitStyle(TextStyleInfo info, TextStyle style)
        {
            if (((SolidBrush)style.ForeBrush).Color != info.Foreground)
                style.ForeBrush = info.Foreground.ToBrush();
            if (((SolidBrush)style.BackgroundBrush).Color != info.Background)
                style.BackgroundBrush = info.Background.ToBrush();
            style.FontStyle = info.FontStyle;
        }

        private void InitStylesPriority()
        {
            TextBox.AddStyle(SameWordsStyle);
            TextBox.AddStyle(ReadOnlyTextStyle);
            TextBox.AddStyle(StringStyle);
            TextBox.AddStyle(CommentStyle);
            TextBox.AddStyle(NumberStyle);
            TextBox.AddStyle(FunctionStyle);
            TextBox.AddStyle(KeywordStyle);
            TextBox.AddStyle(ReservedWordStyle);
            TextBox.AddStyle(DirectiveStyle);
        }

        private void SetLanguage(string language)
        {
            if (Language == language)
                return;
            TextBoxLanguage = language;
            TextBox.ClearStylesBuffer();
            TextBox.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            TextBox.Language = GetLanguage();
            if (Language == "GLSL")
            {
                TextBox.CommentPrefix = "//";
                TextBox.OnTextChanged();
            }
            TextBox.OnSyntaxHighlight(new TextChangedEventArgs(TextBox.Range));
        }

        private void SyntaxHighlightGLSL(TextChangedEventArgs e)
        {
            TextBox.LeftBracket = '(';
            TextBox.RightBracket = ')';
            TextBox.LeftBracket2 = '\x0';
            TextBox.RightBracket2 = '\x0';
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

        private static readonly ReadOnlyStyle
            ReadOnlyStyle = new ReadOnlyStyle();

        private static readonly TextStyle
            CommentStyle = CreateTextStyle(),
            DirectiveStyle = CreateTextStyle(),
            FunctionStyle = CreateTextStyle(),
            KeywordStyle = CreateTextStyle(),
            NumberStyle = CreateTextStyle(),
            ReadOnlyTextStyle = CreateTextStyle(),
            ReservedWordStyle = CreateTextStyle(),
            StringStyle = CreateTextStyle();

        #endregion
    }
}
