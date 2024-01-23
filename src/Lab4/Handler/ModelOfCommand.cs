using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;

public class ModelOfCommand
{
    public string? Name { get; set; }
    public IList<string>? Attributes { get; init; } = new List<string>();
    public IDictionary<string, string>? Flags { get; init; } = new Dictionary<string, string>();
}
