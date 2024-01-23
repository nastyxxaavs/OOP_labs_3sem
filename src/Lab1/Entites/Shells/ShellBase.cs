namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;

public abstract class ShellBase
{
    public int Health { get; set; }
    public bool IsOn { get; set; }
    public abstract ShellBase WhatIsShell();
    public abstract double WhatIsDamage(Obstacles.ObstacleBase obstacle);
}
