namespace ToyGraf.Controllers
{
    using System.Windows.Forms;
    using ToyGraf.Controls;
    using ToyGraf.Views;

    internal class GLProgramController
    {
        internal GLProgramController()
        {
            Editor = new GLProgramEditor();
            new GLShaderController(Editor.glslShaderEditor1);
            new GLShaderController(Editor.glslShaderEditor2);
            new GLShaderController(Editor.glslShaderEditor3);
            new GLShaderController(Editor.glslShaderEditor4);
            new GLShaderController(Editor.glslShaderEditor5);
            new GLShaderController(Editor.glslShaderEditor6);
        }

        internal bool Execute() => Editor.ShowDialog() == DialogResult.OK;

        private GLProgramEditor Editor;
    }
}
