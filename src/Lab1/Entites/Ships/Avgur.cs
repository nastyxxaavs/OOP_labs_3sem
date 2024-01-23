using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Ships;

public class Avgur : Ships
{
    public Avgur(bool photonDeflector)
    {
        Weight = 200;
        Radiator = false;
        Engine = new List<EngineBase>() { new PulseMotorE(), new Alpha() };
        Deflector = new Deflectors.ThirdLevel(photonDeflector);
        Shells = new List<ShellBase>() { new HullStrength.ThirdLevel() };
    }
}
