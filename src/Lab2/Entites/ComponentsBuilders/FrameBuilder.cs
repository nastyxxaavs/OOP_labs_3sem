using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class FrameBuilder
{
    private Frame _frame;

    public FrameBuilder(Frame frame)
    {
        _frame = frame;
    }

    public FrameBuilder BuildFrame(DimensionsOfFrame dimensionsOfFrame)
    {
        _frame.Dimensions = dimensionsOfFrame;
        return this;
    }

    public FrameBuilder BuildMotherBoard(DimensionsOfMotherBoard motherBoard)
    {
        _frame.CorrectMotherBoard = motherBoard;
        return this;
    }

    public FrameBuilder BuildVideoCard(VideoCardOpportunity videoCardOpportunity)
    {
        _frame.VideoCard = videoCardOpportunity;
        return this;
    }

    public void AddFrameToRepository(Repository repository)
    {
        if (repository is not null && repository.Frames is not null)
        {
            if (!repository.Frames.Contains(_frame))
            {
                repository.Frames.Add(_frame);
            }
        }
    }

    public Frame? Build()
    {
        Frame frame = _frame;
        bool result = CorrectAttributes.CorrectBuildingOfFrame(frame);
        if (result)
        {
            return frame;
        }

        return null;
    }
}
