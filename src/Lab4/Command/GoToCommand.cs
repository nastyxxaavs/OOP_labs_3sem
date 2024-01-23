using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class GoToCommand : ICommand
{
    private ILocalServices _receiver;
    private string _path;

    public GoToCommand(ILocalServices receiver, string path)
    {
        _receiver = receiver;
        _path = path;
    }

    public bool CorrectArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 0)
        {
            _path = arguments[0];
            return true;
        }

        return false;
    }

    public void Execute()
    {
        IList<string> arguments = new List<string>() { _path };
        if (CorrectArguments(arguments)) _receiver.GotoTisPath(_path);
    }

    public void Undo()
    {
    }
}
