namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;

public class Alpha : JumpMotorBase
{
    public Alpha()
    {
        Speed = 160;
        DieselSpend = 60;
        Length = 50;
    }

    public override EngineBase IsMotor()
    {
        EngineBase engine = new Alpha();
        return engine;
    }
}
