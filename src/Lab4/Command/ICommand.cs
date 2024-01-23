namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public interface ICommand
{
    void Execute();
    void Undo();
}
