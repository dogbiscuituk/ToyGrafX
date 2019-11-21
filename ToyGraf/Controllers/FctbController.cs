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
            Editor.ActiveControl = MasterTextBox;
            Editor.SplitContainer.SplitterDistance = 0;
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
                Editor.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
                Editor.ViewRuler.Click += ViewRuler_Click;
                Editor.ViewLineNumbers.Click += ViewLineNumbers_Click;
                Editor.btnOK.Click += BtnOK_Click;
                Editor.btnCancel.Click += BtnCancel_Click;
            }
        }

        #endregion

        #region Private Fields & Properties

        private FctbForm _Editor;
        private FastColoredTextBox MasterTextBox => Editor.MasterTextBox;
        private FastColoredTextBox SlaveTextBox => Editor.SlaveTextBox;

        #endregion

        #region Private Event Handlers

        private void BtnCancel_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.OK;

        private void BtnOK_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.Cancel;

        private void EditComment_Click(object sender, System.EventArgs e) =>
            MasterTextBox.InsertLinePrefix(MasterTextBox.CommentPrefix);

        private void EditDecreaseIndent_Click(object sender, System.EventArgs e) =>
            MasterTextBox.DecreaseIndent();

        private void EditFind_Click(object sender, System.EventArgs e) =>
            MasterTextBox.ShowFindDialog();

        private void EditIncreaseIndent_Click(object sender, System.EventArgs e) =>
            MasterTextBox.IncreaseIndent();

        private void EditReplace_Click(object sender, System.EventArgs e) =>
            MasterTextBox.ShowReplaceDialog();

        private void EditUncomment_Click(object sender, System.EventArgs e) =>
            MasterTextBox.RemoveLinePrefix(MasterTextBox.CommentPrefix);

        private void FilePrint_Click(object sender, System.EventArgs e) =>
            MasterTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

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
                    File.WriteAllText(sfd.FileName, MasterTextBox.Rtf);
        }

        private void ViewLineNumbers_Click(object sender, System.EventArgs e) =>
            ShowLineNumbers = !ShowLineNumbers;

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e)
        {
            Editor.ViewRuler.Checked = ShowRuler;
            Editor.ViewLineNumbers.Checked = ShowLineNumbers;
        }

        private void ViewRuler_Click(object sender, System.EventArgs e) =>
            ShowRuler = !ShowRuler;

        #endregion

        #region Private Properties

        private bool ShowLineNumbers
        {
            get => MasterTextBox.ShowLineNumbers;
            set
            {
                MasterTextBox.ShowLineNumbers = SlaveTextBox.ShowLineNumbers = value;
                Editor.Refresh();
            }
        }

        private bool ShowRuler
        {
            get => Editor.MasterRuler.Visible;
            set
            {
                Editor.MasterRuler.Visible = Editor.SlaveRuler.Visible = value;
                Editor.Refresh();
            }
        }

        #endregion

        #region Private Methods

        private string GetHTML(int filterIndex)
        {
            switch (filterIndex)
            {
                case 1:
                    return MasterTextBox.Html;
                case 2:
                    ExportToHTML exporter = new ExportToHTML
                    {
                        UseBr = true,
                        UseNbsp = false,
                        UseForwardNbsp = true,
                        UseStyleTag = true
                    };
                    return exporter.GetHtml(MasterTextBox);
                default:
                    return string.Empty;
            }
        }

        #endregion
    }
}
