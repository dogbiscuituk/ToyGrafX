// <copyright file="Options.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Models.Structs
{
    public struct Options
    {
        public string FilesFolderPath { get; set; }
        public bool OpenInNewWindow { get; set; }
        public bool ShowSystemRO { get; set; }
        public string TemplatesFolderPath { get; set; }
    }
}
