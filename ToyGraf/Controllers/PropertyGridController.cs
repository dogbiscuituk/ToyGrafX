namespace ToyGraf.Controllers
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Controls;
    using ToyGraf.Common.Utility;
    using ToyGraf.Models;
    using ToyGraf.Views;

    internal class PropertyGridController : DockableEditController
    {
        #region Constructor

        internal PropertyGridController(SceneController sceneController)
            : base(sceneController, "Property Grid")
        {
            PropertyGridAdapter = new TgPropertyGridAdapter(PropertyGrid)
            {
                HiddenProperties = new[] { "Traces" }
            };
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewPropertyGrid.Click += TogglePropertyGrid;
            SceneForm.PopupPropertyGridMenu.Opening += PopupPropertyGridMenu_Opening;
            SceneForm.PopupPropertyGridFloat.Click += PopupPropertyGridDock_Click;
            SceneForm.PopupPropertyGridHide.Click += PopupPropertyGridHide_Click;
            SceneForm.PopupSubjectMenu.Opening += PopupSubjectMenu_Opening;
            SceneForm.PopupSubjectScene.Click += PopupSubject_Click;
            SceneForm.PopupSubjectSelectedTraces.Click += PopupSubject_Click;
            SceneForm.PopupSubjectAllTraces.Click += PopupSubject_Click;
            var toolStrip = FindToolStrip(PropertyGrid);
            HidePropertyPagesButton(toolStrip);
            AddToolstripItems(toolStrip);
            PropertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
            Refresh();
        }

        #endregion

        #region Internal Properties

        internal TgPropertyGridAdapter PropertyGridAdapter;

        internal object SelectedObject
        {
            get => PropertyGridAdapter.SelectedObject;
            set => PropertyGridAdapter.SelectedObject = value;
        }

        internal object[] SelectedObjects
        {
            get => PropertyGridAdapter.SelectedObjects;
            set => PropertyGridAdapter.SelectedObjects = value;
        }

        #endregion

        #region Internal Methods

        internal void ApplyOptions() => InitShowSystemRO(PropertyGridAdapter);

        internal static void HidePropertyPagesButton(PropertyGrid propertyGrid) =>
            HidePropertyPagesButton(FindToolStrip(propertyGrid));

        internal static void InitShowSystemRO(TgPropertyGridAdapter propertyGridAdapter) =>
            propertyGridAdapter.HiddenAttributes = AppController.Options.ShowSystemRO
                ? null : new AttributeCollection(new CategoryAttribute(Categories.SystemRO));

        #endregion

        protected override Control EditControl => PropertyGrid;

        protected internal override void Refresh()
        {
            if (EditControlVisible)
            {
                RefreshDataSource();
                PropertyGrid.Refresh();
            }
        }

        protected override void UpdateConfiguration()
        {
            SceneForm.SplitContainer2.Panel2Collapsed = !(_EditControlDocked && _EditControlVisible);
            HostController.FormVisible = !_EditControlDocked && _EditControlVisible;
        }

        #region Private Classes

        private enum Subject
        {
            Scene,
            SelectedTraces,
            AllTraces
        }

        #endregion

        #region Private Properties

        private PropertyGrid PropertyGrid => SceneForm.PropertyGrid;

        private Subject _SelectedSubject = Subject.Scene;
        private Subject SelectedSubject
        {
            get => _SelectedSubject;
            set
            {
                if (SelectedSubject != value)
                    SelectSubject(value);
            }
        }

        private ToolStripSplitButton SubjectButton;
        private TraceTableController TraceTableController => SceneController.TraceTableController;

        #endregion

        #region Private Event Handlers

        private void PopupPropertyGridDock_Click(object sender, EventArgs e) =>
            EditControlDocked = !EditControlDocked;

        private void PopupPropertyGridHide_Click(object sender, EventArgs e) =>
            EditControlVisible = false;

        private void PopupPropertyGridMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupPropertyGridFloat.Text = EditControlDocked ? "&Undock" : "&Dock";

        private void PopupSubjectMenu_Opening(object sender, CancelEventArgs e)
        {
            var items = ((ToolStrip)sender).Items;
            for (int index = 0; index < items.Count; index++)
                ((ToolStripMenuItem)items[index]).Checked = index == (int)SelectedSubject;
        }

        private void PopupSubject_Click(object sender, System.EventArgs e) =>
            SelectSubject((ToolStripItem)sender);

        private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e) =>
            SceneController?.PropertyChanged(e);

        private void SceneController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            PropertyChanged();

        private void SubjectButton_ButtonClick(object sender, System.EventArgs e) => SelectNextSubject();

        private void TogglePropertyGrid(object sender, EventArgs e) =>
            EditControlVisible = !EditControlVisible;

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewPropertyGrid.Checked = EditControlVisible;

        #endregion

        #region Private Methods

        private void AddToolstripItems(ToolStrip toolStrip)
        {
            SubjectButton = new ToolStripSplitButton
            {
                DropDown = SceneForm.PopupSubjectMenu
            };
            SubjectButton.ButtonClick += SubjectButton_ButtonClick;
            toolStrip.Items.Add(SubjectButton);
            SelectSubject(Subject.Scene);
        }

        private static ToolStrip FindToolStrip(PropertyGrid propertyGrid) =>
            propertyGrid.Controls.OfType<ToolStrip>().FirstOrDefault();

        private static void HidePropertyPagesButton(ToolStrip toolStrip)
        {
            toolStrip.Items[4].Visible = false; // Property Pages
            toolStrip.Items[3].Visible = false; // Separator
        }

        private void PropertyChanged() => PropertyGrid.Refresh();

        private void RefreshDataSource()
        {
            switch (SelectedSubject)
            {
                case Subject.Scene:
                    SelectedObject = Scene;
                    break;
                case Subject.SelectedTraces:
                    SelectedObjects = TraceTableController.Selection.ToArray();
                    break;
                case Subject.AllTraces:
                    SelectedObjects = Scene.TraceList.ToArray();
                    break;
            }
        }

        private void SelectNextSubject() =>
            SelectedSubject = SelectedSubject == Subject.AllTraces
            ? Subject.Scene
            : SelectedSubject + 1;

        private void SelectSubject(ToolStripItem item) =>
            SelectedSubject = (Subject)SceneForm.PopupSubjectMenu.Items.IndexOf(item);

        private void SelectSubject(Subject subject)
        {
            _SelectedSubject = subject;
            SubjectButton.Text = SceneForm.PopupSubjectMenu.Items[(int)subject].Text;
            RefreshDataSource();
        }

        #endregion
    }
}
