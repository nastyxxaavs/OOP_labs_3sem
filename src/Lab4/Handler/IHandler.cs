namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;

public interface IHandler
{
    public bool CorrectState { get; set; }
    IHandler? AddNext(IHandler link);

    void Handle(string? request, ModelOfCommand? modelOfCommand);
}
