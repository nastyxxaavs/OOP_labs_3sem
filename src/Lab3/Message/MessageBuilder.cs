namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class MessageBuilder
{
    private Message? _message;

    public MessageBuilder(Message message)
    {
        _message = message;
    }

    public MessageBuilder BuildTitle(string title)
    {
        if (_message is not null)
        {
            _message.Title = title;
        }

        return this;
    }

    public MessageBuilder BuildBody(string body)
    {
        if (_message is not null)
        {
            _message.Body = body;
        }

        return this;
    }

    public MessageBuilder BuildImportanceLevel(int level)
    {
        if (_message is not null)
        {
            _message.ImportanceLevel = level;
        }

        return this;
    }

    public Message? Build()
    {
        Message? message = _message;
        if (message is not null)
        {
            return message;
        }

        return null;
    }
}
