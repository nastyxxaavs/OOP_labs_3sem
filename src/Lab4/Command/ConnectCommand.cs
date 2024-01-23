using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class ConnectCommand : ICommand
{
    private IConnectionServices _receiver;
    private string _path;
    private IDictionary<string, string> _flags;

    public ConnectCommand(IConnectionServices receiver, string path, IDictionary<string, string> flags)
    {
        _receiver = receiver;
        _path = path;
        _flags = flags;
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

    public bool CorrectFlags(IDictionary<string, string> flags)
    {
        if (flags is null) throw new ArgumentNullException(nameof(flags));
        if (flags.ContainsKey("-m") || flags.Count == 0)
        {
            _flags.Add("-m", "local");
            return true;
        }

        return false;
    }

    public void Execute()
    {
        IList<string> arguments = new List<string>() { _path };
        if (CorrectArguments(arguments) && CorrectFlags(_flags))
        {
                _receiver.Connect(_path, _flags);
        }
    }

    public void Undo()
    {
        _receiver.Disconnect();
    }
}
