namespace ToyGraf.Models
{
    using ToyGraf.Models.Enums;

    public interface ITrace
    {
        string[] ComputeShader { get; set; }
        string[] FragmentShader { get; set; }
        string[] GeometryShader { get; set; }
        string[] ShaderStatus { get; set; }
        string[] TessControlShader { get; set; }
        string[] TessEvaluationShader { get; set; }
        string[] VertexShader { get; set; }
        YN Visible { get; set; }
        double Xmax { get; set; }
        double Xmin { get; set; }
        double Ymax { get; set; }
        double Ymin { get; set; }
        double Zmax { get; set; }
        double Zmin { get; set; }
    }
}
