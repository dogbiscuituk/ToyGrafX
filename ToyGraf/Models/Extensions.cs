namespace ToyGraf.Models
{
    public static class Extensions
    {
        public static void CopyTo(this ITrace source, ITrace target) => target.CopyFrom(source);

        public static void CopyFrom(this ITrace target, ITrace source)
        {
            target.ComputeShader = source.ComputeShader;
            target.FragmentShader = source.FragmentShader;
            target.GeometryShader = source.GeometryShader;
            target.ShaderStatus = source.ShaderStatus;
            target.TessControlShader = source.TessControlShader;
            target.TessEvaluationShader = source.TessEvaluationShader;
            target.VertexShader = source.VertexShader;
            target.Visible = source.Visible;
            target.Xmax = source.Xmax;
            target.Xmin = source.Xmin;
            target.Ymax = source.Ymax;
            target.Ymin = source.Ymin;
            target.Zmax = source.Zmax;
            target.Zmin = source.Zmin;
        }
    }
}
