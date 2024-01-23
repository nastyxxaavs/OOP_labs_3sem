namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class HddBuilder
{
    private Hdd _hdd;

    public HddBuilder(Hdd hdd)
    {
        _hdd = hdd;
    }

    public HddBuilder BuildCapacity(double capacity)
    {
        _hdd.Capacity = capacity;
        return this;
    }

    public HddBuilder BuildSpindleSpeed(double spindlespeed)
    {
        _hdd.SpindleSpeed = spindlespeed;
        return this;
    }

    public HddBuilder BuildSpendedPower(double spendedPower)
    {
        _hdd.SpendedPower = spendedPower;
        return this;
    }

    public void AddHddToRepository(Repository repository)
    {
        if (repository is not null && repository.Hdds is not null)
        {
            if (!repository.Hdds.Contains(_hdd))
            {
                repository.Hdds.Add(_hdd);
            }
        }
    }

    public Hdd? Build()
    {
        Hdd hdd = _hdd;
        return hdd;
    }
}
