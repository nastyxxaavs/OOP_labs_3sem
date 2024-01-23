using System;
using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;

public class CommandChain : HandlerBase
{
    private IList<string> _commands = new List<string>() { "connect", "disconnect", "tree goto", "tree list", "file show", "file rename", "file delete", "file copy", "file move" };

    public override void Handle(string? request, ModelOfCommand? modelOfCommand)
    {
        if (request is not null && modelOfCommand is not null)
        {
            foreach (string command in _commands)
            {
                if (request.StartsWith(command, StringComparison.Ordinal))
                {
                    CorrectState = true;
                    modelOfCommand.Name = command;
                    request = request.Remove(0, command.Length).Trim();
                    break;
                }
            }

            if (!CorrectState)
            {
                throw new ArgumentException("wrong command name");
            }
        }

        Next?.Handle(request, modelOfCommand);
    }
}
