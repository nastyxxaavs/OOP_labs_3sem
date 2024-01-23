using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class SsdDriveBuilder
{
    private SsdDrive _ssd;

    public SsdDriveBuilder(SsdDrive ssd)
    {
        _ssd = ssd;
    }

    public SsdDriveBuilder BuildVarious(string various)
    {
        _ssd.AddVarious = various;
        return this;
    }

    public SsdDriveBuilder BuildCapacity(double capacity)
    {
        _ssd.Capacity = capacity;
        return this;
    }

    public SsdDriveBuilder BuildMaxSpeed(double maxSpeed)
    {
        _ssd.MaxSpeedOpportunity = maxSpeed;
        return this;
    }

    public SsdDriveBuilder BuildSpendedPower(double spendedPower)
    {
        _ssd.SpendedPower = spendedPower;
        return this;
    }

    public void AddSsdToRepository(Repository repository)
    {
        if (repository is not null && repository.SsdDrives is not null)
        {
            if (!repository.SsdDrives.Contains(_ssd))
            {
                repository.SsdDrives.Add(_ssd);
            }
        }
    }

    public SsdDrive? Build()
    {
        SsdDrive ssdDrive = _ssd;
        bool result = CorrectAttributes.CorrectBuildingOfSsd(ssdDrive);
        if (result)
        {
            return ssdDrive;
        }

        return null;
    }
}
