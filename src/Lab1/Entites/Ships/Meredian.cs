using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;
using SecondLevel = Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength.SecondLevel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Ships;

public class Meredian : Ships
{
    public Meredian(bool photonDeflector)
    {
        Weight = 100;
        Radiator = true;
        Engine = new List<EngineBase>() { new PulseMotorE() };
        Deflector = new Deflectors.SecondLevel(photonDeflector);
        Shells = new List<ShellBase>() { new SecondLevel() };
    }
}
