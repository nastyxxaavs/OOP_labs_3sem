using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Ships;

public abstract class Ships
{
    public double Weight { get; set; }
    public bool Radiator { get; set; }
    public Deflectors.DeflectorBase? Deflector { get; protected init; }
    public IEnumerable<EngineBase>? Engine { get; protected init; }
    public IEnumerable<ShellBase>? Shells { get; protected init; }
}
