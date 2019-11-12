namespace ToyGraf.Controllers
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using ToyGraf.Controls;

    internal class ShadersController : ShadersControllerBase
    {
        #region Constructor

        internal ShadersController(EntityEditController entityEditController)
            : base() => EntityEditController = entityEditController;

        #endregion

        protected override void LoadItems()
        {
            foreach (var tabPage in AllTabPages)
                Items.Add(tabPage.Text, VisibleTabPages.Contains(tabPage));
        }

        protected override void SaveItems()
        {
            VisibleTabPages.Clear();
            for (var index = 0; index < Items.Count; index++)
                if (ColumnsListBox.GetItemChecked(index))
                    VisibleTabPages.Add(AllTabPages[index]);
        }

        #region Private Fields

        private readonly EntityEditController EntityEditController;

        #endregion

        #region Private Properties

        private List<TabPage> AllTabPages => EntityEditController.AllTabPages;
        private TgEntityEdit EntityEdit => EntityEditController.EntityEdit;
        private TabControl TabControl => EntityEdit.ShadersTabControl;
        private TabControl.TabPageCollection VisibleTabPages => TabControl.TabPages;

        #endregion
    }
}
