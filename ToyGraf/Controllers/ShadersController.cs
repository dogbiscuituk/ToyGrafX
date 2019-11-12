namespace ToyGraf.Controllers
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ToyGraf.Controls;

    internal class ShadersController : ShadersControllerBase
    {
        #region Constructor

        internal ShadersController(EntityEditController entityEditController)
            : base("Visible Tabs") => EntityEditController = entityEditController;

        #endregion

        protected override void LoadItems()
        {
            foreach (var tabPage in AllTabs)
                Items.Add(tabPage.Text, VisibleTabs.Contains(tabPage));
        }

        protected override void SaveItems()
        {
            VisibleTabs.Clear();
            for (var index = 0; index < Items.Count; index++)
                if (ColumnsListBox.GetItemChecked(index))
                    VisibleTabs.Add(AllTabs[index]);
        }

        #region Private Fields

        private readonly EntityEditController EntityEditController;

        #endregion

        #region Private Properties

        private List<TabPage> AllTabs => EntityEditController.AllTabs;
        private TgEntityEdit Editor => EntityEditController.EntityEdit;
        private TabControl TabControl => Editor.ShadersTabControl;
        private TabControl.TabPageCollection VisibleTabs => TabControl.TabPages;

        #endregion
    }
}
