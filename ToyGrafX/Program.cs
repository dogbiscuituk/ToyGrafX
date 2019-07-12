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
            // This line creates a new instance, and wraps the instance in a using statement so it's
            // automatically disposed once we've exited the block.
            using (Space game = new Space(800, 600, Application.ProductName))
            {
                //Run takes a double, which is how many frames per second it should strive to reach.
                //You can leave that out and it'll just update as fast as the hardware will allow it.
                game.Run(60.0);
            }
        }
    }
}
