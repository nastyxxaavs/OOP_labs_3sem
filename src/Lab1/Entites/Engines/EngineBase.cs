namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;

public abstract class EngineBase
{
    public double Speed { get; set; }
    public double DieselSpend { get; set; }
    public double Length { get; set; }
    public abstract EngineBase IsMotor();
}
