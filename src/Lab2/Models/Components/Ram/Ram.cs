using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class Ram
{
    public double SizeOpportunity { get; set; }
    public IEnumerable<double>? CorrectJedec { get; set; }
    public XmpProfile? XmpProfiles { get; set; }
    public DimensionsOfRam? FormFactor { get; set; }
    public string? DdrVersion { get; set; }
    public double SpendedPower { get; set; }
}
