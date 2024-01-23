using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayDriver : IDisplay
{
    private IDisplay? _display;

    public DisplayDriver(IDisplay display)
    {
        _display = display;
    }

    public ConsoleColor? Color { get; set; }

    public Message.Message? Message { get; set; }

    public static void ClearMessage()
    {
        Console.Clear();
    }

    public ConsoleColor SetColor()
    {
        ConsoleColor color = ConsoleColor.White;
        if (Color is not null)
        {
            if (Color == ConsoleColor.Green) color = ConsoleColor.Green;
            if (Color == ConsoleColor.Magenta) color = ConsoleColor.Magenta;
            if (Color == ConsoleColor.Magenta) color = ConsoleColor.Red;
            if (Color == ConsoleColor.Black) color = ConsoleColor.Black;
            if (Color == ConsoleColor.Blue) color = ConsoleColor.Blue;
        }

        return color;
    }

    public void PrintMessage(Message.Message? message)
    {
        if (_display is null) return;
        ClearMessage();
        Write();
        _display.PrintMessage(message);
    }

    public void Write()
    {
        if (Message is null) return;
        Console.ForegroundColor = SetColor();
        Console.WriteLine(Message.Title);
        Console.WriteLine(Message.Body);
        Console.ResetColor();
    }
}
