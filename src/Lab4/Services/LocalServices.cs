using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

public class LocalServices : ILocalServices
{
    public void GotoTisPath(string path)
    {
        Context.State = path;
    }

    public void TreeList(int maxDepth, string prefix, string path)
    {
        prefix = " ";
        int depth = 1;
        if (depth >= maxDepth)
        {
            return;
        }

        var di = new DirectoryInfo(path);
        var fsItems = di.GetFileSystemInfos()
            .Where(f => !f.Name.StartsWith(".", StringComparison.Ordinal))
            .OrderBy(f => f.Name)
            .ToList();

        foreach (FileSystemInfo fsItem in fsItems.Take(fsItems.Count - 1))
        {
            Console.Write(prefix + "├── ");
            Console.Write(fsItem);
            Console.WriteLine();
            TreeList(depth + 1, prefix + "│   ", fsItem.FullName);
        }

        FileSystemInfo? lastFsItem = fsItems.LastOrDefault();
        if (lastFsItem != null)
        {
            Console.Write(prefix + "└── ");
            Console.Write(lastFsItem);
            Console.WriteLine();
            TreeList(depth + 1, prefix + "    ", lastFsItem.FullName);
        }

        ListState.State = true;
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        string[] sourceList = Directory.GetFiles(sourcePath);

        if (sourcePath is not null)
        {
            foreach (string f in sourceList)
            {
                string fName = f.Substring(sourcePath.Length + 1);
                try
                {
                    File.Copy(Path.Combine(sourcePath, fName), Path.Combine(destinationPath, fName), true);
                }
                catch (IOException copyError)
                {
                    Console.WriteLine(copyError.Message);
                }
            }
        }
    }

    public void MoveToAnotherCatalog(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            using (FileStream fs = File.Create(sourcePath))
            {
            }
        }

        if (File.Exists(destinationPath)) File.Delete(destinationPath);
        File.Move(sourcePath, destinationPath);
        if (File.Exists(sourcePath))
        {
            MoveState.State = false;
        }
        else
        {
            MoveState.State = true;
        }
    }

    public void Rename(string path, string name)
    {
        if (!File.Exists(path))
        {
            using (FileStream fs = File.Create(path))
            {
            }
        }

        if (File.Exists(name)) File.Delete(name);
        File.Move(path, name);
        File.Delete(path);
    }

    public void Remove(string path)
    {
        File.Delete(path);
    }

    public void Show(string path, IDictionary<string, string> flags)
    {
        string[] readText = File.ReadAllLines(path);
        foreach (string s in readText)
        {
            Console.WriteLine(s);
        }

        ShowState.State = true;
    }
}
