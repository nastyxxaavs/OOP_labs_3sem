using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class Bios
{
    public string? Type { get; set; }
    public string? Version { get; set; }
    public IEnumerable<string>? CorrectCpu { get; set; }
}
