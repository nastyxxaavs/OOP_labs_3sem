using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Enviroments;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Obstacles;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entites;

public class Routes3
{
    private ICollection<Entites.Ships.Ships> successfulShips = new List<Ships.Ships>();
    public static ICollection<Condition> OvercomingObstacle(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance)
    {
        ICollection<Condition> condition = new List<Condition>();
        ICollection<Condition> result;
        if (environment is Space && obstacle is Asteroids)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.Destroyed);
        }

        if (environment is Space && obstacle is None)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.Destroyed);
        }

        if (environment is Space && obstacle is Meteorites)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.Destroyed);
        }

        if (environment is IncreasedDensityNebulae && obstacle is AntimatterFlares)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.CrewDead);
            condition.Add(Condition.Lost);
        }

        if (environment is IncreasedDensityNebulae && obstacle is None)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.CrewDead);
            condition.Add(Condition.Lost);
        }

        if (environment is NitrineParticleNebulae && obstacle is SpaceWhales)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.Destroyed);
        }

        if (environment is NitrineParticleNebulae && obstacle is None)
        {
            result = obstacle.OvercomingObstacle(ship, environment, obstacle, distance);
            if (result.Contains(Condition.Success)) condition.Add(Condition.Success);
            condition.Add(Condition.Destroyed);
        }

        return condition;
    }

    public ICollection<Condition> Move(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance)
    {
        var result = new List<Condition>();
        if (ship is not null && environment is not null && obstacle is not null)
        {
            ICollection<Condition>
                condition = OvercomingObstacle(ship, environment, obstacle, distance);
            if (condition.Contains(Condition.Success))
            {
                successfulShips.Add(ship);
                result.Add(Condition.Success);
                return result;
            }

            if (condition.Contains(Condition.Destroyed))
            {
                result.Add(Condition.Destroyed);
            }

            if (condition.Contains(Condition.Lost) || condition.Contains(Condition.CrewDead))
            {
                result.Add(Condition.CrewDead);
                result.Add(Condition.Lost);
            }
        }

        return result;
    }

    public ICollection<Condition> GenerateRouteToMove(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment, ICollection<Obstacles.ObstacleBase> obstacle, double distance)
    {
        var result = new List<Condition>();
        if (ship is not null && environment is not null && obstacle is not null)
        {
            foreach (Obstacles.ObstacleBase obs in obstacle)
            {
                ICollection<Condition> condition = OvercomingObstacle(ship, environment, obs, distance);
                while (!(result.Contains(Condition.Destroyed) || result.Contains(Condition.Lost) ||
                         result.Contains(Condition.CrewDead)))
                {
                    if (condition.Contains(Condition.Success))
                    {
                        successfulShips.Add(ship);
                        result.Add(Condition.Success);
                        return result;
                    }

                    if (condition.Contains(Condition.Destroyed))
                    {
                        result.Add(Condition.Destroyed);
                    }

                    if (condition.Contains(Condition.Lost) || condition.Contains(Condition.CrewDead))
                    {
                        result.Add(Condition.CrewDead);
                        result.Add(Condition.Lost);
                    }
                }
            }
        }

        return result;
    }

    public ICollection<Ships.Ships> TheBestShip(ICollection<Ships.Ships> ships, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance, double spendedfuel)
    {
        var result = new List<Ships.Ships>();
        if (obstacle is not null && ships is not null && environment is not null)
        {
                foreach (Ships.Ships ship in obstacle.TheBestShip(ships, environment, obstacle, distance, spendedfuel))
                {
                    result.Add(ship);
                    successfulShips.Add(ship);
                }
        }

        return result;
    }
}
