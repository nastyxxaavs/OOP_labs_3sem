using Itmo.ObjectOrientedProgramming.Lab2.Entites;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.MotherBoard;
namespace Itmo.ObjectOrientedProgramming.Lab2.Service;

public static class CorrectAttributes
{
    /*public static bool CorrectJedec(MotherBoard motherBoard, Ram ram)
    {
        if (motherBoard is not null && ram is not null && motherBoard.Chipset is not null && ram.CorrectJedec is not null)
        {
            if (motherBoard.Chipset == ram.CorrectJedec) return true;
            return false;
        }

        return false;
    }

    public static bool CorrectCpu(Bios bios, Cpu cpu)
    {
        if (cpu is not null && bios is not null && bios.CorrectCpu is not null && cpu.NameOfCpu is not null)
        {
            if (bios.CorrectCpu.Contains(cpu.NameOfCpu)) return true;
            return false;
        }

        return false;
    }

    public static bool CorrectDdr(Ram ram, MotherBoard motherBoard)
    {
        if (ram is not null && motherBoard is not null && ram.DdrVersion is not null && motherBoard.Ddr is not null)
        {
            if (ram.DdrVersion == motherBoard.Ddr) return true;
            return false;
        }

        return false;
    }

    public static bool CorrectXmp(MotherBoard motherBoard, Ram ram, XmpProfile xmp)
    {
        if (ram is not null && motherBoard is not null && ram.XmpProfiles is not null &&
            motherBoard.Chipset is not null && xmp is not null)
        {
            if (motherBoard.Xmp && ram.XmpProfiles.Name == xmp.Name)
            {
                if (motherBoard.Chipset.Contains(xmp.Frequency)) return true;
                return false;
            }

            return false;
        }

        return false;
    }

    public static bool Socket(MotherBoard motherBoard, Cpu cpu)
    {
        if (motherBoard is not null && cpu is not null && motherBoard.Socket is not null && cpu.Socket is not null)
        {
            if (motherBoard.Socket == cpu.Socket) return true;
            return false;
        }

        return false;
    }
*/
    public static bool CorrectBuildingOfMotherBoard(MotherBoard motherBoard)
    {
        if (motherBoard is not null)
        {
            if (motherBoard.Chipset is not null && motherBoard.Ddr is not null && motherBoard.Socket is not null &&
                motherBoard.Bios is not null && motherBoard.FormFactor is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfCoolingSystem(CoolingSystem coolingSystem)
    {
        if (coolingSystem is not null)
        {
            if (coolingSystem.CorrectSockets is not null && coolingSystem.Dimensions is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfFrame(Frame frame)
    {
        if (frame is not null)
        {
            if (frame.Dimensions is not null && frame.VideoCard is not null && frame.CorrectMotherBoard is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfRam(Ram ram)
    {
        if (ram is not null)
        {
            if (ram.DdrVersion is not null && ram.XmpProfiles is not null && ram.CorrectJedec is not null &&
                ram.FormFactor is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfVideoCard(VideoCard videoCard)
    {
        if (videoCard is not null)
        {
            if (videoCard.Dimensions is not null && videoCard.PciVersion is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfBios(Bios bios)
    {
        if (bios is not null)
        {
            if (bios.Type is not null && bios.Version is not null && bios.CorrectCpu is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfCpu(Cpu cpu)
    {
        if (cpu is not null)
        {
            if (cpu.Socket is not null && cpu.NameOfCpu is not null && cpu.DataFrequency is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfSsd(SsdDrive ssdDrive)
    {
        if (ssdDrive is not null)
        {
            if (ssdDrive.AddVarious is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfWifi(Wifi wifi)
    {
        if (wifi is not null)
        {
            if (wifi.PciVersion is not null && wifi.StandartVersion is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public static bool CorrectBuildingOfXmp(XmpProfile xmpProfile)
    {
        if (xmpProfile is not null)
        {
            if (xmpProfile.Timings is not null && xmpProfile.Name is not null)
            {
                return true;
            }

            return false;
        }

        return false;
    }
}
