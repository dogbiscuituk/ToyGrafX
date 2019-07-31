namespace ToyGraf.Commands
{
    public class SceneFramesPerSecondCommand : ScenePropertyCommand<double>
    {
        public SceneFramesPerSecondCommand(double value) : base("FramesPerSecond",
            value, s => s._FramesPerSecond, (s, v) => s._FramesPerSecond = v)
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
