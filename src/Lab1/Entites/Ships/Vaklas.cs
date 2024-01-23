using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;
using FirstLevel = Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors.FirstLevel;
using SecondLevel = Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength.SecondLevel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Ships;

public class Vaklas : Ships
{
    public Vaklas(bool photonDeflector)
    {
        Weight = 100;
        Radiator = false;
        Engine = new List<EngineBase>() { new PulseMotorE(), new Gamma() };
        Deflector = new FirstLevel(photonDeflector);
        Shells = new List<ShellBase>() { new SecondLevel() };
    }
}
