using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;

public class Omega : JumpMotorBase
{
    public Omega()
    {
        Speed = 60;
        DieselSpend = 10 * Math.Log2(10);
        Length = 100;
    }

    public override EngineBase IsMotor()
    {
        EngineBase engine = new Omega();
        return engine;
    }
}
