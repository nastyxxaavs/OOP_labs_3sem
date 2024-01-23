namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors;

public class ThirdLevel : DeflectorBase
{
    public ThirdLevel(bool photonicDeflector)
    {
        Health = 60;
        PhotonicDeflector = photonicDeflector;
        IsOn = true;
    }

    public override DeflectorBase WhatIsDeflector()
    {
        DeflectorBase deflector = new ThirdLevel(PhotonicDeflector);
        return deflector;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacleOne)
    {
        if (obstacleOne is Obstacles.Asteroids asteroids)
        {
            if (asteroids.Count() <= 40)
            {
                return Health - asteroids.Count();
            }

            IsOn = false;
            return -1;
        }

        if (obstacleOne is Obstacles.Meteorites meteorites)
        {
            if (meteorites.Count() <= 10)
            {
                return Health - meteorites.Count();
            }

            IsOn = false;
            return -1;
        }

        if (obstacleOne is Obstacles.SpaceWhales whales)
        {
            if (whales.Count() <= 1)
            {
                return Health - whales.Count();
            }

            IsOn = false;
            return -1;
        }

        return -1;
    }
}
