namespace ToyGraf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class TraceTableController : HostController
    {
        #region Constructor

        internal TraceTableController(SceneController sceneController)
            : base(sceneController, "Trace Table")
        {
            Init();
            Refresh();
        }

        #endregion

        #region Internal Properties

        internal IEnumerable<Trace> Selection => TraceTable.SelectedRows
            .OfType<DataGridViewRow>()
            .Select(p => p.DataBoundItem)
            .Where(p => p != null)
            .Cast<Trace>();

        internal DataGridView TraceTable => SceneForm.TraceTable;

        #endregion

        #region Protected Internal Methods

        protected internal override void Refresh()
        {
            if (EditorVisible)
            {
                TraceTable.DataSource = null;
                var traces = Scene.Traces;
                if (traces.Any())
                    TraceTable.DataSource = traces;
            }
        }

        #endregion

        #region Protected Properties

        protected override Control Editor => TraceTable;
        protected override Control EditorParent => SceneForm.SplitContainer1.Panel2;

        #endregion

        #region Protected Methods

        protected override void Collapse(bool collapse) => SceneForm.SplitContainer1.Panel2Collapsed = collapse;

        #endregion

        #region Private Properties

        private bool Updating;

        #endregion

        #region Private Event Handlers

        private void EditInvertSelection_Click(object sender, EventArgs e) =>
            InvertSelection();

        private void EditSelectAll_Click(object sender, EventArgs e) =>
            SelectAll();

        private void PopupTraceTableColumns_Click(object sender, EventArgs e) =>
            new ColumnsController(this).ShowDialog(Editor);

        private void PopupTraceTableMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupTraceTableFloat.Text = EditorDocked ? "&Undock" : "&Dock";

        private void TraceTable_SelectionChanged(object sender, EventArgs e) =>
            OnSelectionChanged();

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewTraceTable.Checked = EditorVisible;

        #endregion

        #region Private Methods

        private void Init()
        {
            InitSceneForm();
            InitTraceTable();
            InitColumns();
        }

        private void InitColumns()
        {
            SceneForm.colDescription.ToolTipText = Descriptions.Description;
            SceneForm.colLocation.ToolTipText = Descriptions.Location;
            SceneForm.colMaximum.ToolTipText = Descriptions.Maximum;
            SceneForm.colMinimum.ToolTipText = Descriptions.Minimum;
            SceneForm.colOrientation.ToolTipText = Descriptions.Orientation;
            SceneForm.colPattern.ToolTipText = Descriptions.Pattern;
            SceneForm.colScale.ToolTipText = Descriptions.Scale;
            SceneForm.colShader1Vertex.ToolTipText = Descriptions.Shader1Vertex;
            SceneForm.colShader2TessControl.ToolTipText = Descriptions.Shader2TessControl;
            SceneForm.colShader3TessEvaluation.ToolTipText = Descriptions.Shader3TessEvaluation;
            SceneForm.colShader4Geometry.ToolTipText = Descriptions.Shader4Geometry;
            SceneForm.colShader5Fragment.ToolTipText = Descriptions.Shader5Fragment;
            SceneForm.colShader6Compute.ToolTipText = Descriptions.Shader6Compute;
            SceneForm.colStrip.ToolTipText = Descriptions.StripCount;
            SceneForm.colVisible.ToolTipText = Descriptions.Visible;
        }

        private void InitSceneForm()
        {
            SceneForm.EditSelectAll.Click += EditSelectAll_Click;
            SceneForm.EditInvertSelection.Click += EditInvertSelection_Click;
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewTraceTable.Click += ToggleEditor;
            SceneForm.PopupTraceTableMenu.Opening += PopupTraceTableMenu_Opening;
            SceneForm.PopupTraceTableFloat.Click += PopupEditorFloat_Click;
            SceneForm.PopupTraceTableHide.Click += PopupEditorHide_Click;
            SceneForm.PopupTraceTableColumns.Click += PopupTraceTableColumns_Click;
        }

        private void InitTraceTable()
        {
            TraceTable.AutoGenerateColumns = false;
            TraceTable.SelectionChanged += TraceTable_SelectionChanged;
        }

        private void InvertSelection()
        {
            Updating = true;
            foreach (DataGridViewRow row in TraceTable.Rows)
                row.Selected = !row.Selected;
            Updating = false;
            OnSelectionChanged();
        }

        private void OnSelectionChanged()
        {
            if (!Updating)
                SceneController.OnSelectionChanged();
        }

        private void SelectAll() => TraceTable.SelectAll();

        #endregion
    }
}
