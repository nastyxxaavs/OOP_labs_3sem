namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;

public class SecondLevel : ShellBase
{
    public SecondLevel()
    {
        Health = 20;
        IsOn = true;
    }

    public override ShellBase WhatIsShell()
    {
        ShellBase shell = new SecondLevel();
        return shell;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacle)
    {
        if (obstacle is Obstacles.Asteroids asteroids)
        {
            if (asteroids.Count() <= 5)
            {
                return Health - (asteroids.Count() * asteroids.DamageCost());
            }

            IsOn = false;
        }

        if (obstacle is Obstacles.Meteorites meteorites)
        {
            if (meteorites.Count() <= 2)
            {
                return Health - (meteorites.Count() * meteorites.DamageCost());
            }

            IsOn = false;
        }

        return -1;
    }
}
