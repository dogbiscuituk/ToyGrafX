namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class ColumnsController
    {
        #region Internal Interface

        internal ColumnsController(TraceTableController traceTableController)
        {
            TraceTableController = traceTableController;
            ColumnsDialog = new ColumnsDialog();
            ColumnsDialog.cbAll.CheckedChanged += CbAll_CheckedChanged;
            ColumnsDialog.ColumnsListBox.ItemCheck += ColumnsListBox_ItemCheck;
        }

        internal void ShowDialog(IWin32Window owner)
        {
            LoadColumns();
            if (ColumnsDialog.ShowDialog(owner) == DialogResult.OK)
                SaveColumns();
        }

        #endregion

        #region Private Event Handlers

        private void CbAll_CheckedChanged(object sender, System.EventArgs e) => UpdateCheckBoxes();
        private void ColumnsListBox_ItemCheck(object sender, ItemCheckEventArgs e) => UpdateCbAll(e.Index, e.NewValue);

        #endregion

        #region Private Properties

        private DataGridViewColumnCollection Columns => TraceTable.Columns;
        private readonly ColumnsDialog ColumnsDialog;
        private CheckedListBox ColumnsListBox => ColumnsDialog.ColumnsListBox;
        private CheckedListBox.ObjectCollection Items => ColumnsListBox.Items;
        private DataGridView TraceTable => TraceTableController.TraceTable;
        private readonly TraceTableController TraceTableController;

        #endregion

        #region PrivateMethods

        private void LoadColumns()
        {
            Updating = true;
            for (var index = 0; index < Columns.Count; index++)
            {
                var column = Columns[index];
                Items.Add(column.HeaderText, column.Visible);
            }
            Updating = false;
            UpdateCbAll();
        }

        private void SaveColumns()
        {
            for (var index = 0; index < Items.Count; index++)
                Columns[index].Visible = ColumnsListBox.GetItemChecked(index);
        }

        private bool Updating;

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

        #endregion
    }
}