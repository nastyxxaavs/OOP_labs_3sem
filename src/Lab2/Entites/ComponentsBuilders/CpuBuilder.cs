using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class CpuBuilder
{
    private Cpu _cpu;

    public CpuBuilder(Cpu cpu)
    {
        _cpu = cpu;
    }

    public CpuBuilder BuildName(string name)
    {
        _cpu.NameOfCpu = name;
        return this;
    }

    public CpuBuilder BuildCountOfCore(int countOfCore)
    {
        _cpu.CountOfCore = countOfCore;
        return this;
    }

    public CpuBuilder BuildCoreFrequency(double coreFrequency)
    {
        _cpu.CoreFrequency = coreFrequency;
        return this;
    }

    public CpuBuilder BuildSocket(string socket)
    {
        _cpu.Socket = socket;
        return this;
    }

    public CpuBuilder BuildVideoCore(bool videoCore)
    {
        _cpu.VideoCore = videoCore;
        return this;
    }

    public CpuBuilder BuildTdp(int tdp)
    {
        _cpu.Tdp = tdp;
        return this;
    }

    public CpuBuilder BuildSpendedPower(double spendedPower)
    {
        _cpu.SpendedPower = spendedPower;
        return this;
    }

    public CpuBuilder BuildDataFrequency(IList<int> data)
    {
        _cpu.DataFrequency = data;
        return this;
    }

    public void AddCpuToRepository(Repository repository)
    {
        if (repository is not null && repository.CPUs is not null)
        {
            if (!repository.CPUs.Contains(_cpu))
            {
                repository.CPUs.Add(_cpu);
            }
        }
    }

    public Cpu? Build()
    {
        Cpu cpu = _cpu;
        bool result = CorrectAttributes.CorrectBuildingOfCpu(cpu);
        if (result)
        {
            return cpu;
        }

        return null;
    }
}
