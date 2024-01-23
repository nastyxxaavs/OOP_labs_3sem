using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class XmpProfileBuilder
{
    private XmpProfile _xmpProfile;

    public XmpProfileBuilder(XmpProfile xmpProfile)
    {
        _xmpProfile = xmpProfile;
    }

    public XmpProfileBuilder BuildName(string name)
    {
        _xmpProfile.Name = name;
        return this;
    }

    public XmpProfileBuilder BuildTimings(string timings)
    {
        _xmpProfile.Timings = timings;
        return this;
    }

    public XmpProfileBuilder BuildVoltage(double voltage)
    {
        _xmpProfile.Voltage = voltage;
        return this;
    }

    public XmpProfileBuilder BuildFrequency(double frequency)
    {
        _xmpProfile.Frequency = frequency;
        return this;
    }

    public void AddXmpToRepository(Repository repository)
    {
        if (repository is not null && repository.XmpProfiles is not null)
        {
            if (!repository.XmpProfiles.Contains(_xmpProfile))
            {
                repository.XmpProfiles.Add(_xmpProfile);
            }
        }
    }

    public XmpProfile? Build()
    {
        XmpProfile xmpProfile = _xmpProfile;
        bool result = CorrectAttributes.CorrectBuildingOfXmp(xmpProfile);
        if (result)
        {
            return xmpProfile;
        }

        return null;
    }
}
