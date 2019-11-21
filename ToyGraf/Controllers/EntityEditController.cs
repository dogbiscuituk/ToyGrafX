namespace ToyGraf.Controllers
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ToyGraf.Controls;
    using ToyGraf.Views;

    // https://github.com/PavelTorgashov/FastColoredTextBox/blob/master/Tester/PowerfulSample.cs

    internal class EntityEditController : HostController
    {
        #region Constructor

        internal EntityEditController(SceneController sceneController)
            : base(sceneController, "Entity Editor") => Init();

        #endregion

        #region Internal Fields

        internal List<TabPage> AllTabs;

        #endregion

        #region Internal Properties

        internal TgEntityEdit EntityEdit => SceneForm.EntityEdit;

        #endregion

        #region Protected Internal Methods

        protected internal override void Refresh()
        {
        }

        #endregion

        #region Internal Methods

        internal void Redraw()
        {
            FctbVertex.Invalidate();
            FctbTessellationControl.Invalidate();
            FctbTessellationEvaluation.Invalidate();
            FctbGeometry.Invalidate();
            FctbFragment.Invalidate();
            FctbCompute.Invalidate();
        }

        #endregion

        #region Protected Properties

        protected override Control Editor => EntityEdit;
        protected override Control EditorParent => SceneForm.SplitContainer3.Panel1;

        #endregion

        #region Protected Methods

        protected override void Collapse(bool collapse) => SceneForm.SplitContainer3.Panel1Collapsed = collapse;

        #endregion

        #region Private Fields

        private FastColoredTextBox FctbVertex => EntityEdit.fctbVertex;
        private FastColoredTextBox FctbTessellationControl => EntityEdit.fctbTessellationControl;
        private FastColoredTextBox FctbTessellationEvaluation => EntityEdit.fctbTessellationEvaluation;
        private FastColoredTextBox FctbGeometry => EntityEdit.fctbGeometry;
        private FastColoredTextBox FctbFragment => EntityEdit.fctbFragment;
        private FastColoredTextBox FctbCompute => EntityEdit.fctbCompute;

        #endregion

        #region Private Event Handlers

        private void PopupEntityEditShaders_Click(object sender, EventArgs e) =>
            new ShadersController(this).ShowDialog(Editor);

        private void PopupEntityEditMenu_Opening(object sender, CancelEventArgs e) =>
            SceneForm.PopupEntityEditFloat.Text = EditorDocked ? "&Undock" : "&Dock";

        private void ViewMenu_DropDownOpening(object sender, EventArgs e) =>
            SceneForm.ViewEntityEditor.Checked = EditorVisible;

        #endregion

        #region Private Methods

        private void Init()
        {
            InitSceneForm();
            InitTabPages();
            InitFctbControllers();
        }

        private void InitFctbControllers()
        {
            new TextStyleController(FctbVertex);
            new TextStyleController(FctbTessellationControl);
            new TextStyleController(FctbTessellationEvaluation);
            new TextStyleController(FctbGeometry);
            new TextStyleController(FctbFragment);
            new TextStyleController(FctbCompute);
        }

        private void InitSceneForm()
        {
            SceneForm.PopupEntityEditFloat.Click += PopupEditorFloat_Click;
            SceneForm.PopupEntityEditHide.Click += PopupEditorHide_Click;
            SceneForm.PopupEntityEditMenu.Opening += PopupEntityEditMenu_Opening;
            SceneForm.PopupEntityEditVisibleTabs.Click += PopupEntityEditShaders_Click;
            SceneForm.ViewEntityEditor.Click += ToggleEditor;
            SceneForm.ViewMenu.DropDownOpening += ViewMenu_DropDownOpening;
        }

        private void InitTabPages()
        {
            AllTabs = new List<TabPage>();
            AllTabs.AddRange(EntityEdit.ShadersTabControl.TabPages.OfType<TabPage>());
        }

        #endregion
    }
}
