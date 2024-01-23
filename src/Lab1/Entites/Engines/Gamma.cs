using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;

public class Gamma : JumpMotorBase
{
    public Gamma()
    {
        Speed = 180;
        DieselSpend = Math.Pow(9, 2);
        Length = 150;
    }

    public override EngineBase IsMotor()
    {
        EngineBase engine = new Gamma();
        return engine;
    }
}
