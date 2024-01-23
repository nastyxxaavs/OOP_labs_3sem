using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;
using FirstLevel = Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength.FirstLevel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Ships;

public class Stella : Ships
{
    public Stella(bool photonDeflector)
    {
        Weight = 50;
        Radiator = false;
        Engine = new List<EngineBase>() { new PulseMotorC(), new Omega() };
        Deflector = new Deflectors.FirstLevel(photonDeflector);
        Shells = new List<ShellBase>() { new FirstLevel() };
    }
}
