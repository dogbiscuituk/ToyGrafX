namespace ToyGraf.Models
{
    public static class Extensions
    {
        public static void CopyTo(this ITrace source, ITrace target) => target.CopyFrom(source);

        public static void CopyFrom(this ITrace target, ITrace source)
        {
            target.ShaderCompute = source.ShaderCompute;
            target.ShaderFragment = source.ShaderFragment;
            target.ShaderGeometry = source.ShaderGeometry;
            target.ShaderStatus = source.ShaderStatus;
            target.ShaderTessControl = source.ShaderTessControl;
            target.ShaderTessEvaluation = source.ShaderTessEvaluation;
            target.ShaderVertex = source.ShaderVertex;
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
