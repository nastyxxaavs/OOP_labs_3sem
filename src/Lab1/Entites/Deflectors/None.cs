namespace Itmo.ObjectOrientedProgramming.Lab1.Entites.Deflectors;

public class None : DeflectorBase
{
    public None(bool photonicDeflector)
    {
        Health = 0;
        PhotonicDeflector = photonicDeflector;
    }

    public override DeflectorBase WhatIsDeflector()
    {
        DeflectorBase deflector = new None(PhotonicDeflector);
        return deflector;
    }

    public override double WhatIsDamage(Obstacles.ObstacleBase obstacleOne)
    {
            return -1;
    }
}
