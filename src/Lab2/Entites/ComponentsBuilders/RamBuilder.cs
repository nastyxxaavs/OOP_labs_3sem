using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class RamBuilder
{
    private Ram _ram;

    public RamBuilder(Ram ram)
    {
        _ram = ram;
    }

    public RamBuilder BuildSize(double size)
    {
        _ram.SizeOpportunity = size;
        return this;
    }

    public RamBuilder BuildXmps(XmpProfile xmp)
    {
        _ram.XmpProfiles = xmp;
        return this;
    }

    public RamBuilder BuildFormFactor(DimensionsOfRam dimensionsOfRam)
    {
        _ram.FormFactor = dimensionsOfRam;
        return this;
    }

    public RamBuilder BuildDdrVersion(string dderVersion)
    {
        _ram.DdrVersion = dderVersion;
        return this;
    }

    public RamBuilder BuildSpendedPower(double spendedPower)
    {
        _ram.SpendedPower = spendedPower;
        return this;
    }

    public RamBuilder BuildCorrectJedec(IList<double> jedec)
    {
        _ram.CorrectJedec = jedec;
        return this;
    }

    public void AddRamToRepository(Repository repository)
    {
        if (repository is not null && repository.RAMs is not null)
        {
            if (!repository.RAMs.Contains(_ram))
            {
                repository.RAMs.Add(_ram);
            }
        }
    }

    public Ram? Build()
    {
        Ram ram = _ram;
        bool result = CorrectAttributes.CorrectBuildingOfRam(ram);
        if (result)
        {
            return ram;
        }

        return null;
    }
}
