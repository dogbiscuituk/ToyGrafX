namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;

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

        private FastColoredTextBox TextBox;

        #region Private Properties

        private const string
            AnyComment1 = @"//.*$",
            AnyComment2 = @"(/\*.*?\*/)|(/\*.*)",
            AnyComment3 = @"(/\*.*?\*/)|(.*\*/)",
            AnyNumber = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b",
            AnyString = @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'";

        private static readonly string
            AnyDirective = $@"^\s*#\s*\b{MakePattern(Directives)}\b.*$",
            AnyKeyword = $@"\b{MakePattern(Keywords)}\b",
            AnyReservedWord = $@"\b{MakePattern(ReservedWords)}\b";

        private string _Lingo;

        #endregion

        #region Private Methods

        private void InitStylesPriority() => TextBox.AddStyle(SameWordsStyle);

        private static string MakePattern(IEnumerable<string> words) =>
            $@"({words.Aggregate((s, t) => $"s|t")})";

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

            e.ChangedRange.SetStyle(BrownStyle, AnyString);
            e.ChangedRange.SetStyle(GreenStyle, AnyComment1, RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, AnyComment2, RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, AnyComment3, RegexOptions.Singleline | RegexOptions.RightToLeft);
            e.ChangedRange.SetStyle(MagentaStyle, AnyNumber);
            e.ChangedRange.SetStyle(BlueStyle, AnyKeyword);
            e.ChangedRange.SetStyle(RedStyle, AnyReservedWord);
            e.ChangedRange.SetStyle(MaroonStyle, AnyDirective);
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");
        }

        #endregion

        #region Styles

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

        #region GLSL Syntax

        // https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.40.pdf

        private static readonly string[]
            Directives = new[]
            {
                "define", "elif", "else", "endif", "error", "extension", "if", "ifdef", "ifndef",
                "line", "pragma", "undef", "version"
            },
            Keywords = new[]
            {
                "atomic_uint", "attribute", "bool", "break", "buffer", "bvec2", "bvec3", "bvec4",
                "case", "centroid", "coherent", "const", "continue", "default", "discard", "dmat2",
                "dmat2x2", "dmat2x3", "dmat2x4", "dmat3", "dmat3x2", "dmat3x3", "dmat3x4", "dmat4",
                "dmat4x2", "dmat4x3", "dmat4x4", "do", "double", "dvec2", "dvec3", "dvec4", "else",
                "false", "flat", "float", "for", "highp", "if", "iimage1D", "iimage1DArray",
                "iimage2D", "iimage2DArray", "iimage2DMS", "iimage2DMSArray", "iimage2DRect",
                "iimage3D", "iimageBuffer", "iimageCube", "iimageCubeArray", "image1D",
                "image1DArray", "image2D", "image2DArray", "image2DMS", "image2DMSArray",
                "image2DRect", "image3D", "imageBuffer", "imageCube", "imageCubeArray", "in",
                "inout", "int", "invariant", "isampler1D", "isampler1DArray", "isampler2D",
                "isampler2DArray", "isampler2DMS", "isampler2DMSArray", "isampler2DRect",
                "isampler3D", "isamplerBuffer", "isamplerCube", "isamplerCubeArray", "ivec2",
                "ivec3", "ivec4", "layout", "lowp", "mat2", "mat2x2", "mat2x3", "mat2x4", "mat3",
                "mat3x2", "mat3x3", "mat3x4", "mat4", "mat4x2", "mat4x3", "mat4x4", "mediump",
                "noperspective", "out", "patch", "precise", "precision", "readonly", "restrict",
                "return", "sample", "sampler1D", "sampler1DArray", "sampler1DArrayShadow",
                "sampler1DShadow", "sampler2D", "sampler2DArray", "sampler2DArrayShadow",
                "sampler2DMS", "sampler2DMSArray", "sampler2DRect", "sampler2DRectShadow",
                "sampler2DShadow", "sampler3D", "samplerBuffer", "samplerCube", "samplerCubeArray",
                "samplerCubeArrayShadow", "samplerCubeShadow", "shared", "smooth", "struct",
                "subroutine", "switch", "true", "uimage1D", "uimage1DArray", "uimage2D",
                "uimage2DArray", "uimage2DMS", "uimage2DMSArray", "uimage2DRect", "uimage3D",
                "uimageBuffer", "uimageCube", "uimageCubeArray", "uint", "uniform", "usampler1D",
                "usampler1DArray", "usampler2D", "usampler2DArray", "usampler2DMS",
                "usampler2DMSArray", "usampler2DRect", "usampler3D", "usamplerBuffer",
                "usamplerCube", "usamplerCubeArray", "uvec2", "uvec3", "uvec4", "varying", "vec2",
                "vec3", "vec4", "void", "volatile", "while", "writeonly"
            },
            ReservedWords = new[]
            {
                "active", "asm", "cast", "class", "common", "enum", "extern", "external", "filter",
                "fixed", "fvec2", "fvec3", "fvec4", "goto", "half", "hvec2", "hvec3", "hvec4",
                "inline", "input", "interface", "long", "namespace", "noinline", "output",
                "partition", "public", "resource", "sampler3DRect", "short", "sizeof", "static",
                "superp", "template", "this", "typedef", "union", "unsigned", "using"
            };

        #endregion
    }
}
