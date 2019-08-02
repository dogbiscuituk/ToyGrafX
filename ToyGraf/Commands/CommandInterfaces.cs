namespace ToyGraf.Commands
{
    using ToyGraf.Models;

    internal interface ICommand
    {
        int Index { get; }
        string PropertyName { get; }
        string RedoAction { get; }
        string UndoAction { get; }

        bool Do(Scene scene);
        void Invert();
        bool Run(Scene scene);
    }

    internal interface IPropertyCommand : ICommand { }

    internal interface IScenePropertyCommand : IPropertyCommand
    {
        void RunOn(Scene scene);
    }

    internal interface ITracePropertyCommand : IPropertyCommand
    {
        void RunOn(Trace trace);
    }

    internal interface ICollectionCommand : ICommand
    {
        bool Adding { get; set; }
    }

    internal interface ITracesCommand : ICollectionCommand
    {
        Trace Value { get; set; }
    }

    internal interface ICommandProcessor
    {
        void Run(ICommand command);
    }

    internal interface ISceneController
    {
        ICommandProcessor CommandProcessor { get; }
    }
}
