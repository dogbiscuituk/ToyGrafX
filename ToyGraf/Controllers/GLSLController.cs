namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal class GLSLController
    {
        internal GLSLController()
        {
            Editor = new GLSLEditor();
            //new GLSLSnippetController(this, Editor.f)
        }

        internal bool Execute() => Editor.ShowDialog() == DialogResult.OK;

        private GLSLEditor Editor;
    }
}
