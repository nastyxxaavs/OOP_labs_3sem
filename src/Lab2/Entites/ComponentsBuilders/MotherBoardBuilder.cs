using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entites;
using Itmo.ObjectOrientedProgramming.Lab2.Entites.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class MotherBoardBuilder
{
    private MotherBoard _motherBoard;
    public MotherBoardBuilder(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
    }

    public MotherBoardBuilder BuildSocket(string socket)
    {
        _motherBoard.Socket = socket;
        return this;
    }

    public MotherBoardBuilder BuildCountPCI(int countPci)
    {
        _motherBoard.CountPCI = countPci;
        return this;
    }

    public MotherBoardBuilder BuildCountSata(int countSata)
    {
        _motherBoard.CountSATA = countSata;
        return this;
    }

    public MotherBoardBuilder BuildDdr(string ddr)
    {
        _motherBoard.Ddr = ddr;
        return this;
    }

    public MotherBoardBuilder BuildXmp(bool xmp)
    {
        _motherBoard.Xmp = xmp;
        return this;
    }

    public MotherBoardBuilder BuildRamSticks(int ramSticks)
    {
        _motherBoard.RAMsticks = ramSticks;
        return this;
    }

    public MotherBoardBuilder BuildFormFactor(DimensionsOfMotherBoard dimensionsOfMotherBoard)
    {
        _motherBoard.FormFactor = dimensionsOfMotherBoard;
        return this;
    }

    public MotherBoardBuilder BuildBios(string bios)
    {
        _motherBoard.Bios = bios;
        return this;
    }

    public MotherBoardBuilder BuildWifi(bool wifi)
    {
        _motherBoard.HaveWifi = wifi;
        return this;
    }

    public MotherBoardBuilder BuildCorrectJedec(IList<double> chipset)
    {
        _motherBoard.Chipset = chipset;
        return this;
    }

    public void AddMotherBoardToRepository(Repository repository)
    {
        if (repository is not null && repository.MotherBoards is not null)
        {
            if (!repository.MotherBoards.Contains(_motherBoard))
            {
                repository.MotherBoards.Add(_motherBoard);
            }
        }
    }

    public MotherBoard? Build()
    {
        MotherBoard motherBoard = _motherBoard;
        bool result = CorrectAttributes.CorrectBuildingOfMotherBoard(motherBoard);
        if (result)
        {
            return motherBoard;
        }

        return null;
    }
}
