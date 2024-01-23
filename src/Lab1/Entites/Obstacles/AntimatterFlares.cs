using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entites.Engines;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Obstacles;

public class AntimatterFlares : ObstacleBase
{
    public AntimatterFlares()
    {
        Damage = 60;
    }

    public override int Count()
    {
        if (Damage == 60)
        {
            return 1;
        }
        else if (Damage < 60)
        {
            return 0;
        }

        int result = 0;
        if (Damage % 60 == 0)
        {
            result++;
            Damage = Damage / 60;
        }

        return result;
    }

    public override int DamageCost()
    {
        var obstacle = new AntimatterFlares();
        return obstacle.Damage;
    }

    public override ICollection<double> DamageDistribution(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment)
    {
        ICollection<double> spentDamage = new List<double>();
        if (ship is not null && environment is not null && ship.Deflector is not null &&
            environment.Obstacles is not null && ship.Shells is not null)
        {
            if (ship.Deflector.IsOn)
            {
                foreach (ObstacleBase obs in environment.Obstacles)
                {
                    spentDamage.Add(ship.Deflector.WhatIsDamage(obs));
                }
            }

            foreach (Entites.HullStrength.ShellBase theShell in ship.Shells)
            {
                foreach (ObstacleBase obs in environment.Obstacles)
                {
                    spentDamage.Add(theShell.WhatIsDamage(obs));
                }
            }
        }

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

    public override bool IsCorrectTypeOfDeflector(Ships.Ships ship, Enviroments.EnvironmentBase environment)
    {
        if (ship is not null && ship.Deflector is not null)
        {
            if (ship.Deflector.PhotonicDeflector) return true;
            return false;
        }

        return false;
    }

    public override bool IsCorrectTypeOfShell(Ships.Ships ship, Enviroments.EnvironmentBase environment)
    {
        return true;
    }

    public override bool IsCorrectTypeOfEngine(Ships.Ships ship, Enviroments.EnvironmentBase environment)
    {
        if (ship is not null && ship.Engine is not null)
        {
            foreach (Engines.EngineBase engine in ship.Engine)
            {
                if (engine is JumpMotorBase) return true;
                return false;
            }
        }

        return false;
    }

    public override bool CorrectDeflectorAndShell(Ships.Ships ship, Enviroments.EnvironmentBase environment)
    {
        bool deflector = IsCorrectTypeOfDeflector(ship, environment);
        if (deflector)
        {
            return true;
        }

        return false;
    }

    public override bool IsCorrectDamage(Ships.Ships ship, Enviroments.EnvironmentBase environment)
    {
        if (ship is not null && ship.Deflector is not null)
        {
            ICollection<double> damage = DamageDistribution(ship, environment);
            foreach (double theDamage in damage)
            {
                if (theDamage > 0 || ship.Deflector.PhotonicDeflector) return true;
                return false;
            }
        }

        return false;
    }

    public override ICollection<Condition> OvercomingObstacle(Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance)
    {
        ICollection<Condition> condition = new List<Condition>();
        bool protection = CorrectDeflectorAndShell(ship, environment);
        bool correctDamage = IsCorrectDamage(ship, environment);
        if (CanFlyThisDistance(ship, distance))
        {
            if (protection && correctDamage)
            {
                condition.Add(Condition.Success);
            }
            else
            {
                condition.Add(Condition.CrewDead);
                condition.Add(Condition.Lost);
            }
        }
        else
        {
            condition.Add(Condition.CrewDead);
            condition.Add(Condition.Lost);
        }

        return condition;
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
            foreach (Ships.Ships ship in ships)
            {
                ICollection<Condition> conditions = OvercomingObstacle(ship, environment, obstacle, distance);
                if (conditions.Contains(Condition.Success))
                {
                    IEnumerable<double> money = SpendedMoney(ship, spendedfuel);
                    IEnumerable<double> dublicateTwo;
                    dublicateTwo = money.ToList();
                    foreach (double theMoney in dublicateTwo)
                    {
                        double cost = dublicateTwo.Min();
                        foreach (double cash in dublicateTwo)
                        {
                            if (cash < cost)
                            {
                                result.Add(ship);
                            }
                        }
                    }
                }
            }
        }

        return result;
    }
}
