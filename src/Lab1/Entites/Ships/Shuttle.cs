using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;
using FirstLevel = Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength.FirstLevel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Ships;

public class Shuttle : Ships
{
    public Shuttle(bool photonDeflector)
    {
        Weight = 50;
        Radiator = false;
        Engine = new List<EngineBase>() { new PulseMotorC() };
        Deflector = new None(photonDeflector);
        Shells = new List<ShellBase>() { new FirstLevel() };
    }
}
