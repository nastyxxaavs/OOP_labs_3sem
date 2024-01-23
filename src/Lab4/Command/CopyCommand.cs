using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class CopyCommand : ICommand
{
    private string _destinationPath;
    private ILocalServices _receiver;
    private string _path;

    public CopyCommand(ILocalServices receiver, string path, string destinationPath)
    {
        _receiver = receiver;
        _path = path;
        _destinationPath = destinationPath;
    }

    public bool CorrectArguments(IList<string> arguments)
    {
        if (arguments is null) throw new ArgumentNullException(nameof(arguments));
        if (arguments.Count != 0)
        {
            _path = arguments[0];
            _destinationPath = arguments[1];
            return true;
        }

        return false;
    }

    public void Execute()
    {
        IList<string> arguments = new List<string>() { _path, _destinationPath };
        if (CorrectArguments(arguments)) _receiver.Copy(_path, _destinationPath);
    }

    public void Undo()
    {
    }
}
