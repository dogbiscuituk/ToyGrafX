namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
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
            TraceTable.SelectionChanged += TraceTable_SelectionChanged;
            SceneForm.EditSelectAll.Click += EditSelectAll_Click;
            SceneForm.EditInvertSelection.Click += EditInvertSelection_Click;
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewTraceTable.Click += ToggleTraceTable;
            SceneForm.PopupTraceTableMenu.Opening += PopupTraceTableMenu_Opening;
            SceneForm.PopupTraceTableFloat.Click += PopupTraceTableDock_Click;
            SceneForm.PopupTraceTableHide.Click += PopupTraceTableHide_Click;
            SceneForm.PopupTraceTableColumns.Click += PopupTraceTableColumns_Click;

            RefreshDataSource();
        }

        private void RefreshDataSource()
        {
            var traces = Scene._Traces;
            TraceTable.DataSource = traces.Any() ? traces : null;
            ResizeRows();
        }

        internal IEnumerable<Trace> Selection => TraceTable.SelectedRows
            .OfType<DataGridViewRow>()
            .Select(p => p.DataBoundItem)
            .Cast<Trace>();

        internal readonly DataGridView TraceTable;

        internal bool TraceTableVisible
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

        private bool TraceTableDocked
        {
            get => TraceTable.FindForm() == SceneForm;
            set
            {
                if (TraceTableDocked != value)
                    if (TraceTableDocked)
                    {
                        TraceTableVisible = false;
                        HostController.HostFormClosing += HostFormClosing;
                        HostController.Show(SceneForm);
                        ResizeRows();
                    }
                    else
                    {
                        HostController.HostFormClosing -= HostFormClosing;
                        HostController.Close();
                        ResizeRows();
                        TraceTableVisible = true;
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

        private void PopupTraceTableColumns_Click(object sender, EventArgs e) =>
            new ColumnsController(this).ShowDialog(SceneForm);

        private void PopupTraceTableDock_Click(object sender, System.EventArgs e) =>
            TraceTableDocked = !TraceTableDocked;

        private void PopupTraceTableHide_Click(object sender, EventArgs e)
        {
            TraceTableDocked = true;
            TraceTableVisible = false;
        }

        private void PopupTraceTableMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupTraceTableFloat.Text = TraceTableDocked ? "&Undock" : "&Dock";

        private void ToggleTraceTable(object sender, EventArgs e)
        {
            TraceTableDocked = true;
            TraceTableVisible = !TraceTableVisible;
        }

        private void TraceTable_SelectionChanged(object sender, EventArgs e) =>
            SelectionChanged?.Invoke(sender, e);

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewTraceTable.Checked = TraceTableVisible;

        #endregion

        #region Private Methods

        private void InvertSelection()
        {
            RefreshDataSource();

            foreach (DataGridViewRow row in TraceTable.Rows)
                row.Selected = !row.Selected;

            //SceneController.PropertyGridController.SelectedObject = Scene;
        }

        private void ResizeRows()
        {
            foreach (DataGridViewRow row in TraceTable.Rows)
                row.Height = 18;
        }

        private void SelectAll()
        {
            RefreshDataSource();

            TraceTable.SelectAll();

            //SceneController.PropertyGridController.SelectedObjects = Scene._Traces.ToArray();
        }

        #endregion
    }
}
