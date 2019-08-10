namespace ToyGraf.Models
{
    using ToyGraf.Models.Enums;

    public interface ITrace
    {
        string Shader1Vertex { get; set; }
        string Shader2TessControl { get; set; }
        string Shader3TessEvaluation { get; set; }
        string Shader4Geometry { get; set; }
        string Shader5Fragment { get; set; }
        string Shader6Compute { get; set; }
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
