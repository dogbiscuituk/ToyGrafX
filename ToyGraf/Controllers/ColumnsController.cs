namespace ToyGraf.Controllers
{
    using System.Windows.Forms;

    internal class ColumnsController : ShadersControllerBase
    {
        #region Constructor

        internal ColumnsController(TraceTableController traceTableController)
            : base()
        {
            TraceTableController = traceTableController;
        }

        #endregion

        #region Protected Override Methods

        protected override void LoadItems()
        {
            for (var index = 0; index < Columns.Count; index++)
            {
                var column = Columns[index];
                Items.Add(column.HeaderText, column.Visible);
            }
        }

        protected override void SaveItems()
        {
            for (var index = 0; index < Items.Count; index++)
                Columns[index].Visible = ColumnsListBox.GetItemChecked(index);
        }

        #endregion

        #region Private Properties

        private DataGridViewColumnCollection Columns => TraceTableController.TraceTable.Columns;
        private readonly TraceTableController TraceTableController;

        #endregion
    }
}
