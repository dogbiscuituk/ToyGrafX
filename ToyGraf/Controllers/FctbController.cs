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
            Editor.ActiveControl = PrimaryTextBox; // Do not add to initializer!
            Splitter.SplitterDistance = 0;
            new TextStyleController(PrimaryTextBox);
            new TextStyleController(SecondaryTextBox);
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
            Editor.ViewSplitHorizontal.Click += ViewSplitHorizontal_Click;
            Editor.ViewSplitVertical.Click += ViewSplitVertical_Click;
            Editor.ViewLineNumbers.Click += ViewLineNumbers_Click;
            Editor.btnOK.Click += BtnOK_Click;
            Editor.btnCancel.Click += BtnCancel_Click;
        }

        #endregion

        #region Internal Properties

        internal FctbForm Editor { get; set; }

        #endregion

        #region Private Fields & Properties

        private Orientation Orientation { get => Splitter.Orientation; set => Splitter.Orientation = value; }
        private FastColoredTextBox PrimaryTextBox => Editor.PrimaryTextBox;
        private FastColoredTextBox SecondaryTextBox => Editor.SecondaryTextBox;
        private SplitContainer Splitter => Editor.SplitContainer;

        #endregion

        #region Private Event Handlers

        private void BtnCancel_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.OK;

        private void BtnOK_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.Cancel;

        private void EditComment_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.InsertLinePrefix(PrimaryTextBox.CommentPrefix);

        private void EditDecreaseIndent_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.DecreaseIndent();

        private void EditFind_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.ShowFindDialog();

        private void EditIncreaseIndent_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.IncreaseIndent();

        private void EditReplace_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.ShowReplaceDialog();

        private void EditUncomment_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.RemoveLinePrefix(PrimaryTextBox.CommentPrefix);

        private void FilePrint_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void FileSaveAsHTML_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "HTML with <PRE>|*.html|HTML without <PRE>|*.html" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, GetHTML(dialog.FilterIndex));
        }

        private void FileSaveAsRTF_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "RTF|*.rtf" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, PrimaryTextBox.Rtf);
        }

        private void ViewLineNumbers_Click(object sender, System.EventArgs e) =>
            ShowLineNumbers = !ShowLineNumbers;

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e)
        {
            Editor.ViewRuler.Checked = ShowRuler;
            Editor.ViewLineNumbers.Checked = ShowLineNumbers;
            Editor.ViewSplitHorizontal.Checked = Orientation == Orientation.Horizontal;
            Editor.ViewSplitVertical.Checked = Orientation == Orientation.Vertical;
        }

        private void ViewRuler_Click(object sender, System.EventArgs e) =>
            ShowRuler = !ShowRuler;

        private void ViewSplitHorizontal_Click(object sender, System.EventArgs e) =>
            SetSplit(Orientation.Horizontal);

        private void ViewSplitVertical_Click(object sender, System.EventArgs e) =>
            SetSplit(Orientation.Vertical);

        #endregion

        #region Private Properties

        private bool ShowLineNumbers
        {
            get => PrimaryTextBox.ShowLineNumbers;
            set
            {
                PrimaryTextBox.ShowLineNumbers = SecondaryTextBox.ShowLineNumbers = value;
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
                    return PrimaryTextBox.Html;
                case 2:
                    return new ExportToHTML { UseNbsp = false, UseForwardNbsp = true }.GetHtml(PrimaryTextBox);
                default:
                    return string.Empty;
            }
        }

        private void SetSplit(Orientation orientation)
        {
            Orientation = orientation;
            Splitter.SplitterDistance = Orientation == Orientation.Horizontal
                ? Splitter.Height / 2
                : Splitter.Width / 2;
        }

        #endregion
    }
}
