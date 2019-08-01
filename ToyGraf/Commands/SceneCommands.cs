namespace ToyGraf.Commands
{
    public class SceneFpsCommand : ScenePropertyCommand<double>
    {
        public SceneFpsCommand(double value) : base("FPS",
            value, s => s._FPS, (s, v) => s._FPS = v)
        { }
    }

    public class SceneTitleCommand : ScenePropertyCommand<string>
    {
        public SceneTitleCommand(string value) : base("Script",
            value, s => s._Title, (s, v) => s._Title = v)
        { }
    }

    public class TraceInsertCommand : TracesCommand
    {
        public TraceInsertCommand(int index) : base(index, true) { }
    }

    public class TraceDeleteCommand : TracesCommand
    {
        public TraceDeleteCommand(int index) : base(index, false) { }
    }

}
