using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class Cpu
{
    public string? NameOfCpu { get; set; }
    public int CountOfCore { get; set; }
    public double CoreFrequency { get; set; }
    public string? Socket { get; set; }
    public bool VideoCore { get; set; }
    public IEnumerable<int>? DataFrequency { get; set; }
    public int Tdp { get; set; }
    public double SpendedPower { get; set; }
}
