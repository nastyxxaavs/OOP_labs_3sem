using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Obstacles;

public abstract class ObstacleBase
{
    public int Damage { get; set; }

    public abstract int DamageCost();
    public abstract int Count();

    public abstract ICollection<double> DamageDistribution(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment);
    public abstract ICollection<double> LengthOpportunity(Entites.Ships.Ships ship);
    public abstract bool CanFlyThisDistance(Entites.Ships.Ships ship, double distance);

    public abstract bool IsCorrectTypeOfDeflector(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment);
    public abstract bool IsCorrectTypeOfShell(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment);
    public abstract bool IsCorrectTypeOfEngine(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment);

    public abstract bool IsCorrectDamage(Entites.Ships.Ships ship, Enviroments.EnvironmentBase environment);

    public abstract bool CorrectDeflectorAndShell(Entites.Ships.Ships ship, Enviroments.EnvironmentBase environment);

    public abstract ICollection<double> TimeOfFlight(double distance, Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment);
    public abstract ICollection<double> SpendedFuel(Entites.Ships.Ships ship, double spendedfuel);
    public abstract ICollection<double> SpendedMoney(Entites.Ships.Ships ship, double spendedfuel);
    public abstract ICollection<Ships.Ships> TheBestShip(ICollection<Ships.Ships> ships, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance, double spendedfuel);

    public abstract ICollection<Condition> OvercomingObstacle(Entites.Ships.Ships ship, Entites.Enviroments.EnvironmentBase environment, Obstacles.ObstacleBase obstacle, double distance);
}
