namespace ToyGraf.Models
{
    using ToyGraf.Models.Enums;

    public interface ITrace
    {
        string Shader1_Vertex { get; set; }
        string Shader2_TessControl { get; set; }
        string Shader3_TessEvaluation { get; set; }
        string Shader4_Geometry { get; set; }
        string Shader5_Fragment { get; set; }
        string Shader6_Compute { get; set; }
        string GPUStatus { get; }
        YN Visible { get; set; }
        double Xmax { get; set; }
        double Xmin { get; set; }
        double Ymax { get; set; }
        double Ymin { get; set; }
        double Zmax { get; set; }
        double Zmin { get; set; }
    }
}
