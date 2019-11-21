namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System.IO;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class FctbController
    {
        #region Constructor

        internal FctbController()
        {
            Editor = new FctbForm();
            Editor.MainMenu.CloneTo(Editor.PopupMenu);
        }

        #endregion

        #region Internal Properties

        internal FctbForm Editor
        {
            get => _Editor;
            set
            {
                _Editor = value;
                Editor.FileSaveAsHTML.Click += FileSaveAsHTML_Click;
                Editor.FileSaveAsRTF.Click += FileSaveAsRTF_Click;
                Editor.FilePrint.Click += FilePrint_Click;
                Editor.EditFind.Click += EditFind_Click;
                Editor.EditReplace.Click += EditReplace_Click;
                Editor.EditComment.Click += EditComment_Click;
                Editor.EditUncomment.Click += EditUncomment_Click;
                Editor.EditIncreaseIndent.Click += EditIncreaseIndent_Click;
                Editor.EditDecreaseIndent.Click += EditDecreaseIndent_Click;
                Editor.btnOK.Click += BtnOK_Click;
                Editor.btnCancel.Click += BtnCancel_Click;
            }
        }

        #endregion

        #region Private Fields & Properties

        private FctbForm _Editor;
        private FastColoredTextBox TextBox => Editor.TextBox2;

        #endregion

        #region Private Event Handlers

        private void BtnCancel_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.OK;

        private void BtnOK_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.Cancel;

        private void EditComment_Click(object sender, System.EventArgs e) =>
            TextBox.InsertLinePrefix(TextBox.CommentPrefix);

        private void EditDecreaseIndent_Click(object sender, System.EventArgs e) =>
            TextBox.DecreaseIndent();

        private void EditFind_Click(object sender, System.EventArgs e) =>
            TextBox.ShowFindDialog();

        private void EditIncreaseIndent_Click(object sender, System.EventArgs e) =>
            TextBox.IncreaseIndent();

        private void EditReplace_Click(object sender, System.EventArgs e) =>
            TextBox.ShowReplaceDialog();

        private void EditUncomment_Click(object sender, System.EventArgs e) =>
            TextBox.RemoveLinePrefix(TextBox.CommentPrefix);

        private void FilePrint_Click(object sender, System.EventArgs e) =>
            TextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void FileSaveAsHTML_Click(object sender, System.EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "HTML with <PRE>|*.html|HTML without <PRE>|*.html" })
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, GetHTML(sfd.FilterIndex));
        }

        private void FileSaveAsRTF_Click(object sender, System.EventArgs e)
        {
            using (var sfd = new SaveFileDialog { Filter = "RTF|*.rtf" })
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, TextBox.Rtf);
        }

        #endregion

        #region Private Methods

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

        #endregion
    }
}
