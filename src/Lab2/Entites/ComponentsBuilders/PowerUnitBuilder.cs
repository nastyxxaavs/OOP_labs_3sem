namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class PowerUnitBuilder
{
    private PowerUnit _powerUnit;

    public PowerUnitBuilder(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
    }

    public PowerUnitBuilder BuildMaxPower(double maxPower)
    {
        _powerUnit.MaxPower = maxPower;
        return this;
    }

    public void AddPowerUnitToRepository(Repository repository)
    {
        if (repository is not null && repository.PowerUnits is not null)
        {
            if (!repository.PowerUnits.Contains(_powerUnit))
            {
                repository.PowerUnits.Add(_powerUnit);
            }
        }
    }

    public PowerUnit? Build()
    {
        PowerUnit powerUnit = _powerUnit;
        return powerUnit;
    }
}
