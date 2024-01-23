using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

public interface IConnectionServices
{
    public void Connect(string path, IDictionary<string, string> flags);
    public void Disconnect();
}
