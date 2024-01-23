namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeMessanger : IAddressee
{
    private Messanger.Messanger _messanger;

    public AddresseeMessanger(Messanger.Messanger messanger)
    {
        _messanger = messanger;
    }

    public void SendMessage(Message.Message? message)
    {
        if (message is null) return;
        _messanger.Message = message;
    }
}
