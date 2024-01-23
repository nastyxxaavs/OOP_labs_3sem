namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;

public class PulseMotorC : PulseMotorBase
{
    public PulseMotorC()
    {
        Speed = 50;
        DieselSpend = 20;
        Length = 0;
    }

    public override EngineBase IsMotor()
    {
        EngineBase engine = new PulseMotorC();
        return engine;
    }
}
