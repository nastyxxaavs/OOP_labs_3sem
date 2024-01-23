using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Enviroments;
public abstract class EnvironmentBase
{
    public IEnumerable<Obstacles.ObstacleBase>? Obstacles { get; set; }
}
