using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class WifiBuilder
{
    private Wifi _wifi;

    public WifiBuilder(Wifi wifi)
    {
        _wifi = wifi;
    }

    public WifiBuilder BuildVersion(string standart)
    {
        _wifi.StandartVersion = standart;
        return this;
    }

    public WifiBuilder BuildBluetooth(bool bluetooth)
    {
        _wifi.Bluetooth = bluetooth;
        return this;
    }

    public WifiBuilder BuildPciVersion(string pciVersion)
    {
        _wifi.PciVersion = pciVersion;
        return this;
    }

    public WifiBuilder BuildSpendedPower(double spendedPower)
    {
        _wifi.SpendedPower = spendedPower;
        return this;
    }

    public void AddWifiToRepository(Repository repository)
    {
        if (repository is not null && repository.WifiAdapters is not null)
        {
            if (!repository.WifiAdapters.Contains(_wifi))
            {
                repository.WifiAdapters.Add(_wifi);
            }
        }
    }

    public Wifi? Build()
    {
        Wifi wifi = _wifi;
        bool result = CorrectAttributes.CorrectBuildingOfWifi(wifi);
        if (result)
        {
            return wifi;
        }

        return null;
    }
}
