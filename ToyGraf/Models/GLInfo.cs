// <copyright file="GLInfo.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Models
{
    using OpenTK.Graphics.OpenGL;
    using System.ComponentModel;

    [TypeConverter(typeof(GLInfoTypeConverter))]
    public class GLInfo
    {
        public GLInfo() : this(
            number: GL.GetString(StringName.Version),
            major: GL.GetInteger(GetPName.MajorVersion),
            minor: GL.GetInteger(GetPName.MinorVersion),
            shader: GL.GetString(StringName.ShadingLanguageVersion),
            vendor: GL.GetString(StringName.Vendor),
            renderer: GL.GetString(StringName.Renderer))
        { }

        public GLInfo(string number, int major, int minor, string vendor, string renderer, string shader)
        {
            Number = number;
            Major = major;
            Minor = minor;
            Shader = shader;
            Vendor = vendor;
            Renderer = renderer;
        }

        [Description(Descriptions.GLInfo_Number)]
        [DisplayName(DisplayNames.GLInfo_Number)]
        public string Number { get; }

        [Description(Descriptions.GLInfo_Major)]
        [DisplayName(DisplayNames.GLInfo_Major)]
        public int Major { get; }

        [Description(Descriptions.GLInfo_Minor)]
        [DisplayName(DisplayNames.GLInfo_Minor)]
        public int Minor { get; }

        [Description(Descriptions.GLInfo_Shader)]
        [DisplayName(DisplayNames.GLInfo_Shader)]
        public string Shader { get; }

        [Description(Descriptions.GLInfo_Vendor)]
        [DisplayName(DisplayNames.GLInfo_Vendor)]
        public string Vendor { get; }

        [Description(Descriptions.GLInfo_Renderer)]
        [DisplayName(DisplayNames.GLInfo_Renderer)]
        public string Renderer { get; }

        public override string ToString() =>
            $"{Number}, {Major}, {Minor}, {Shader}, {Vendor}, {Renderer}";
    }
}
