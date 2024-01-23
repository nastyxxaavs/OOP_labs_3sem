namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic
{
    public Topic(string name, Addressee.IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string? Name { get; set; }
    public Addressee.IAddressee? Addressee { get; set; }

    public void SetMessage(Message.Message? message)
    {
        Message.Message? newMessage = message;
        if (newMessage is not null && Addressee is not null)
        {
            Addressee.SendMessage(message);
        }
    }
}
