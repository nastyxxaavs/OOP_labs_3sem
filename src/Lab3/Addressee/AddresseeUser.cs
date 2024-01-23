using Itmo.ObjectOrientedProgramming.Lab3.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeUser : IAddressee
{
    private User.User _user;

    public AddresseeUser(User.User user)
    {
        _user = user;
    }

    public void SendMessage(Message.Message? message)
    {
        if (message is null) return;
        var info = new InformationAboutMessage() { Message = message, };
        _user.Info.Add(info);
    }
}
