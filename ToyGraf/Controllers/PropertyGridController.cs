namespace ToyGraf.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class PropertyGridController
    {
        #region Internal Interface

        internal PropertyGridController(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewPropertyGrid.Click += TogglePropertyGrid;
            SceneForm.PopupPropertyGridMenu.Opening += PopupPropertyGridMenu_Opening;
            SceneForm.PopupPropertyGridFloat.Click += PopupPropertyGridDock_Click;
            SceneForm.PopupPropertyGridHide.Click += PopupPropertyGridHide_Click;
            var toolStrip = FindToolStrip(PropertyGrid);
            HidePropertyPagesButton(toolStrip);
            AddTitleLabel(toolStrip);
            PropertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
        }

        internal PropertyGrid PropertyGrid => SceneForm.PropertyGrid;

        internal bool PropertyGridVisible
        {
            get => !SceneForm.SplitContainer2.Panel2Collapsed;
            set => SceneForm.SplitContainer2.Panel2Collapsed = !value;
        }

        internal object SelectedObject
        {
            get => PropertyGrid.SelectedObject;
            set => PropertyGrid.SelectedObject = value;
        }

        internal object[] SelectedObjects
        {
            get => PropertyGrid.SelectedObjects;
            set => PropertyGrid.SelectedObjects = value;
        }

        internal static void HidePropertyPagesButton(PropertyGrid propertyGrid) =>
            HidePropertyPagesButton(FindToolStrip(propertyGrid));

        internal void Refresh() => PropertyGrid.Refresh();

        #endregion

        #region Private Properties

        private readonly SceneController SceneController;

        private HostController _HostController;
        private HostController HostController
        {
            get
            {
                if (_HostController == null)
                    _HostController = new HostController("Property Grid", PropertyGrid);
                return _HostController;
            }
        }

        private SceneForm SceneForm => SceneController.SceneForm;

        private bool PropertyGridDocked
        {
            get => PropertyGrid.FindForm() == SceneForm;
            set
            {
                if (PropertyGridDocked != value)
                    if (PropertyGridDocked)
                    {
                        PropertyGridVisible = false;
                        HostController.HostFormClosing += HostFormClosing;
                        HostController.Show(SceneForm);
                    }
                    else
                    {
                        HostController.HostFormClosing -= HostFormClosing;
                        HostController.Close();
                        PropertyGridVisible = true;
                    }
            }
        }

        private ToolStripLabel TitleLabel;

        #endregion

        #region Private Event Handlers

        private void HostFormClosing(object sender, FormClosingEventArgs e) =>
            PropertyGridDocked = true;

        private void PopupPropertyGridDock_Click(object sender, EventArgs e) =>
            PropertyGridDocked = !PropertyGridDocked;

        private void PopupPropertyGridHide_Click(object sender, EventArgs e)
        {
            PropertyGridDocked = true;
            PropertyGridVisible = false;
        }

        private void PopupPropertyGridMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupPropertyGridFloat.Text = PropertyGridDocked ? "&Undock" : "&Dock";

        private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e) =>
            SceneController?.PropertyChanged(e);

        private void SceneController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            PropertyChanged();

        private void TogglePropertyGrid(object sender, EventArgs e)
        {
            PropertyGridDocked = true;
            PropertyGridVisible = !PropertyGridVisible;
        }

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewPropertyGrid.Checked = PropertyGridVisible;

        #endregion

        #region Private Methods

        private void AddTitleLabel(ToolStrip toolStrip)
        {
            TitleLabel = new ToolStripLabel
            {
                Alignment = ToolStripItemAlignment.Right,
                Text = "Properties"
            };
            toolStrip.Items.Add(TitleLabel);
        }

        private static ToolStrip FindToolStrip(PropertyGrid propertyGrid) =>
            propertyGrid.Controls.OfType<ToolStrip>().FirstOrDefault();

        private static void HidePropertyPagesButton(ToolStrip toolStrip)
        {
            toolStrip.Items[4].Visible = false; // Property Pages
            toolStrip.Items[3].Visible = false; // Separator
        }

        private void PropertyChanged() => PropertyGrid.Refresh();

        #endregion
    }
}
