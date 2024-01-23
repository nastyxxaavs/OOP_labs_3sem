using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Enviroments;

public class Space : EnvironmentBase
{
    public Space()
    {
        Obstacles = new List<Obstacles.ObstacleBase>() { new None(), new Asteroids(), new Meteorites() };
    }
}
