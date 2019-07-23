namespace ToyGrafXwin.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGrafXwin.Views;

    internal class EntityTableController
    {
        #region Internal Interface

        internal EntityTableController(SceneController sceneController)
        {
            SceneController = sceneController;
            EntityTable = SceneForm.EntityTable;
            EntityTable.AutoGenerateColumns = false;
            EntityTable.SelectionChanged += EntityTable_SelectionChanged;
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewEntityTable.Click += ToggleEntityTable;
            SceneForm.PopupEntityTableMenu.Opening += PopupEntityTableMenu_Opening;
            SceneForm.PopupEntityTableFloat.Click += PopupEntityTableDock_Click;
            SceneForm.PopupEntityTableHide.Click += PopupEntityTableHide_Click;
        }

        internal bool EntityTableVisible
        {
            get => !SceneForm.SplitContainer1.Panel2Collapsed;
            set => SceneForm.SplitContainer1.Panel2Collapsed = !value;
        }

        internal event EventHandler SelectionChanged;

        #endregion

        #region Private Properties

        private readonly SceneController SceneController;

        private HostController _HostController;
        private HostController HostController
        {
            get
            {
                if (_HostController == null)
                    _HostController = new HostController("Entity Table", EntityTable);
                return _HostController;
            }
        }

        private SceneForm SceneForm => SceneController.SceneForm;
        private readonly DataGridView EntityTable;

        private bool EntityTableDocked
        {
            get => EntityTable.FindForm() == SceneForm;
            set
            {
                if (EntityTableDocked != value)
                    if (EntityTableDocked)
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
            EntityTable.SelectAll();

        private void GraphController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var entities = SceneController.Entities;
            EntityTable.DataSource = entities.Any() ? entities : null;
            ResizeRows();
        }

        private void HostFormClosing(object sender, FormClosingEventArgs e) =>
            EntityTableDocked = true;

        private void PopupEntityTableDock_Click(object sender, System.EventArgs e) =>
            EntityTableDocked = !EntityTableDocked;

        private void PopupEntityTableHide_Click(object sender, EventArgs e)
        {
            EntityTableDocked = true;
            EntityTableVisible = false;
        }

        private void PopupEntityTableMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupEntityTableFloat.Checked = !EntityTableDocked;

        private void ToggleEntityTable(object sender, EventArgs e)
        {
            EntityTableDocked = true;
            EntityTableVisible = !EntityTableVisible;
        }

        private void EntityTable_SelectionChanged(object sender, EventArgs e) =>
            SelectionChanged?.Invoke(sender, e);

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewEntityTable.Checked = EntityTableVisible;

        #endregion

        #region Private Methods

        private void InvertSelection()
        {
            foreach (DataGridViewRow row in EntityTable.Rows)
                row.Selected = !row.Selected;
        }

        private void ResizeRows()
        {
            foreach (DataGridViewRow row in EntityTable.Rows)
                row.Height = 18;
        }

        #endregion
    }
}
