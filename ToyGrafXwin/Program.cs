namespace ToyGrafXwin
{
    using System;
    using System.Windows.Forms;
    using ToyGrafXwin.Controllers;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(AppController.AboutDialog);
        }
    }
}
