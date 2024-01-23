using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Enviroments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Obstacles;

public class None : ObstacleBase
{
    public None()
    {
        Damage = 0;
    }

    public override int Count()
    {
        return 0;
    }

    public override int DamageCost()
    {
        ObstacleBase obstacle = new None();
        return obstacle.Damage;
    }

    public override ICollection<double> DamageDistribution(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment)
    {
        ICollection<double> spentDamage = new List<double>();
        return spentDamage;
    }

    public override ICollection<double> LengthOpportunity(Ships.Ships ship)
    {
        ICollection<double> spentLength = new List<double>();
        if (ship is not null && ship.Engine is not null)
        {
            foreach (Engines.EngineBase engine in ship.Engine)
            {
                if (engine is JumpMotorBase)
                {
                        spentLength.Add(engine.Length);
                }
            }
        }

        return spentLength;
    }

    public override bool CanFlyThisDistance(Ships.Ships ship, double distance)
    {
        IEnumerable<double> spentLength = LengthOpportunity(ship);
        foreach (double length in spentLength)
        {
            if (length >= distance)
            {
                return true;
            }
        }

        return false;
    }

    public override ICollection<Condition> OvercomingObstacle(Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (ship is not null && ship.Engine is not null)
        {
            bool engine = IsCorrectTypeOfEngine(ship, environment);
            if (engine || CanFlyThisDistance(ship, distance))
            {
                condition.Add(Condition.Success);
            }
            else
            {
                condition.Add(Condition.Destroyed);
            }
        }

        return condition;
    }

    public override bool IsCorrectTypeOfEngine(Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment)
    {
        if (ship is not null && ship.Engine is not null && environment is not null)
        {
            foreach (Engines.EngineBase engine in ship.Engine)
            {
                if (environment is Space)
                {
                    if (engine is PulseMotorBase) return true;
                    return false;
                }

                if (environment is NitrineParticleNebulae)
                {
                    if (engine is PulseMotorE) return true;
                    return false;
                }

                if (environment is IncreasedDensityNebulae)
                {
                    if (engine is JumpMotorBase) return true;
                    return false;
                }
            }
        }

        return false;
    }

    public override bool CorrectDeflectorAndShell(Ships.Ships? ship, EnvironmentBase? environment)
    {
        return true;
    }

    public override bool IsCorrectDamage(Ships.Ships? ship, Enviroments.EnvironmentBase? environment)
    {
        return true;
    }

    public override bool IsCorrectTypeOfDeflector(Ships.Ships? ship, Entites.Enviroments.EnvironmentBase? environment)
    {
        return true;
    }

    public override bool IsCorrectTypeOfShell(Ships.Ships? ship, Entites.Enviroments.EnvironmentBase? environment)
    {
        return true;
    }

    public override ICollection<double> TimeOfFlight(double distance, Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment)
    {
        ICollection<double> spentTime = new List<double>();
        if (ship is not null && environment is not null && ship.Engine is not null)
        {
            foreach (Engines.EngineBase engine in ship.Engine)
            {
                if (engine is PulseMotorBase)
                {
                    spentTime.Add(distance / engine.Speed);
                }

                if (engine is JumpMotorBase)
                {
                    if (CanFlyThisDistance(ship, distance))
                    {
                        spentTime.Add(distance / engine.Speed);
                    }
                }
            }
        }

        return spentTime;
    }

    public override ICollection<double> SpendedFuel(Entites.Ships.Ships ship, double spendedfuel)
    {
        ICollection<double> spentFuel = new List<double>();
        if (ship is not null && ship.Engine is not null)
        {
            foreach (Entites.Engines.EngineBase engine in ship.Engine)
            {
                spentFuel.Add(engine.DieselSpend + spendedfuel);
            }
        }

        return spentFuel;
    }

    public override ICollection<double> SpendedMoney(Entites.Ships.Ships ship, double spendedfuel)
    {
        ICollection<double> spentFuel = SpendedFuel(ship, spendedfuel);
        ICollection<double> spentMoney = new List<double>();
        if (ship is not null && ship.Engine is not null)
        {
            foreach (Entites.Engines.EngineBase engine in ship.Engine)
            {
                foreach (double fuel in spentFuel)
                {
                    double money = fuel * 100;
                    spentMoney.Add(money);
                }
            }
        }

        return spentMoney;
    }

    public override ICollection<Ships.Ships> TheBestShip(ICollection<Ships.Ships> ships, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance, double spendedfuel)
    {
        ICollection<Ships.Ships> result = new List<Ships.Ships>();
        if (ships is not null)
        {
            foreach (Ships.Ships shipp in ships)
            {
                    if (OvercomingObstacle(shipp, environment, obstacle, distance).Contains(Condition.Success))
                    {
                        IEnumerable<double> money = SpendedMoney(shipp, spendedfuel);
                        foreach (double cash in SpendedMoney(shipp, spendedfuel))
                        {
                            double cost = SpendedMoney(shipp, spendedfuel).Min();
                            if (cash < cost)
                            {
                                result.Add(shipp);
                            }
                        }
                    }

                    foreach (double theMoney in SpendedMoney(shipp, spendedfuel))
                    {
                        double cost = SpendedMoney(shipp, spendedfuel).Min();
                        if (theMoney < cost)
                        {
                            result.Add(shipp);
                        }
                    }
            }
        }

        return result;
    }
}
