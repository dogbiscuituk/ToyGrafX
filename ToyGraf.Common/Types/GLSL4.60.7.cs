namespace ToyGraf.Common.Types
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.pdf
    /// </summary>
    public class GLSL
    {
        #region Public Properties

        protected static readonly string[]

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
                "isampler3D", "isamplerBuffer", "isamplerCube", "isamplerCubeArray",
                "isubpassInput", "isubpassInputMS", "itexture1D", "itexture1DArray", "itexture2D",
                "itexture2DArray", "itexture2DMS", "itexture2DMSArray", "itexture2DRect",
                "itexture3D", "itextureBuffer", "itextureCube", "itextureCubeArray", "ivec2",
                "ivec3", "ivec4", "layout", "lowp", "mat2", "mat2x2", "mat2x3", "mat2x4", "mat3",
                "mat3x2", "mat3x3", "mat3x4", "mat4", "mat4x2", "mat4x3", "mat4x4", "mediump",
                "noperspective", "out", "patch", "precise", "precision", "readonly", "restrict",
                "return", "sample", "sampler", "sampler1D", "sampler1DArray",
                "sampler1DArrayShadow", "sampler1DShadow", "sampler2D", "sampler2DArray",
                "sampler2DArrayShadow", "sampler2DMS", "sampler2DMSArray", "sampler2DRect",
                "sampler2DRectShadow", "sampler2DShadow", "sampler3D", "samplerBuffer",
                "samplerCube", "samplerCubeArray", "samplerCubeArrayShadow", "samplerCubeShadow",
                "samplerShadow", "shared", "smooth", "struct", "subpassInput", "subpassInputMS",
                "subroutine", "switch", "texture1D", "texture1DArray", "texture2D",
                "texture2DArray", "texture2DMS", "texture2DMSArray", "texture2DRect", "texture3D",
                "textureBuffer", "textureCube", "textureCubeArray", "true", "uimage1D",
                "uimage1DArray", "uimage2D", "uimage2DArray", "uimage2DMS", "uimage2DMSArray",
                "uimage2DRect", "uimage3D", "uimageBuffer", "uimageCube", "uimageCubeArray", "uint",
                "uniform", "usampler1D", "usampler1DArray", "usampler2D", "usampler2DArray",
                "usampler2DMS", "usampler2DMSArray", "usampler2DRect", "usampler3D",
                "usamplerBuffer", "usamplerCube", "usamplerCubeArray", "usubpassInput",
                "usubpassInputMS", "utexture1D", "utexture1DArray", "utexture2D", "utexture2DArray",
                "utexture2DMS", "utexture2DMSArray", "utexture2DRect", "utexture3D",
                "utextureBuffer", "utextureCube", "utextureCubeArray", "uvec2", "uvec3", "uvec4",
                "varying", "vec2", "vec3", "vec4", "void", "volatile", "while", "writeonly"
            },

            ReservedWords = new[]
            {
                "active", "asm", "cast", "class", "common", "enum", "extern", "external", "filter",
                "fixed", "fvec2", "fvec3", "fvec4", "goto", "half", "hvec2", "hvec3", "hvec4",
                "inline", "input", "interface", "long", "namespace", "noinline", "output",
                "partition", "public", "resource", "sampler3DRect", "short", "sizeof", "static",
                "superp", "template", "this", "typedef", "union", "unsigned", "using"
            };

        public const string
            CommentPattern1 = @"//.*$",
            CommentPattern2 = @"(/\*.*?\*/)|(/\*.*)",
            CommentPattern3 = @"(/\*.*?\*/)|(.*\*/)",
            NumberPattern = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b",
            StringPattern = @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'";

        public static readonly string
            DirectivePattern = $@"^\s*#\s*\b{MakePattern(Directives)}\b.*$",
            KeywordPattern = $@"\b{MakePattern(Keywords)}\b",
            ReservedWordPattern = $@"\b{MakePattern(ReservedWords)}\b";

        #endregion

        #region Private Methods

        private static string MakePattern(IEnumerable<string> words) =>
            string.Concat("(", words.Aggregate((s, t) => $"{s}|{t}"), ")");

        #endregion

    }
}
