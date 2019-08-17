namespace ToyGraf.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class TraceTableController
    {
        #region Internal Interface

        internal TraceTableController(SceneController sceneController)
        {
            SceneController = sceneController;
            TraceTable = SceneForm.TraceTable;
            TraceTable.AutoGenerateColumns = false;
            TraceTable.SelectionChanged += EntityTable_SelectionChanged;
            SceneForm.EditSelectAll.Click += EditSelectAll_Click;
            SceneForm.EditInvertSelection.Click += EditInvertSelection_Click;
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewTraceTable.Click += ToggleEntityTable;
            SceneForm.PopupTraceTableMenu.Opening += PopupEntityTableMenu_Opening;
            SceneForm.PopupTraceTableFloat.Click += PopupEntityTableDock_Click;
            SceneForm.PopupTraceTableHide.Click += PopupEntityTableHide_Click;
        }

        internal bool EntityTableVisible
        {
            get => !SceneForm.SplitContainer1.Panel2Collapsed;
            set => SceneForm.SplitContainer1.Panel2Collapsed = !value;
        }

        internal event EventHandler SelectionChanged;

        #endregion

        #region Private Properties

        private Scene Scene => SceneController.Scene;
        private readonly SceneController SceneController;

        private HostController _HostController;
        private HostController HostController
        {
            get
            {
                if (_HostController == null)
                    _HostController = new HostController("Trace Table", TraceTable);
                return _HostController;
            }
        }

        private SceneForm SceneForm => SceneController.SceneForm;
        private readonly DataGridView TraceTable;

        private bool TraceTableDocked
        {
            get => TraceTable.FindForm() == SceneForm;
            set
            {
                if (TraceTableDocked != value)
                    if (TraceTableDocked)
                    {
                        EntityTableVisible = false;
                        HostController.HostFormClosing += HostFormClosing;
                        HostController.Show(SceneForm);
                        ResizeRows();
                    }
                    else
                    {
                        HostController.HostFormClosing -= HostFormClosing;
                        HostController.Close();
                        ResizeRows();
                        EntityTableVisible = true;
                    }
            }
        }

        #endregion

        #region Private Event Handlers

        private void EditInvertSelection_Click(object sender, EventArgs e) =>
            InvertSelection();

        private void EditSelectAll_Click(object sender, EventArgs e) =>
            SelectAll();

        private void HostFormClosing(object sender, FormClosingEventArgs e) =>
            TraceTableDocked = true;

        private void PopupEntityTableDock_Click(object sender, System.EventArgs e) =>
            TraceTableDocked = !TraceTableDocked;

        private void PopupEntityTableHide_Click(object sender, EventArgs e)
        {
            TraceTableDocked = true;
            EntityTableVisible = false;
        }

        private void PopupEntityTableMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupTraceTableFloat.Checked = !TraceTableDocked;

        private void ToggleEntityTable(object sender, EventArgs e)
        {
            TraceTableDocked = true;
            EntityTableVisible = !EntityTableVisible;
        }

        private void EntityTable_SelectionChanged(object sender, EventArgs e) =>
            SelectionChanged?.Invoke(sender, e);

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewTraceTable.Checked = EntityTableVisible;

        #endregion

        #region Private Methods

        private void InvertSelection()
        {
            foreach (DataGridViewRow row in TraceTable.Rows)
                row.Selected = !row.Selected;

            SceneController.PropertyGridController.SelectedObject = Scene;
        }

        private void ResizeRows()
        {
            foreach (DataGridViewRow row in TraceTable.Rows)
                row.Height = 18;
        }

        private void SelectAll()
        {
            TraceTable.SelectAll();

            SceneController.PropertyGridController.SelectedObjects = Scene._Traces.ToArray();
        }

        #endregion
    }
}
