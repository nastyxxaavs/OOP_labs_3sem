using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

public class ConnectService : IConnectionServices
{
    private IDictionary<string, string> _flags = new Dictionary<string, string>();

    public void Connect(string path, IDictionary<string, string> flags)
    {
        Context.State = path;
        _flags = flags;
    }

    public void Disconnect()
    {
        Context.State = null;
    }
}
