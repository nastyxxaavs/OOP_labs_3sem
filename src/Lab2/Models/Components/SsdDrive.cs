namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class SsdDrive
{
    public string? AddVarious { get; set; } // Вариант подключения (PCI-E / Sata)
    public double Capacity { get; set; }
    public double MaxSpeedOpportunity { get; set; }
    public double SpendedPower { get; set; }
}
