using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class TreeListCommand : ICommand
{
    private ILocalServices _receiver;
    private string _path;
    private string _prefix;
    private int _maxDepth;
    private IDictionary<string, string> _flags;

    public TreeListCommand(ILocalServices receiver, string path, IDictionary<string, string> flags, string prefix, int maxDepth)
    {
        _receiver = receiver;
        _path = path;
        _prefix = prefix;
        _flags = flags;
        _maxDepth = maxDepth;
    }

    public bool CorrectFlags(IDictionary<string, string> flags, int depth)
    {
        if (flags is null) throw new ArgumentNullException(nameof(flags));
        if ((flags.ContainsKey("-d") && depth >= 1) || flags.Count == 0)
        {
            string d = depth + "0";
            _flags.Add("-d", d);
            return true;
        }

        return false;
    }

    public void Execute()
    {
        if (CorrectFlags(_flags, _maxDepth))
        {
            _receiver.TreeList(_maxDepth, _prefix, _path);
        }
    }

    public void Undo()
    {
    }
}
