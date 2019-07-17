namespace ToyGrafX
{
    using OpenTK;
    using System;
    using System.Windows.Forms;

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

            foreach (var p in Grid.GetTriangleStripIndices(4, 4))
                Console.Write($"{p}, ");
            Console.WriteLine();

            using (Space game = new Space(100, 100, Application.ProductName))
            {
                game.Run(60.0); // target fps (optional)
            }
        }
    }
}
