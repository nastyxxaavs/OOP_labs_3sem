using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites;

public class Repository
{
    public ICollection<MotherBoard.MotherBoard>? MotherBoards { get; } = new List<MotherBoard.MotherBoard>();
    public ICollection<Cpu>? CPUs { get; } = new List<Cpu>();
    public ICollection<Ram>? RAMs { get; } = new List<Ram>();
    public ICollection<Frame>? Frames { get; } = new List<Frame>();
    public ICollection<CoolingSystem>? CoolingSystems { get; } = new List<CoolingSystem>();
    public ICollection<PowerUnit>? PowerUnits { get; } = new List<PowerUnit>();
    public ICollection<Bios>? Bioses { get; } = new List<Bios>();
    public ICollection<XmpProfile>? XmpProfiles { get; } = new List<XmpProfile>();
    public ICollection<VideoCard>? VideoCards { get; } = new List<VideoCard>();
    public ICollection<SsdDrive>? SsdDrives { get; } = new List<SsdDrive>();
    public ICollection<Hdd>? Hdds { get; } = new List<Hdd>();
    public ICollection<Wifi>? WifiAdapters { get; } = new List<Wifi>();
}
