using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entites.ComponentsBuilders;

public class VideoCardBuilder
{
    private VideoCard _videoCard;

    public VideoCardBuilder(VideoCard videoCard)
    {
        _videoCard = videoCard;
    }

    public VideoCardBuilder BuildCard(DimensionsOfVideoCard dimensionsOfVideoCard)
    {
        _videoCard.Dimensions = dimensionsOfVideoCard;
        return this;
    }

    public VideoCardBuilder BuildStorage(int storage)
    {
        _videoCard.Storage = storage;
        return this;
    }

    public VideoCardBuilder BuildPciVersion(string version)
    {
        _videoCard.PciVersion = version;
        return this;
    }

    public VideoCardBuilder BuildChipFrequency(double frequency)
    {
        _videoCard.ChipFrequency = frequency;
        return this;
    }

    public VideoCardBuilder BuildSpendedPower(double spendedPower)
    {
        _videoCard.SpendedPower = spendedPower;
        return this;
    }

    public void AddVideoCardToRepository(Repository repository)
    {
        if (repository is not null && repository.VideoCards is not null)
        {
            if (!repository.VideoCards.Contains(_videoCard))
            {
                repository.VideoCards.Add(_videoCard);
            }
        }
    }

    public VideoCard? Build()
    {
        VideoCard videoCard = _videoCard;
        bool result = CorrectAttributes.CorrectBuildingOfVideoCard(videoCard);
        if (result)
        {
            return videoCard;
        }

        return null;
    }
}
