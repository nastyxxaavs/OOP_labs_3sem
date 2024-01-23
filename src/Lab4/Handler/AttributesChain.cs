using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;

public class AttributesChain : HandlerBase
{
    public override void Handle(string? request, ModelOfCommand? modelOfCommand)
    {
        if (request is not null)
        {
            string[] args = request.Split();
            foreach (string arg in args)
            {
                if (arg.StartsWith("-", StringComparison.Ordinal)) break;
                modelOfCommand?.Attributes?.Add(arg);
                request = request?.Remove(0, arg.Length).Trim();
            }

            if (request is not null && request.StartsWith("-", StringComparison.Ordinal))
                Next?.Handle(request, modelOfCommand);
        }
    }
}
