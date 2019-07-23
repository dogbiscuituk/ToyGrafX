namespace ToyGraf
{
    using ToyGraf.Engine;

    class Program
    {
        static void Main() =>
            new GameWindowRenderer(1024, 768, "ToyGraf Console").
            GameWindow.Run(60);
    }
}
