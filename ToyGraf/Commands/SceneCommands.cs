namespace ToyGraf.Commands
{
    public class SceneTitleCommand : ScenePropertyCommand<string>
    {
        public SceneTitleCommand(string value) : base("Script",
            value, s => s._Title, (s, v) => s._Title = v)
        { }
    }
}
