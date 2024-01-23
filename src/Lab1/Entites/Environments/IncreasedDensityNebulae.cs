using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Enviroments;

public class IncreasedDensityNebulae : EnvironmentBase
{
    public IncreasedDensityNebulae()
    {
        Obstacles = new List<Obstacles.ObstacleBase>() { new None(), new AntimatterFlares() };
    }
}
