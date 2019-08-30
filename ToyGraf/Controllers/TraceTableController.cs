// <copyright file="TraceTableController.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

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
        internal TraceTableController(SceneController sceneController)
        {
            SceneController = sceneController;
            Init();
            Refresh();
        }

        internal IEnumerable<Trace> Selection => TraceTable.SelectedRows
            .OfType<DataGridViewRow>()
            .Select(p => p.DataBoundItem)
            .Where(p => p != null)
            .Cast<Trace>();

        internal DataGridView TraceTable => SceneForm.TraceTable;

        internal bool TraceTableVisible
        {
            get => !SceneForm.SplitContainer1.Panel2Collapsed;
            set => SceneForm.SplitContainer1.Panel2Collapsed = !value;
        }

        internal void Refresh()
        {
            TraceTable.DataSource = null;
            var traces = Scene.Traces;
            if (traces.Any())
                TraceTable.DataSource = traces;
        }

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
                    }
                    else
                    {
                        HostController.HostFormClosing -= HostFormClosing;
                        HostController.Close();
                        TraceTableVisible = true;
                    }
            }
        }

        private bool Updating;

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

        private void TraceTable_SelectionChanged(object sender, EventArgs e) => OnSelectionChanged();

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewTraceTable.Checked = TraceTableVisible;

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
            SceneForm.ViewTraceTable.Click += ToggleTraceTable;
            SceneForm.PopupTraceTableMenu.Opening += PopupTraceTableMenu_Opening;
            SceneForm.PopupTraceTableFloat.Click += PopupTraceTableDock_Click;
            SceneForm.PopupTraceTableHide.Click += PopupTraceTableHide_Click;
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
    }
}
