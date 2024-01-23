using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class RepositoryComplectation
{
    private readonly Repository _repository;

    public RepositoryComplectation(Repository repository)
    {
        _repository = repository;
    }

    public void InitData()
    {
        InitMotherBoard();
        InitCPUs();
        InitCoolingSystems();
        InitVideoCards();
        InitSSDs();
        InitHDDs();
        InitFrames();
        InitPowerUnits();
        InitXMPs();
        InitWifi();
        InitBios();
        InitRAMs();
    }

    private void InitMotherBoard()
    {
        if (_repository.MotherBoards is null) return;
        _repository.MotherBoards.Add(new MotherBoard.MotherBoard
        {
            Socket = "AM4",
            CountPCI = 28,
            CountSATA = 4,
            Chipset = new List<double>() { 3200 },
            Ddr = "DDR4",
            Xmp = true,
            RAMsticks = 4,
            FormFactor = new DimensionsOfMotherBoard()
            {
                Length = 0,
                Width = 244, // в мм
                Height = 305,
            },
            Bios = "F50",
            HaveWifi = false,
        });
        _repository.MotherBoards.Add(new MotherBoard.MotherBoard
        {
            Socket = "LGA 1700",
            CountPCI = 28,
            CountSATA = 6,
            Chipset = new List<double>() { 5600 },
            Ddr = "DDR5",
            Xmp = true,
            RAMsticks = 4,
            FormFactor = new DimensionsOfMotherBoard()
            {
                Length = 0,
                Width = 244, // в мм
                Height = 305,
            },
            Bios = "F50",
            HaveWifi = true,
        });
        _repository.MotherBoards.Add(new MotherBoard.MotherBoard
        {
            Socket = "LGA 1200",
            CountPCI = 24,
            CountSATA = 6,
            Chipset = new List<double>() { 3200 },
            Ddr = "DDR4",
            Xmp = true,
            RAMsticks = 4,
            FormFactor = new DimensionsOfMotherBoard()
            {
                Length = 0,
                Width = 243, // в мм
                Height = 243,
            },
            Bios = "F50",
            HaveWifi = false,
        });
    }

    private void InitBios()
    {
        if (_repository.Bioses is null) return;
        _repository.Bioses.Add(new Bios
        {
            Type = "AMI",
            Version = "F50",
            CorrectCpu = new List<string>() { "Intel Core i5-12400F OEM", "Intel Core i3-12100F OEM" },
        });
        _repository.Bioses.Add(new Bios
        {
            Type = "Award",
            Version = "F50",
            CorrectCpu = new List<string>() { "Intel Core i3-12100F OEM", "AMD Ryzen 5 5600X OEM" },
        });
        _repository.Bioses.Add(new Bios
        {
            Type = "Intel",
            Version = "F50",
            CorrectCpu = new List<string>() { "AMD Ryzen 5 5600X OEM" },
        });
    }

    private void InitWifi()
    {
        if (_repository.WifiAdapters is null) return;
        _repository.WifiAdapters.Add(new Wifi
        {
            StandartVersion = "TP-LINK Archer T5E",
            Bluetooth = true,
            PciVersion = "PCI-E x1",
            SpendedPower = 79,
        });
        _repository.WifiAdapters.Add(new Wifi
        {
            StandartVersion = "ASUS PCE-AXE5400",
            Bluetooth = true,
            PciVersion = "PCI-E x3",
            SpendedPower = 100,
        });
        _repository.WifiAdapters.Add(new Wifi
        {
            StandartVersion = "TP-LINK Archer TX20E",
            Bluetooth = true,
            PciVersion = "PCI-E x4",
            SpendedPower = 100,
        });
    }

    private void InitCPUs()
    {
        if (_repository.CPUs is null) return;
        _repository.CPUs.Add(new Cpu
        {
            NameOfCpu = "Intel Core i5-12400F OEM",
            CountOfCore = 6,
            CoreFrequency = 250,
            Socket = "LGA 1700",
            VideoCore = false,
            DataFrequency = new List<int>() { 4800, 3200 },
            Tdp = 65,
            SpendedPower = 260,
        });
        _repository.CPUs.Add(new Cpu
        {
            NameOfCpu = "AMD Ryzen 5 5600X OEM",
            CountOfCore = 2,
            CoreFrequency = 350,
            Socket = "LGA 1200",
            VideoCore = true,
            DataFrequency = new List<int>() { 2666 },
            Tdp = 58,
            SpendedPower = 170,
        });
        _repository.CPUs.Add(new Cpu
        {
            NameOfCpu = "Intel Core i3-12100F OEM",
            CountOfCore = 16,
            CoreFrequency = 340,
            Socket = "AM4",
            VideoCore = false,
            DataFrequency = new List<int>() { 3200 },
            Tdp = 105,
            SpendedPower = 142,
        });
    }

    private void InitCoolingSystems()
    {
        if (_repository.CoolingSystems is null) return;

        _repository.CoolingSystems.Add(new CoolingSystem
        {
            Dimensions = new DimensionsOfCoolingSystem()
            {
                Height = 160,
                Width = 129,
                Length = 138,
            },
            CorrectSockets = new List<string>()
            { "AM2", "AM3", "AM4", "AM5", "FM1", "FM2", "LGA 1151", "LGA 1155", "LGA 1200", "LGA 1700" },
            Tdp = 260,
        });
        _repository.CoolingSystems.Add(new CoolingSystem
        {
            Dimensions = new DimensionsOfCoolingSystem()
            {
                Height = 136,
                Width = 121,
                Length = 76,
            },
            CorrectSockets = new List<string>()
                { "AM4", "AM5", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1200", "LGA 1700" },
            Tdp = 130,
        });
        _repository.CoolingSystems.Add(new CoolingSystem
        {
            Dimensions = new DimensionsOfCoolingSystem()
            {
                Height = 158,
                Width = 129,
                Length = 103,
            },
            CorrectSockets = new List<string>()
                { "AM4", "AM5", "FM1", "FM2", "LGA 1150", "LGA 1151", "LGA 1155", "LGA 1200", "LGA 1700" },
            Tdp = 180,
        });
    }

    private void InitVideoCards()
    {
        if (_repository.VideoCards is null) return;

        _repository.VideoCards.Add(new VideoCard
        {
            Dimensions = new DimensionsOfVideoCard()
            {
                Length = 294,
                Width = 118,
                Height = 53,
            },
            Storage = 8,
            PciVersion = "PCI-E x4",
            ChipFrequency = 1410,
            SpendedPower = 225,
        });
        _repository.VideoCards.Add(new VideoCard
        {
            Dimensions = new DimensionsOfVideoCard()
            {
                Length = 329,
                Width = 133,
                Height = 64,
            },
            Storage = 12,
            PciVersion = "PCI-E x4",
            ChipFrequency = 2310,
            SpendedPower = 285,
        });
        _repository.VideoCards.Add(new VideoCard
        {
            Dimensions = new DimensionsOfVideoCard()
            {
                Length = 200,
                Width = 111,
                Height = 33,
            },
            Storage = 4,
            PciVersion = "PCI-E x3",
            ChipFrequency = 1410,
            SpendedPower = 90,
        });
    }

    private void InitSSDs()
    {
        if (_repository.SsdDrives is null) return;
        _repository.SsdDrives.Add(new SsdDrive
        {
            AddVarious = "SATA",
            Capacity = 240,
            MaxSpeedOpportunity = 520,
            SpendedPower = 200,
        });
        _repository.SsdDrives.Add(new SsdDrive
        {
            AddVarious = "SATA",
            Capacity = 960,
            MaxSpeedOpportunity = 550,
            SpendedPower = 400,
        });
        _repository.SsdDrives.Add(new SsdDrive
        {
            AddVarious = "PCI-E",
            Capacity = 500,
            MaxSpeedOpportunity = 3500,
            SpendedPower = 90,
        });
    }

    private void InitHDDs()
    {
        if (_repository.Hdds is null) return;

        _repository.Hdds.Add(new Hdd
        {
            Capacity = 2000,
            SpindleSpeed = 7200,
            SpendedPower = 370,
        });
        _repository.Hdds.Add(new Hdd
        {
            Capacity = 4000,
            SpindleSpeed = 5400,
            SpendedPower = 470,
        });
        _repository.Hdds.Add(new Hdd
        {
            Capacity = 1000,
            SpindleSpeed = 7200,
            SpendedPower = 600,
        });
    }

    private void InitFrames()
    {
        if (_repository.Frames is null) return;

        _repository.Frames.Add(new Frame
        {
            Dimensions = new DimensionsOfFrame()
            {
                Length = 465,
                Width = 340,
                Height = 496,
            },
            VideoCard = new VideoCardOpportunity()
            {
                Length = 390,
                Width = 140,
                Height = 70,
            },
            CorrectMotherBoard = new DimensionsOfMotherBoard()
            {
                Width = 250,
                Length = 310,
                Height = 305,
            },
        });
        _repository.Frames.Add(new Frame
        {
            Dimensions = new DimensionsOfFrame()
            {
                Length = 562,
                Width = 238,
                Height = 523,
            },
            VideoCard = new VideoCardOpportunity()
            {
                Length = 435,
                Width = 207,
                Height = 94,
            },
            CorrectMotherBoard = new DimensionsOfMotherBoard()
            {
                Width = 308,
                Length = 355,
                Height = 243,
            },
        });
        _repository.Frames.Add(new Frame
        {
            Dimensions = new DimensionsOfFrame()
            {
                Length = 360,
                Width = 175,
                Height = 360,
            },
            VideoCard = new VideoCardOpportunity()
            {
                Length = 300,
                Width = 105,
                Height = 64,
            },
            CorrectMotherBoard = new DimensionsOfMotherBoard()
            {
                Width = 203,
                Length = 179,
                Height = 48,
            },
        });
    }

    private void InitPowerUnits()
    {
        if (_repository.PowerUnits is null) return;

        _repository.PowerUnits.Add(new PowerUnit
        {
            MaxPower = 600,
        });
        _repository.PowerUnits.Add(new PowerUnit
        {
            MaxPower = 700,
        });
        _repository.PowerUnits.Add(new PowerUnit
        {
            MaxPower = 800,
        });
    }

    private void InitXMPs()
    {
        if (_repository.XmpProfiles is null) return;

        _repository.XmpProfiles.Add(new XmpProfile
        {
            Name = "XMP2",
            Timings = "16-20-20",
            Voltage = 135,
            Frequency = 3200,
        });
        _repository.XmpProfiles.Add(new XmpProfile
        {
            Name = "XMP1",
            Timings = "16-18-18",
            Voltage = 125,
            Frequency = 3200,
        });
        _repository.XmpProfiles.Add(new XmpProfile
        {
            Name = "XMP3",
            Timings = "40-40-40",
            Voltage = 160,
            Frequency = 5600,
        });
    }

    private void InitRAMs()
    {
        if (_repository.RAMs is null) return;

        _repository.RAMs.Add(new Ram
        {
            SizeOpportunity = 16,
            CorrectJedec = new List<double>() { 1066, 2066, 3060 },
            FormFactor = new DimensionsOfRam()
            {
                Length = 150,
                Width = 6,
                Height = 34,
            },
            DdrVersion = "DDR4",
            SpendedPower = 135,
            XmpProfiles = new XmpProfile { Name = "XMP2" }, // Voltage = 1.35f, Timings = "16-20-20"
        });
        _repository.RAMs.Add(new Ram
        {
            SizeOpportunity = 16,
            CorrectJedec = new List<double>() { 2066, 3066 },
            FormFactor = new DimensionsOfRam()
            {
                Length = 150,
                Height = 35,
                Width = 6,
            },
            DdrVersion = "DDR5",
            SpendedPower = 125,
            XmpProfiles = new XmpProfile { Name = "XMP3" }, // Voltage = 1.25f, Timings = "40-40-40"
        });
        _repository.RAMs.Add(new Ram
        {
            SizeOpportunity = 16,
            CorrectJedec = new List<double>() { 1066, 2066 },
            FormFactor = new DimensionsOfRam()
            {
                Length = 150,
                Height = 34,
                Width = 6,
            },
            DdrVersion = "DDR4",
            SpendedPower = 145,
            XmpProfiles = new XmpProfile { Name = "XMP2" }, // Voltage = 1.45f, Timings = "18-22-22"
        });
    }
}
