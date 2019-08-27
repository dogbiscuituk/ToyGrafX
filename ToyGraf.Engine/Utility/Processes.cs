namespace ToyGraf.Engine.Utility
{
    public static class Processes
    {
        public static void Launch(this string url) => System.Diagnostics.Process.Start(url);
        public static void Spit(this string s) => System.Diagnostics.Debug.WriteLine(s);
    }
}
