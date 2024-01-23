using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class CoolingSystem
{
    public DimensionsOfCoolingSystem? Dimensions { get; set; }
    public IEnumerable<string>? CorrectSockets { get; set; }
    public int Tdp { get; set; }
}
