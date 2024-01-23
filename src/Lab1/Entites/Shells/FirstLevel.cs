namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.HullStrength;

public class FirstLevel : ShellBase
{
    public FirstLevel()
    {
        Health = 20;
        IsOn = true;
    }

    public override ShellBase WhatIsShell()
    {
        ShellBase shell = new FirstLevel();
        return shell;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacle)
    {
        if (obstacle is Obstacles.Asteroids asteroids)
        {
            if (asteroids.Count() <= 1)
            {
                return Health - (asteroids.Count() * asteroids.DamageCost());
            }

            IsOn = false;
        }

        return -1;
    }
}
