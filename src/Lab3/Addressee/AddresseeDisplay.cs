namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDisplay : IAddressee
{
    private Display.Display _display;

    public AddresseeDisplay(Display.Display display)
    {
        _display = display;
    }

    public void SendMessage(Message.Message? message)
    {
        if (message is null) return;
        _display.Message = message;
    }

    /*public IEnumerable<Message.Message>? GetMessage(Message.Message? message)
    {
        IList<Message.Message> messages = new List<Message.Message>();
        if (message is not null)
        {
            messages.Add(message);
        }

        return messages;
    }*/
}
