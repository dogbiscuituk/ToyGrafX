namespace ToyGrafX
{
    using ToyGrafX.Engine;

    class Program
    {
        static void Main() =>
            new GameWindowRenderer(1024, 768, "ToyGrafX Console").
            GameWindow.Run(60);
    }
}
