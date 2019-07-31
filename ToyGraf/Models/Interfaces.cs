namespace ToyGraf.Models
{
    public interface ITrace
    {
        string[] ShaderCompute { get; set; }
        string[] ShaderFragment { get; set; }
        string[] ShaderGeometry { get; set; }
        string[] ShaderStatus { get; set; }
        string[] ShaderTessControl { get; set; }
        string[] ShaderTessEvaluation { get; set; }
        string[] ShaderVertex { get; set; }
        bool Visible { get; set; }
        double Xmax { get; set; }
        double Xmin { get; set; }
        double Ymax { get; set; }
        double Ymin { get; set; }
        double Zmax { get; set; }
        double Zmin { get; set; }
    }
}
