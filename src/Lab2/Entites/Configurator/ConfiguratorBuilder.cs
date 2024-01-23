using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entites;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ConfiguratorBuilder
{
    private PC _pc;

    public ConfiguratorBuilder(PC pc)
    {
        _pc = pc;
    }

    public PC? Build()
    {
        PC pc = _pc;
        ICollection<Condition> result = CorrectDetails.CorrectBuilding(pc);
        if (result.Contains(Condition.Success))
        {
            return pc;
        }

        return null;
    }

    public ConfiguratorBuilder BuildMotherBoard(MotherBoard motherBoard)
    {
        _pc.Motherboard = motherBoard;
        return this;
    }

    public ConfiguratorBuilder BuildCpu(Cpu cpu)
    {
        _pc.CPU = cpu;
        return this;
    }

    public ConfiguratorBuilder BuildCoolingSystem(CoolingSystem coolingSystem)
    {
        _pc.CoolingSystem = coolingSystem;
        return this;
    }

    public ConfiguratorBuilder BuildRam(Ram ram)
    {
        _pc.RAM = ram;
        return this;
    }

    public ConfiguratorBuilder BuildFrame(Frame frame)
    {
        _pc.Frame = frame;
        return this;
    }

    public ConfiguratorBuilder BuildPowerUnit(PowerUnit powerUnit)
    {
        _pc.PowerUnit = powerUnit;
        return this;
    }

    public ConfiguratorBuilder BuildBios(Bios bios)
    {
        _pc.Bios = bios;
        return this;
    }

    public ConfiguratorBuilder BuildWifi(Wifi wifi)
    {
        _pc.WIFI = wifi;
        return this;
    }

    public ConfiguratorBuilder BuildHdd(Hdd hdd)
    {
        _pc.HDD = hdd;
        return this;
    }

    public ConfiguratorBuilder BuildXmp(XmpProfile xmpProfile)
    {
        _pc.XMP = xmpProfile;
        return this;
    }

    public ConfiguratorBuilder BuildVideoCard(VideoCard videoCard)
    {
        _pc.VideoCard = videoCard;
        return this;
    }

    public ConfiguratorBuilder BuildSdd(SsdDrive ssdDrive)
    {
        _pc.SSD = ssdDrive;
        return this;
    }
}
