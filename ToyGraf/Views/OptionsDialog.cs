namespace ToyGraf.Views
{
    using System.Windows.Forms;
    using ToyGraf.Models;

    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = new TextStyleInfos();
        }
    }
}
