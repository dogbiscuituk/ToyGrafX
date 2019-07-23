namespace ToyGrafX
{
    using ToyGrafX.Engine;

    class Program
    {
        static void Main() => new GameWindowRenderer(1024, 768, "Cleo").GameWindow.Run(60);
    }
}
