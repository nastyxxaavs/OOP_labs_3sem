using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

public interface ILocalServices
{
    public void GotoTisPath(string path);
    public void TreeList(int maxDepth, string prefix, string path);
    public void Copy(string sourcePath, string destinationPath);

    public void MoveToAnotherCatalog(string sourcePath, string destinationPath);

    public void Rename(string path, string name);
    public void Remove(string path);

    public void Show(string path, IDictionary<string, string> flags);
}
