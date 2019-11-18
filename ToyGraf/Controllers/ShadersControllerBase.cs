namespace ToyGraf.Controllers
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal abstract class ShadersControllerBase
    {
        #region Constructor

        protected ShadersControllerBase(string caption)
        {
            ColumnsDialog = new ColumnsDialog { Text = caption };
            ColumnsDialog.cbAll.CheckedChanged += CbAll_CheckedChanged;
            ColumnsDialog.ColumnsListBox.ItemCheck += ColumnsListBox_ItemCheck;
        }

        #endregion

        #region Internal Methods

        internal void ShowDialog(Control editor)
        {
            Updating = true;
            LoadItems();
            Updating = false;
            UpdateCbAll();
            ColumnsDialog.Location = editor.PointToScreen(editor.Location);
            ColumnsDialog.Size = new Size(ColumnsDialog.Width, 18 * Items.Count + 130);
            if (ColumnsDialog.ShowDialog(editor.FindForm()) == DialogResult.OK)
                SaveItems();
        }

        #endregion

        #region Protected Properties

        protected CheckedListBox ColumnsListBox => ColumnsDialog.ColumnsListBox;
        protected CheckedListBox.ObjectCollection Items => ColumnsListBox.Items;

        #endregion

        #region Protected Abstract Methods

        protected abstract void LoadItems();
        protected abstract void SaveItems();

        #endregion

        #region Private Fields

        private readonly ColumnsDialog ColumnsDialog;
        private bool Updating;

        #endregion

        #region Private Event Handlers

        private void CbAll_CheckedChanged(object sender, EventArgs e) => UpdateCheckBoxes();
        private void ColumnsListBox_ItemCheck(object sender, ItemCheckEventArgs e) => UpdateCbAll(e.Index, e.NewValue);

        #endregion

        #region Private Methods

        private void UpdateCheckBoxes()
        {
            if (Updating)
                return;
            Updating = true;
            var check = ColumnsDialog.cbAll.Checked;
            for (var index = 0; index < Items.Count; index++)
                ColumnsListBox.SetItemChecked(index, check);
            Updating = false;
        }

        private void UpdateCbAll(int changedIndex = -1, CheckState newCheckState = CheckState.Indeterminate)
        {
            if (Updating)
                return;
            Updating = true;
            bool allChecked = true, allUnchecked = true;
            for (var index = 0; index < Items.Count; index++)
            {
                var check = index == changedIndex
                    ? newCheckState == CheckState.Checked
                    : ColumnsListBox.GetItemChecked(index);
                allChecked &= check;
                allUnchecked &= !check;
                if (!(allChecked || allUnchecked))
                    break;
            }
            ColumnsDialog.cbAll.CheckState = allChecked
                ? CheckState.Checked
                : allUnchecked
                ? CheckState.Unchecked
                : CheckState.Indeterminate;
            Updating = false;
        }

        #endregion
    }
}
