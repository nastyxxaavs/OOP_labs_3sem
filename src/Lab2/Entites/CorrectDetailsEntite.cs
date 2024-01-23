using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class CorrectDetailsEntite
{
    private ICollection<Condition> successful = new List<Condition>();
    public static ICollection<Condition> CorrectVideoSettings(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.CPU is not null)
        {
            if (!pc.CPU.VideoCore && pc.VideoCard is null) condition.Add(Condition.Failure);

            condition.Add(Condition.Success);
        }

        return condition;
    }

    public static ICollection<Condition> CorrectStorageDevice(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null)
        {
            if (pc.SSD is null && pc.HDD is null) condition.Add(Condition.Failure);
            condition.Add(Condition.Success);
        }

        return condition;
    }

    public static ICollection<Condition> CorrectTdpInCoolingSystem(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.CoolingSystem is not null)
        {
            if (pc.CoolingSystem.Tdp == 130)
            {
                condition.Add(Condition.Refusal);
                condition.Add(Condition.Success);
            }

            if (pc.CoolingSystem.Tdp < 130)
            {
                condition.Add(Condition.Failure);
            }

            if (pc.CoolingSystem.Tdp > 130)
            {
                condition.Add(Condition.Success);
            }
        }

        return condition;
    }

    public static ICollection<Condition> CorrectWifiSystem(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.Motherboard is not null && pc.WIFI is not null)
        {
            if (pc.Motherboard.HaveWifi && pc.WIFI.PciVersion is not null)
            {
                condition.Add(Condition.Failure);
            }

            if ((pc.Motherboard.HaveWifi && pc.WIFI.PciVersion is null) || (!pc.Motherboard.HaveWifi && pc.WIFI.PciVersion is not null))
            {
                condition.Add(Condition.Success);
            }
        }

        return condition;
    }

    public static bool CorrectComponentsSize(PC? pc)
    {
        if (pc is not null && pc.Frame is not null && pc.Frame.Dimensions is not null && pc.CoolingSystem is not null && pc.Frame.CorrectMotherBoard is not null && pc.CoolingSystem.Dimensions is not null)
        {
            if ((pc.Frame.CorrectMotherBoard.Length + pc.CoolingSystem.Dimensions.Length < pc.Frame.Dimensions.Length) && (pc.Frame.CorrectMotherBoard.Width + pc.CoolingSystem.Dimensions.Width < pc.Frame.Dimensions.Width) && (pc.Frame.CorrectMotherBoard.Height + pc.CoolingSystem.Dimensions.Height < pc.Frame.Dimensions.Height))
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static ICollection<Condition> CorrectSize(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null)
        {
            if (CorrectComponentsSize(pc))
            {
                condition.Add(Condition.Success);
            }
            else
            {
                condition.Add(Condition.Failure);
            }
        }

        return condition;
    }

    public static ICollection<Condition> CorrectPowerUnits(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.PowerUnit is not null)
        {
            if (pc.PowerUnit.MaxPower == 700)
            {
                condition.Add(Condition.Warning);
                condition.Add(Condition.Success);
            }

            if (pc.PowerUnit.MaxPower < 700)
            {
                condition.Add(Condition.Failure);
            }

            if (pc.PowerUnit.MaxPower > 700)
            {
                condition.Add(Condition.Success);
            }
        }

        return condition;
    }

    public static ICollection<Condition> CorrectJedec(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.Motherboard is not null && pc.RAM is not null && pc.Motherboard.Chipset is not null && pc.RAM.CorrectJedec is not null)
        {
            foreach (double jedec in pc.Motherboard.Chipset)
            {
                foreach (double jedec2 in pc.RAM.CorrectJedec)
                {
                    if (jedec == jedec2)
                    {
                        condition.Add(Condition.Success);
                    }
                    else
                    {
                        condition.Add(Condition.Failure);
                    }
                }
            }
        }

        return condition;
    }

    public static ICollection<Condition> CorrectCpu(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.CPU is not null && pc.Bios is not null && pc.Bios.CorrectCpu is not null)
        {
            if (pc.Bios.CorrectCpu.Contains(pc.CPU.NameOfCpu))
            {
                condition.Add(Condition.Success);
            }
            else
            {
                condition.Add(Condition.Failure);
            }
        }

        return condition;
    }

    public static ICollection<Condition> CorrectDdr(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.RAM is not null && pc.Motherboard is not null && pc.RAM.DdrVersion is not null &&
            pc.Motherboard.Ddr is not null)
        {
            if (pc.RAM.DdrVersion == pc.Motherboard.Ddr)
            {
                condition.Add(Condition.Success);
            }
            else
            {
                condition.Add(Condition.Failure);
            }
        }

        return condition;
    }

    public static ICollection<Condition> CorrectXmp(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.RAM is not null && pc.Motherboard is not null && pc.RAM.XmpProfiles is not null &&
            pc.Motherboard.Chipset is not null && pc.XMP is not null)
        {
            if (pc.Motherboard.Xmp && (pc.RAM.XmpProfiles.Name == pc.XMP.Name))
            {
                if (pc.Motherboard.Chipset.Contains(pc.XMP.Frequency))
                {
                    condition.Add(Condition.Success);
                }
                else
                {
                    condition.Add(Condition.Failure);
                }
            }
            else
            {
                condition.Add(Condition.Failure);
            }

            return condition;
        }

        return condition;
    }

    public static ICollection<Condition> Socket(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null && pc.Motherboard is not null && pc.CPU is not null && pc.Motherboard.Socket is not null && pc.CPU.Socket is not null)
        {
            if (pc.Motherboard.Socket == pc.CPU.Socket)
            {
                condition.Add(Condition.Success);
            }
            else
            {
                condition.Add(Condition.Failure);
            }
        }

        return condition;
    }

    public ICollection<Condition> CorrectBuilding(PC? pc)
    {
        ICollection<Condition> condition = new List<Condition>();
        if (pc is not null)
        {
            ICollection<Condition> res1 = CorrectSize(pc);
            ICollection<Condition> res2 = CorrectVideoSettings(pc);
            ICollection<Condition> res3 = CorrectStorageDevice(pc);
            ICollection<Condition> res4 = CorrectPowerUnits(pc);
            ICollection<Condition> res5 = CorrectWifiSystem(pc);
            ICollection<Condition> res6 = CorrectTdpInCoolingSystem(pc);
            ICollection<Condition> res7 = Socket(pc);
            ICollection<Condition> res8 = CorrectXmp(pc);
            ICollection<Condition> res9 = CorrectDdr(pc);
            ICollection<Condition> res10 = CorrectCpu(pc);
            ICollection<Condition> res11 = CorrectJedec(pc);
            if (res1.Contains(Condition.Success) && res2.Contains(Condition.Success) &&
                res3.Contains(Condition.Success) && res4.Contains(Condition.Success) &&
                res5.Contains(Condition.Success) && res6.Contains(Condition.Success) &&
                res7.Contains(Condition.Success) && res8.Contains(Condition.Success) &&
                res9.Contains(Condition.Success) && res10.Contains(Condition.Success) &&
                res11.Contains(Condition.Success))
            {
                condition.Add(Condition.Success);
                successful.Add(Condition.Success);
                if (res6.Contains(Condition.Refusal))
                {
                    condition.Add(Condition.Refusal);
                }

                if (res4.Contains(Condition.Warning))
                {
                    condition.Add(Condition.Warning);
                }
            }
        }
        else
        {
            condition.Add(Condition.Failure);
        }

        return condition;
    }

    public string ResultOfConditions(PC? pc)
    {
        string result;
        if (pc is not null)
        {
            ICollection<Condition> res1 = CorrectSize(pc);
            ICollection<Condition> res2 = CorrectVideoSettings(pc);
            ICollection<Condition> res3 = CorrectStorageDevice(pc);
            ICollection<Condition> res4 = CorrectPowerUnits(pc);
            ICollection<Condition> res5 = CorrectWifiSystem(pc);
            ICollection<Condition> res6 = CorrectTdpInCoolingSystem(pc);
            ICollection<Condition> res7 = Socket(pc);
            ICollection<Condition> res8 = CorrectXmp(pc);
            ICollection<Condition> res9 = CorrectDdr(pc);
            ICollection<Condition> res10 = CorrectCpu(pc);
            ICollection<Condition> res11 = CorrectJedec(pc);
            if (res1.Contains(Condition.Success) && res2.Contains(Condition.Success) &&
                res3.Contains(Condition.Success) && res4.Contains(Condition.Success) &&
                res5.Contains(Condition.Success) && res6.Contains(Condition.Success) &&
                res7.Contains(Condition.Success) && res8.Contains(Condition.Success) &&
                res9.Contains(Condition.Success) && res10.Contains(Condition.Success) &&
                res11.Contains(Condition.Success))
            {
                result = "PC assembly was successful!";
                successful.Add(Condition.Success);
                if (res6.Contains(Condition.Refusal))
                {
                    result = "Refusal: Disclaimer of warranty. But PC assembly was successful!";
                }

                if (res4.Contains(Condition.Warning))
                {
                    result =
                        "You have been deceived: the amount of power consumed is less than indicated! But PC assembly was successful!";
                }

                return result;
            }
        }

        return "PC assembly failed!";
    }

    public ICollection<string> SpecificReason(PC? pc)
    {
        ICollection<Condition> res1 = CorrectSize(pc);
        ICollection<Condition> res2 = CorrectVideoSettings(pc);
        ICollection<Condition> res3 = CorrectStorageDevice(pc);
        ICollection<Condition> res4 = CorrectPowerUnits(pc);
        ICollection<Condition> res5 = CorrectWifiSystem(pc);
        ICollection<Condition> res6 = CorrectTdpInCoolingSystem(pc);
        ICollection<Condition> res7 = Socket(pc);
        ICollection<Condition> res8 = CorrectXmp(pc);
        ICollection<Condition> res9 = CorrectDdr(pc);
        ICollection<Condition> res10 = CorrectCpu(pc);
        ICollection<Condition> res11 = CorrectJedec(pc);
        ICollection<string> result = new List<string>();
        successful.Add(Condition.Success);
        if (res1.Contains(Condition.Failure)) result.Add("You need a videoCard!");
        if (res2.Contains(Condition.Failure)) result.Add("You need a SSD or HHD, what do you prefer?");
        if (res3.Contains(Condition.Failure)) result.Add("Cooling System is so bad!");
        if (res4.Contains(Condition.Failure)) result.Add("You need an wifi-adapter!");
        if (res5.Contains(Condition.Failure)) result.Add("Cooling system and Motherboard do not match with this frame, because they are so big!");
        if (res6.Contains(Condition.Failure)) result.Add("PowerUnit is so bad!");
        if (res7.Contains(Condition.Failure)) result.Add("Motherboard and RAM don't fit together!");
        if (res8.Contains(Condition.Failure)) result.Add("Please change Cpu!");
        if (res9.Contains(Condition.Failure)) result.Add("Motherboard and RAM don't fit together, they have problem with ddr!");
        if (res10.Contains(Condition.Failure)) result.Add("Motherboard and RAM don't fit together, they have problem with xmp!");
        if (res11.Contains(Condition.Failure)) result.Add("Motherboard and Cpu don't fit together, they have problem with sockets!");
        return result;
    }
}
