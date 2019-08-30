namespace ToyGraf
{
    using System;
    using System.Windows.Forms;
    using ToyGraf.Controllers;

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
