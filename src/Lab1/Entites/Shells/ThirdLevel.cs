namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;

public class ThirdLevel : ShellBase
{
    public ThirdLevel()
    {
        Health = 20;
        IsOn = true;
    }

    public override ShellBase WhatIsShell()
    {
        ShellBase shell = new ThirdLevel();
        return shell;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacle)
    {
        if (obstacle is Obstacles.Asteroids asteroids)
        {
            if (asteroids.Count() <= 20)
            {
                return Health - (asteroids.Count() * asteroids.DamageCost());
            }

            IsOn = false;
        }

        if (obstacle is Obstacles.Meteorites meteorites)
        {
            if (meteorites.Count() <= 5)
            {
                return Health - (meteorites.Count() * meteorites.DamageCost());
            }

            IsOn = false;
        }

        return -1;
    }
}
