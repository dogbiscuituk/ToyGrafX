namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using ToyGraf.Controls;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class FctbController
    {
        #region Constructor

        internal FctbController(SceneController sceneController)
            : this(Descriptions.GPUCode)
        {
            SceneController = sceneController;
            Text = Scene.GPUCode;
            SetBreaks(RenderController.Breaks);
        }

        internal FctbController(string caption)
        {
            Editor = new FctbForm() { Text = $"{caption} - GLSL Shader Editor" };
            Editor.ActiveControl = PrimaryTextBox;
            Splitter.SplitterDistance = 0;
            ShowDocumentMap = false;
            PrimaryTextStyleController = new TextStyleController(PrimaryTextBox);
            SecondaryTextStyleController = new TextStyleController(SecondaryTextBox);
            Editor.FileExportHTML.Click += FileExportHTML_Click;
            Editor.FileExportRTF.Click += FileExportRTF_Click;
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
            Editor.ViewDocumentMap.Click += ViewDocumentMap_Click;
            Editor.ViewSplitHorizontal.Click += ViewSplitHorizontal_Click;
            Editor.ViewSplitVertical.Click += ViewSplitVertical_Click;
            Editor.btnOK.Click += BtnOK_Click;
            Editor.btnCancel.Click += BtnCancel_Click;
            Editor.btnApply.Click += BtnApply_Click;
        }

        #endregion

        #region Internal Properties

        internal string Text
        {
            get => PrimaryTextBox.Text;
            set => PrimaryTextBox.Text = value;
        }

        #endregion

        #region Internal Events

        internal event EventHandler<EditEventArgs> Apply;

        #endregion

        #region Internal Methods

        internal bool Execute(IWindowsFormsEditorService service) =>
            service.ShowDialog(Editor) == DialogResult.OK;

        internal bool Execute() =>
            Editor.ShowDialog(SceneController.SceneForm) == DialogResult.OK;

        #endregion

        #region Private Fields

        private SceneController SceneController;
        private readonly TextStyleController PrimaryTextStyleController, SecondaryTextStyleController;

        #endregion

        #region Private Properties

        private RenderController RenderController => SceneController.RenderController;
        private Scene Scene => SceneController.Scene;

        private FctbForm Editor { get; set; }
        private Orientation Orientation { get => Splitter.Orientation; set => Splitter.Orientation = value; }
        private SplitContainer PrimarySplitter => Editor.PrimarySplitter;
        private FastColoredTextBox PrimaryTextBox => Editor.PrimaryTextBox;
        private SplitContainer SecondarySplitter => Editor.SecondarySplitter;
        private FastColoredTextBox SecondaryTextBox => Editor.SecondaryTextBox;
        private SplitContainer Splitter => Editor.Splitter;

        private bool ShowDocumentMap
        {
            get => !PrimarySplitter.Panel2Collapsed;
            set => PrimarySplitter.Panel2Collapsed = SecondarySplitter.Panel2Collapsed = !value;
        }

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
            get => Editor.PrimaryRuler.Visible;
            set
            {
                Editor.PrimaryRuler.Visible = Editor.SecondaryRuler.Visible = value;
                Editor.Refresh();
            }
        }

        #endregion

        #region Private Event Handlers

        private void BtnApply_Click(object sender, System.EventArgs e) =>
            OnApply();

        private void BtnCancel_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.Cancel;

        private void BtnOK_Click(object sender, System.EventArgs e) =>
            Editor.DialogResult = DialogResult.OK;

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

        private void FileExportHTML_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "HTML with <PRE>|*.html|HTML without <PRE>|*.html" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, GetHTML(dialog.FilterIndex));
        }

        private void FileExportRTF_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "RTF|*.rtf" })
                if (dialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dialog.FileName, PrimaryTextBox.Rtf);
        }

        private void FilePrint_Click(object sender, System.EventArgs e) =>
            PrimaryTextBox.Print(new PrintDialogSettings() { ShowPrintPreviewDialog = true });

        private void ViewDocumentMap_Click(object sender, System.EventArgs e) =>
            ShowDocumentMap = !ShowDocumentMap;

        private void ViewLineNumbers_Click(object sender, System.EventArgs e) =>
            ShowLineNumbers = !ShowLineNumbers;

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e)
        {
            Editor.ViewRuler.Checked = ShowRuler;
            Editor.ViewLineNumbers.Checked = ShowLineNumbers;
            Editor.ViewDocumentMap.Checked = ShowDocumentMap;
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

        private void OnApply() => Apply?.Invoke(this, new EditEventArgs(Text));

        private void SetBreaks(List<int> breaks)
        {
            for (var index = 0; index < breaks.Count - 2; index += 2)
            {
                int a = breaks[index] - 1, b = breaks[index + 1] - 1;
                var range = new Range(PrimaryTextBox, 0, a, 0, b);
                PrimaryTextStyleController.AddReadOnlyRange(range);
            }
        }

        private void SetSplit(Orientation orientation)
        {
            Orientation = orientation;
            var size = Orientation == Orientation.Horizontal
                ? Splitter.Height
                : Splitter.Width;
            Splitter.SplitterDistance = size / 2 - 2;
        }

        #endregion
    }
}
