namespace ToyGraf.Common.Utility
{
    public static class Categories
    {
        /// <summary>
        /// All categories must end with a trailing space. This is required to prevent their
        /// being incorporated into property paths when parsing PropertyGrid events.
        /// </summary>
        public const string
            Placement = "Placement ",
            Scene = "Scene ",
            ShaderCode = "Shader Code ",
            ShaderTemplates = "Shader Templates ",
            SystemRO = "Read Only / System ",
            Trace = "Trace ";
    }
}
