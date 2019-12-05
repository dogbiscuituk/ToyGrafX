namespace ToyGraf.Controllers
{
    using Properties;
    using System.Windows.Forms;
    using ToyGraf.Views;

    internal static class HotkeysController
    {
        internal static void Show(IWin32Window owner)
        {
            if (Form.Visible)
                Form.BringToFront();
            else
                Form.Show(owner);
        }

        private static HotkeysForm _Form;
        private static HotkeysForm Form
        {
            get
            {
                if (_Form == null)
                {
                    _Form = new HotkeysForm();
                    Form.WebBrowser.DocumentText = Resources.Hotkeys;
                    Form.FormClosing += Form_FormClosing;
                }
                return _Form;
            }
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Form.Hide();
                e.Cancel = true;
            }
        }
    }
}
