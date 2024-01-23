using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class CoolingSystemBuilder
{
    private CoolingSystem _coolingSystem;

    public CoolingSystemBuilder(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
    }

    public CoolingSystemBuilder BuildCoolingSystem(DimensionsOfCoolingSystem dimensionsOfCoolingSystem)
    {
        _coolingSystem.Dimensions = dimensionsOfCoolingSystem;
        return this;
    }

    public CoolingSystemBuilder BuildTdp(int tdp)
    {
        _coolingSystem.Tdp = tdp;
        return this;
    }

    public CoolingSystemBuilder BuildCorrectSockets(IList<string> socket)
    {
        _coolingSystem.CorrectSockets = socket;
        return this;
    }

    public void AddCoolingSystemToRepository(Repository repository)
    {
        if (repository is not null && repository.CoolingSystems is not null)
        {
            if (!repository.CoolingSystems.Contains(_coolingSystem))
            {
                repository.CoolingSystems.Add(_coolingSystem);
            }
        }
    }

    public CoolingSystem? Build()
    {
        CoolingSystem coolingSystem = _coolingSystem;
        bool result = CorrectAttributes.CorrectBuildingOfCoolingSystem(coolingSystem);
        if (result)
        {
            return coolingSystem;
        }

        return null;
    }
}
