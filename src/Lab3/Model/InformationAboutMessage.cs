namespace Itmo.ObjectOrientedProgramming.Lab3.Model;

public record InformationAboutMessage
{
    public Message.Message? Message { get; set; }
    public bool HaveRead { get; set; } // по умолчанию false
}
