using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.MotherBoard;

public class MotherBoard
{
    public string? Socket { get; set; }
    public int CountPCI { get; set; }
    public int CountSATA { get; set; }
    public IEnumerable<double>? Chipset { get; set; } // correct jedec
    public string? Ddr { get; set; }
    public bool Xmp { get; set; }
    public int RAMsticks { get; set; } // Кол-во слотов под ОЗУ
    public DimensionsOfMotherBoard? FormFactor { get; set; }
    public string? Bios { get; set; }
    public bool HaveWifi { get; set; }
}
