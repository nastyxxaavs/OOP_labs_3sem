namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class VideoCard
{
    public DimensionsOfVideoCard? Dimensions { get; set; }
    public int Storage { get; set; }
    public string? PciVersion { get; set; }
    public double ChipFrequency { get; set; }
    public double SpendedPower { get; set; }
}
