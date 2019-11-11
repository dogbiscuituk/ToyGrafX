namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Controls;
    using ToyGraf.Views;

    internal class EntityEditController : DockableEditController
    {
        #region Constructor

        internal EntityEditController(SceneController sceneController)
            : base(sceneController, "Entity Editor")
        {
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.PopupEntityEditMenu.Opening += PopupEntityEditMenu_Opening;
            SceneForm.PopupEntityEditFloat.Click += PopupEntityEditFloat_Click;
            SceneForm.PopupEntityEditHide.Click += PopupEntityEditHide_Click;
        }

        #endregion

        #region Protected Overrides

        protected override Control EditControl => EntityEdit;

        protected internal override void Refresh()
        {

        }

        protected override void UpdateConfiguration()
        {
            SceneForm.SplitContainer3.Panel2Collapsed = !(_EditControlDocked && _EditControlVisible);
            HostController.FormVisible = !_EditControlDocked && _EditControlVisible;

        }

        #endregion

        #region Private Properties

        private TgEntityEdit EntityEdit => SceneForm.EntityEdit;

        #endregion

        #region Private Event Handlers

        private void HostController_HostFormClosing(object sender, FormClosingEventArgs e) =>
            EditControlVisible = false;

        private void PopupEntityEditFloat_Click(object sender, System.EventArgs e) =>
            EditControlDocked = !EditControlDocked;

        private void PopupEntityEditHide_Click(object sender, System.EventArgs e) =>
            EditControlVisible = false;

        private void PopupEntityEditMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) =>
            SceneForm.PopupEntityEditFloat.Text = EditControlDocked ? "&Undock" : "&Dock";

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e) =>
            SceneForm.ViewEntityEditor.Checked = EditControlVisible;

        #endregion
    }
}
