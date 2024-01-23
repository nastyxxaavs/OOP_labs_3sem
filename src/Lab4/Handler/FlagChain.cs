using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;

public class FlagChain : HandlerBase
{
    public override void Handle(string? request, ModelOfCommand? modelOfCommand)
    {
        if (request is not null)
        {
            string[] args = request.Split();
            for (int i = 0; i < args.Length; i += 2)
            {
                if (args[i].StartsWith("-", StringComparison.Ordinal))
                {
                    modelOfCommand?.Flags?.Add(args[i], args[i + 1]);
                }
                else
                {
                    i--;
                }

                request = request?.Remove(0, args[i].Length).Trim();
            }
        }
    }
}
