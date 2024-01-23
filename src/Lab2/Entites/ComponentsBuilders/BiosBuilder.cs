using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class BiosBuilder
{
    private Bios _bios;

    public BiosBuilder(Bios bios)
    {
        _bios = bios;
    }

    public BiosBuilder BuildType(string type)
    {
        _bios.Type = type;
        return this;
    }

    public BiosBuilder BuildVersion(string version)
    {
        _bios.Version = version;
        return this;
    }

    public BiosBuilder BuildCorrectCpu(ICollection<string> cpus)
    {
        _bios.CorrectCpu = cpus;
        return this;
    }

    public void AddBiosToRepository(Repository repository)
    {
        if (repository is not null && repository.Bioses is not null)
        {
            if (!repository.Bioses.Contains(_bios))
            {
                repository.Bioses.Add(_bios);
            }
        }
    }

    public Bios? Build()
    {
        Bios bios = _bios;
        bool result = CorrectAttributes.CorrectBuildingOfBios(bios);
        if (result)
        {
            return bios;
        }

        return null;
    }
}
