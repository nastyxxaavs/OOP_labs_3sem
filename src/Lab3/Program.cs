using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3;
public static class Program
{
    public static void Main()
    {
        var firstUser = new User.User();
        var userAddressee = new AddresseeUser(firstUser);
        var messageBuilder = new MessageBuilder(new Message.Message());
        Message.Message? firstMessage = messageBuilder.BuildTitle("Attention! Cancellation of the day off!")
            .BuildBody(
                "Dear colleagues, unfortunately you will have to come to the office on Saturday, detailed information will be sent later!")
            .BuildImportanceLevel(7).Build();
        var proxy = new AddresseeProxy(userAddressee);
        var topic = new Topic.Topic("Force Majeure!", proxy);
        topic.SetMessage(firstMessage);
        proxy.Logic(firstMessage);
        Console.WriteLine(proxy.Counter);
        var firstMessanger = new Messanger.Messanger();
        var messangerAddressee = new AddresseeMessanger(firstMessanger);
        var messageBuilder2 = new MessageBuilder(new Message.Message());
        Message.Message? secondMessage = messageBuilder2.BuildTitle("Emergency survey!")
            .BuildBody(
                "Dear colleagues, please take the survey, detailed information will be sent later!")
            .BuildImportanceLevel(7).Build();
        var proxy2 = new AddresseeProxy(messangerAddressee);
        var topic2 = new Topic.Topic("Force Majeure!", proxy2);
        topic2.SetMessage(secondMessage);
        firstMessanger.PrintMessage(secondMessage);
        var firstDisplay = new Display.Display();
        var displayAddressee = new AddresseeDisplay(firstDisplay);
        var messageBuilder3 = new MessageBuilder(new Message.Message());
        Message.Message? thirdMessage = messageBuilder3.BuildTitle("Emergency survey!")
            .BuildBody(
                "Dear colleagues, please take the survey, detailed information will be sent later!")
            .BuildImportanceLevel(7).Build();
        var proxy3 = new AddresseeProxy(displayAddressee);
        var topic3 = new Topic.Topic("Force Majeure!", proxy3);
        topic3.SetMessage(thirdMessage);
        var driver = new DisplayDriver(firstDisplay);
        driver.Color = ConsoleColor.Magenta;
        driver.PrintMessage(thirdMessage);
    }
}
