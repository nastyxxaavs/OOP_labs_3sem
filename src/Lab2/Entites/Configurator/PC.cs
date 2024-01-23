namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class PC
{
    public MotherBoard.MotherBoard? Motherboard { get; set; }
    public Cpu? CPU { get; set; }
    public Bios? Bios { get; set; }
    public CoolingSystem? CoolingSystem { get; set; }
    public Ram? RAM { get; set; }
    public XmpProfile? XMP { get; set; }
    public VideoCard? VideoCard { get; set; }
    public SsdDrive? SSD { get; set; }
    public Hdd? HDD { get; set; }
    public Frame? Frame { get; set; }
    public PowerUnit? PowerUnit { get; set; }
    public Wifi? WIFI { get; set; }
}
