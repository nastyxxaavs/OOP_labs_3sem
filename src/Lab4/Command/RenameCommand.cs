using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class RenameCommand : ICommand
{
    private string _name;
    private ILocalServices _receiver;
    private string _path;

    public RenameCommand(ILocalServices receiver, string path, string name)
    {
        _receiver = receiver;
        _path = path;
        _name = name;
    }

    public bool CorrectArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 0)
        {
            _path = arguments[0];
            _name = arguments[1];
            return true;
        }

        return false;
    }

    public void Execute()
    {
        IList<string> arguments = new List<string>() { _path, _name };
        if (CorrectArguments(arguments)) _receiver.Rename(_path, _name);
    }

    public void Undo()
    {
    }
}
