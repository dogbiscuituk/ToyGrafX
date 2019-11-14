namespace ToyGraf.Views
{
    using System.Windows.Forms;
    using ToyGraf.Controls;

    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
            GLSLStylesPropertyGrid.SelectedObject = new TextStyleInfos();
        }
    }
}
