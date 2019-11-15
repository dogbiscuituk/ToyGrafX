using ToyGraf.Controls;

namespace ToyGraf.Models
{
    public class Options
    {
        public string FilesFolderPath { get; set; }
        public bool OpenInNewWindow { get; set; }
        public bool ShowSystemRO { get; set; }
        public string TemplatesFolderPath { get; set; }
        public TextStyleInfos SyntaxHighlightStyles { get; set; }
    }
}
