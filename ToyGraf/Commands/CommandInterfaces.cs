namespace ToyGraf.Commands
{
    using ToyGraf.Models;

    public interface ICommand
    {
        int Index { get; }
        string PropertyName { get; }
        string RedoAction { get; }
        string UndoAction { get; }

        bool Do(Scene scene);
        void Invert();
        bool Run(Scene scene);
    }

    public interface IPropertyCommand : ICommand { }

    public interface IScenePropertyCommand : IPropertyCommand
    {
    }

    public interface ITracePropertyCommand : IPropertyCommand
    {
    }

    public interface ICollectionCommand : ICommand
    {
        bool Adding { get; set; }
    }

    public interface ITracesCommand : ICollectionCommand
    {
        Trace Value { get; set; }
    }

    public interface ICommandProcessor
    {
        void Run(ICommand command);
    }

    public interface ISceneController
    {
        ICommandProcessor CommandProcessor { get; }
    }
}
