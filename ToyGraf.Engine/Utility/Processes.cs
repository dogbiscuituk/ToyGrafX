namespace ToyGraf.Engine.Utility
{
    using System.Diagnostics;

    public static class Processes
    {
        public static void Launch(this string url) => Process.Start(url);
    }
}
