namespace ToyGraf.Views
{
    using FastColoredTextBoxNS;
    using System.IO;
    using System.Windows.Forms;

    public partial class FctbForm : Form
    {
        public FctbForm()
        {
            InitializeComponent();
        }

        private void PopupFind_Click(object sender, System.EventArgs e) =>
            TextBox.ShowFindDialog();

        private void PopupReplace_Click(object sender, System.EventArgs e) =>
            TextBox.ShowReplaceDialog();

        private void PopupPrint_Click(object sender, System.EventArgs e) =>
            TextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void PopupSaveAsHTML_Click(object sender, System.EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "HTML with <PRE>|*.html|HTML without <PRE>|*.html" })
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, GetHTML(sfd.FilterIndex));
        }

        private void PopupSaveAsRTF_Click(object sender, System.EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "RTF|*.rtf" })
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, TextBox.Rtf);
        }

        private string GetHTML(int filterIndex)
        {
            switch (filterIndex)
            {
                case 1:
                    return TextBox.Html;
                case 2:
                    ExportToHTML exporter = new ExportToHTML
                    {
                        UseBr = true,
                        UseNbsp = false,
                        UseForwardNbsp = true,
                        UseStyleTag = true
                    };
                    return exporter.GetHtml(TextBox);
                default:
                    return string.Empty;
            }
        }
    }
}
