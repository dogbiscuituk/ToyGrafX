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
            SceneForm.ViewEntityEditor.Click += ToggleEditControl;
            SceneForm.PopupEntityEditMenu.Opening += PopupEntityEditMenu_Opening;
            SceneForm.PopupEntityEditFloat.Click += PopupEditControlFloat_Click;
            SceneForm.PopupEntityEditHide.Click += PopupEditControlHide_Click;
        }

        #endregion

        #region Protected Overrides

        protected override Control EditControl => EntityEdit;

        protected internal override void Refresh()
        {

        }

        protected override void UpdateConfiguration()
        {
            SceneForm.SplitContainer3.Panel1Collapsed = !(_EditControlDocked && _EditControlVisible);
            HostController.FormVisible = !_EditControlDocked && _EditControlVisible;

        }

        #endregion

        #region Private Properties

        private TgEntityEdit EntityEdit => SceneForm.EntityEdit;

        #endregion

        #region Private Event Handlers

        private void PopupEntityEditMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) =>
            SceneForm.PopupEntityEditFloat.Text = EditControlDocked ? "&Undock" : "&Dock";

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e) =>
            SceneForm.ViewEntityEditor.Checked = EditControlVisible;

        #endregion
    }
}
