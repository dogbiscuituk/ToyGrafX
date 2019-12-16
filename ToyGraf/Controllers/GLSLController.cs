namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Controls;
    using ToyGraf.Views;

    internal class GLSLController
    {
        internal GLSLController()
        {
            Editor = new GLSLEditor();
            new GLSLShaderController(Editor.glslShaderEditor1);
            new GLSLShaderController(Editor.glslShaderEditor2);
            new GLSLShaderController(Editor.glslShaderEditor3);
            new GLSLShaderController(Editor.glslShaderEditor4);
            new GLSLShaderController(Editor.glslShaderEditor5);
            new GLSLShaderController(Editor.glslShaderEditor6);
        }

        internal bool Execute() => Editor.ShowDialog() == DialogResult.OK;

        private GLSLEditor Editor;
    }
}
