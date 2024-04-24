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
}
