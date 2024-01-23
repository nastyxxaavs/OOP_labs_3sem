using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Invokers;

public class Invoker
{
    private ICommand _command;

    public Invoker(string? context, ICommand command)
    {
        _command = command;
        Context.State = context;
    }

    public void SetCommand(ICommand com)
    {
        _command = com;
    }

    public void Action(string request)
    {
        if (Context.State is not null)
        {
            _command.Execute();
        }
    }

    public void Stop()
    {
        if (Context.State is not null)
        {
            _command.Undo();
        }
    }
}
