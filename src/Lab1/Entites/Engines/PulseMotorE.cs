using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;

public class PulseMotorE : PulseMotorBase
{
    public PulseMotorE()
    {
        Speed = Math.Exp(5);
        DieselSpend = 50;
        Length = 0;
    }

    public override EngineBase IsMotor()
    {
        EngineBase engine = new PulseMotorE();
        return engine;
    }
}
