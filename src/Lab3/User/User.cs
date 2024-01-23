using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public class User
{
    public IList<InformationAboutMessage> Info { get; } = new List<InformationAboutMessage>();

    public void WhatStatusOfMessage(Message.Message? message)
    {
        InformationAboutMessage information = Info.First(mes => mes.Message == message);
        if (information.HaveRead) throw new ArgumentException("The message has already been read!");
        information.HaveRead = true;
    }

    /*public void ChangeStatusOfMessage(AddresseeUser? addresseeUser)
    {
        ICollection<Condition> condition = WhatStatusOfMessage(addresseeUser);
        if (condition.Contains(Condition.NotReadYet))
        {
            condition.Clear();
            condition.Add(Condition.HaveRead);
        }

        try
        {
            if (condition.Contains(Condition.HaveRead))
            {
                throw new ArgumentException("The message has already been read!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return condition;
    }*/
}
