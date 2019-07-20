namespace ToyGrafX
{
    using OpenTK;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            for (DisplayIndex displayIndex = 0; displayIndex <= DisplayIndex.Sixth; displayIndex++)
            {
                var d = DisplayDevice.GetDisplay(displayIndex);
                if (d != null)
                    Console.WriteLine($"{d.Width}x{d.Height}x{d.BitsPerPixel}bpp @{d.RefreshRate}Hz {displayIndex} display");
            }
            var controller = new GameWindowController(1024, 768, "Cleo");
            controller.GameWindow.Run(60); // target fps (optional)
        }
    }
}
