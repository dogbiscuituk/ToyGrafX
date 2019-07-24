namespace ToyGraf.Commands
{
    using System.Collections.Generic;
    using ToyGraf.Controllers;
    using ToyGraf.Models;
    using ToyGraf.Views;

    public class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor(SceneController sceneController)
        {
            SceneController = sceneController;
            // Edit
            SceneForm.EditUndo.Click += EditUndo_Click;
            SceneForm.EditRedo.Click += EditRedo_Click;
        }

        public void Run(ICommand command)
        {
            Redo(command);
            RedoStack.Clear();
            UpdateUI();
        }

        #region Private Properties

        private SceneController SceneController;
        private Scene Scene => SceneController.Scene;
        private SceneForm SceneForm => SceneController.SceneForm;

        private readonly Stack<ICommand> UndoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> RedoStack = new Stack<ICommand>();

        private bool CanUndo { get => UndoStack.Count > 0; }
        private bool CanRedo { get => RedoStack.Count > 0; }

        private string UndoAction => UndoStack.Peek().UndoAction;
        private string RedoAction => RedoStack.Peek().RedoAction;

        #endregion

        #region Private Event Handlers

        private void EditUndo_Click(object sender, System.EventArgs e) => Undo();
        private void EditRedo_Click(object sender, System.EventArgs e) => Redo();

        #endregion

        #region Private Methods

        private void Redo() { if (CanRedo) Redo(RedoStack.Pop()); }

        private void Redo(ICommand command)
        {
            if (!command.Do(Scene))
                return;
            //if (!(GroupUndo && CanUndo && CanGroup(UndoStack.Peek(), command)))
                UndoStack.Push(command);
            UpdateUI();
        }

        private void Undo() { if (CanUndo) Undo(UndoStack.Pop()); }

        private void Undo(ICommand command)
        {
            command.Do(Scene);
            RedoStack.Push(command);
            UpdateUI();
        }

        private void UpdateUI()
        {
            string
                undo = CanUndo ? $"Undo {UndoAction}" : "Undo",
                redo = CanRedo ? $"Redo {RedoAction}" : "Redo";
            SceneForm.EditUndo.Enabled = SceneForm.tbUndo.Enabled = CanUndo;
            SceneForm.EditRedo.Enabled = SceneForm.tbRedo.Enabled = CanRedo;
            SceneForm.EditUndo.Text = $"&{undo}";
            SceneForm.EditRedo.Text = $"&{redo}";
            //SceneForm.tbUndo.ToolTipText = $"{undo} (^Z)";
            //SceneForm.tbRedo.ToolTipText = $"{redo} (^Y)";
            //SceneForm.EditCut.Enabled = SceneForm.tbCut.Enabled = false;
            //SceneForm.EditCopy.Enabled = SceneForm.tbCopy.Enabled = false;
            //SceneForm.EditPaste.Enabled = SceneForm.tbPaste.Enabled = false;
            //SceneForm.EditDelete.Enabled = SceneForm.tbDelete.Enabled = false;
        }

        #endregion
    }
}
