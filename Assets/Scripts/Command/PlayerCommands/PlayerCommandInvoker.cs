using System.Collections.Generic;

public class PlayerCommandInvoker
{
    private Stack<ICommand> _commandQueue = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandQueue.Push(command);
    }
    public void UndoCommand()
    {
        if (_commandQueue.Count > 0)
        {
            ICommand lastCommand = _commandQueue.Pop();
            lastCommand.Undo();
        }
    }
}