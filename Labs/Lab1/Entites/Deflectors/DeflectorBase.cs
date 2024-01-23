namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors;

public abstract class DeflectorBase
{
     public bool PhotonicDeflector { get; init; }
     public int Health { get; set; }
     public bool IsOn { get; set; }
     public abstract DeflectorBase WhatIsDeflector();
     public abstract double WhatIsDamage(Obstacles.ObstacleBase obstacleOne);
}
