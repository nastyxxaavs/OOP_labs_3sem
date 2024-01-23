namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors;

public class SecondLevel : DeflectorBase
{
    public SecondLevel(bool photonicDeflector)
    {
        Health = 60;
        PhotonicDeflector = photonicDeflector;
        IsOn = true;
    }

    public override DeflectorBase WhatIsDeflector()
    {
        DeflectorBase deflector = new SecondLevel(PhotonicDeflector);
        return deflector;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacleOne)
    {
        if (obstacleOne is Obstacles.Asteroids asteroids)
        {
            if (asteroids.Count() <= 10)
            {
                return Health - asteroids.Count();
            }

            IsOn = false;
            return -1;
        }

        if (obstacleOne is Obstacles.Meteorites meteorites)
        {
            if (meteorites.Count() <= 3)
            {
                return Health - meteorites.Count();
            }

            IsOn = false;
            return -1;
        }

        return -1;
    }
}
