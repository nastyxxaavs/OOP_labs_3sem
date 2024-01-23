namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors;

public class PhotonicDeflector : DeflectorBase
{
    public PhotonicDeflector(bool photonicDeflector)
    {
        Health = 60;
        PhotonicDeflector = photonicDeflector;
    }

    public override DeflectorBase WhatIsDeflector()
    {
        DeflectorBase deflector = new PhotonicDeflector(PhotonicDeflector);
        return deflector;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacleOne)
    {
        if (obstacleOne is Obstacles.AntimatterFlares flares)
        {
            if (flares.Count() <= 3)
            {
                return Health - flares.Count();
            }

            IsOn = false;
        }

        return -1;
    }
}
