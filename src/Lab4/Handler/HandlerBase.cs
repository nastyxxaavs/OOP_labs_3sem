namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;

public abstract class HandlerBase : IHandler
{
    public bool CorrectState { get; set; }
    protected IHandler? Next { get; set; }

    public IHandler? AddNext(IHandler link)
    {
        Next = link;
        return Next;
    }

    public abstract void Handle(string? request, ModelOfCommand? modelOfCommand);
}
