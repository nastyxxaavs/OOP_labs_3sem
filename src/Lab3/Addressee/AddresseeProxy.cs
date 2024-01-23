using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeProxy : IAddressee
{
    private IAddressee _addressee;

    public AddresseeProxy(IAddressee addressee)
    {
        _addressee = addressee;
        Counter = 0;
    }

    public int Counter { get; set; }
    public int UserLevel { get; set; }
    public Message.Message? Message { get; set; }
    public void Logic(Message.Message? message)
    {
        if (message is not null)
        {
            Message = message;
            Console.WriteLine("Message to user:");
            Console.WriteLine(Message.Title);
            Console.WriteLine(Message.Body);
            Counter += 1;
        }
    }

    public bool Filter(Message.Message? message, int userLevel)
    {
        if (message is null) return false;
        UserLevel = userLevel;
        Message = message;
        if (UserLevel > Message.ImportanceLevel)
        {
            return true;
        }

        return false;
    }

    public void SendMessage(Message.Message? message)
    {
        if (message is not null)
        {
            Message = message;
            _addressee.SendMessage(Message);
        }
    }

    public void SendMessage(Message.Message? message, int userLevel)
    {
        if (message is not null && Filter(message, userLevel))
        {
            Message = message;
            _addressee.SendMessage(Message);
        }
    }
}
