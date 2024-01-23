using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IDisplay
{
    public Message.Message? Message { get; set; }
    public void PrintMessage(Message.Message? message)
    {
        if (Message is null) return;
        Console.WriteLine(Message.Title);
        Console.WriteLine(Message.Body);
    }
}
