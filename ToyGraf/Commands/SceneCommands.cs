namespace ToyGraf.Commands
{
    internal class SceneFpsCommand : ScenePropertyCommand<double>
    {
        internal SceneFpsCommand(double value) : base("FPS",
            value, s => s._FPS, (s, v) => s._FPS = v)
        { }
    }

    internal class SceneTitleCommand : ScenePropertyCommand<string>
    {
        internal SceneTitleCommand(string value) : base("Script",
            value, s => s._Title, (s, v) => s._Title = v)
        { }
    }

    internal class TraceInsertCommand : TracesCommand
    {
        internal TraceInsertCommand(int index) : base(index, true) { }
    }

    internal class TraceDeleteCommand : TracesCommand
    {
        internal TraceDeleteCommand(int index) : base(index, false) { }
    }

}
