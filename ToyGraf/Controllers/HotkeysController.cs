namespace ToyGraf.Controllers
{
    using Properties;
    using ToyGraf.Views;

    internal class HotkeysController
    {
        internal HotkeysController()
        {
            Form = new HotkeysForm();
            Form.WebBrowser.DocumentText = Resources.Hotkeys;
        }

        internal void Show() => Form.Show();

        private readonly HotkeysForm Form;
    }
}
