using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entites;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ConfiguratorBaseBuilder
{
    private PC? _pc;

    public ConfiguratorBaseBuilder(PC? pc)
    {
        _pc = pc;
    }

    public PC? Build()
    {
        PC? pc = _pc;
        ICollection<Condition> result = CorrectDetails.CorrectBuilding(pc);
        if (result.Contains(Condition.Success))
        {
            return pc;
        }

        return null;
    }

    public ConfiguratorBaseBuilder BuildMotherBoard(MotherBoard motherBoard)
    {
        if (_pc is not null)
        {
            _pc.Motherboard = motherBoard;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildCpu(Cpu cpu)
    {
        if (_pc is not null)
        {
            _pc.CPU = cpu;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildCoolingSystem(CoolingSystem coolingSystem)
    {
        if (_pc is not null)
        {
            _pc.CoolingSystem = coolingSystem;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildRam(Ram ram)
    {
        if (_pc is not null)
        {
            _pc.RAM = ram;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildFrame(Frame frame)
    {
        if (_pc is not null)
        {
            _pc.Frame = frame;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildPowerUnit(PowerUnit powerUnit)
    {
        if (_pc is not null)
        {
            _pc.PowerUnit = powerUnit;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildBios(Bios bios)
    {
        if (_pc is not null)
        {
            _pc.Bios = bios;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildWifi(Wifi wifi)
    {
        if (_pc is not null)
        {
            _pc.WIFI = wifi;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildHdd(Hdd hdd)
    {
        if (_pc is not null)
        {
            _pc.HDD = hdd;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildXmp(XmpProfile xmpProfile)
    {
        if (_pc is not null)
        {
            _pc.XMP = xmpProfile;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildVideoCard(VideoCard videoCard)
    {
        if (_pc is not null)
        {
            _pc.VideoCard = videoCard;
        }

        return this;
    }

    public ConfiguratorBaseBuilder BuildSdd(SsdDrive ssdDrive)
    {
        if (_pc is not null)
        {
            _pc.SSD = ssdDrive;
        }

        return this;
    }
}
