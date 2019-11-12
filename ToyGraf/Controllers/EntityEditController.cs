namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Controls;
    using ToyGraf.Views;

    internal class EntityEditController : HostController
    {
        #region Constructor

        internal EntityEditController(SceneController sceneController)
            : base(sceneController, "Entity Editor")
        {
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
            SceneForm.ViewEntityEditor.Click += ToggleEditor;
            SceneForm.PopupEntityEditMenu.Opening += PopupEntityEditMenu_Opening;
            SceneForm.PopupEntityEditFloat.Click += PopupEditorFloat_Click;
            SceneForm.PopupEntityEditHide.Click += PopupEditorHide_Click;
        }

        #endregion

        #region Protected Properties

        protected override Control Editor => EntityEdit;
        protected override Control EditorParent => SceneForm.SplitContainer3.Panel1;

        #endregion

        #region Protected Methods

        protected override void Collapse(bool collapse) => SceneForm.SplitContainer3.Panel1Collapsed = collapse;

        protected internal override void Refresh()
        {
        }

        #endregion

        #region Private Properties

        private TgEntityEdit EntityEdit => SceneForm.EntityEdit;

        #endregion

        #region Private Event Handlers

        private void PopupEntityEditMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) =>
            SceneForm.PopupEntityEditFloat.Text = EditorDocked ? "&Undock" : "&Dock";

        private void ViewMenu_DropDownOpening(object sender, System.EventArgs e) =>
            SceneForm.ViewEntityEditor.Checked = EditorVisible;

        #endregion
    }
}
