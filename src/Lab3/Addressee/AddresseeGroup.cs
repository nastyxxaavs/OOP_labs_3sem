using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeGroup : IAddressee
{
    private IList<IAddressee> _addressee = new List<IAddressee>();

    public void SendMessage(Message.Message? message)
    {
        if (message is not null)
        {
            foreach (IAddressee addressee in _addressee)
            {
                addressee.SendMessage(message);
            }
        }
    }
}
