using System;
namespace Itmo.ObjectOrientedProgramming.Lab3.Messanger;

public class Messanger
{
    public Message.Message? Message { get; set; }
    public int Counter { get; set; }
    public void PrintMessage(Message.Message? message)
    {
        if (message is not null)
        {
            Message = message;
            Console.WriteLine(Message.Title);
            Console.WriteLine(Message.Body);
            Counter += 1;
        }
    }
}
