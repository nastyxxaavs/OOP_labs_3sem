using System;
using Itmo.ObjectOrientedProgramming.Lab4.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Invokers;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            int depth;
            string? request = Console.ReadLine();
            IHandler result = new CommandChain();
            var model = new ModelOfCommand();
            result.AddNext(new AttributesChain())?.AddNext(new FlagChain());
            result.Handle(request, model);
            if (result.CorrectState && request is not null && model.Flags is not null && model.Attributes is not null)
            {
                switch (model.Name)
                {
                    case "connect":
                        IConnectionServices receiver = new ConnectService();
                        foreach (string path in model.Attributes)
                        {
                            ICommand command = new ConnectCommand(receiver, path, model.Flags);
                            var invokerOne = new Invoker(Context.State, command);
                            invokerOne.SetCommand(command);
                            invokerOne.Action(request);
                            command.Execute();
                        }

                        break;
                    case "disconnect":
                        IConnectionServices receiverTwo = new ConnectService();
                        foreach (string path in model.Attributes)
                        {
                            ICommand commandTwo = new ConnectCommand(receiverTwo, path, model.Flags);
                            var invokerTwo = new Invoker(Context.State, commandTwo);
                            invokerTwo.SetCommand(commandTwo);
                            invokerTwo.Action(request);
                            commandTwo.Undo();
                        }

                        break;
                    case "tree goto":
                        ILocalServices firstReceiver = new LocalServices();
                        foreach (string path in model.Attributes)
                        {
                            firstReceiver.GotoTisPath(path);
                            ICommand firstCommand = new GoToCommand(firstReceiver, path);
                            var firstInvoker = new Invoker(Context.State, firstCommand);
                            firstInvoker.SetCommand(firstCommand);
                            firstInvoker.Action(request);
                            firstCommand.Execute();
                            firstReceiver.GotoTisPath(path);
                        }

                        break;
                    case "tree list":
                        depth = Console.Read();
                        ILocalServices secondReceiver = new LocalServices();
                        foreach (string path in model.Attributes)
                        {
                            secondReceiver.TreeList(depth, " ", path);
                            ICommand secondCommand = new TreeListCommand(secondReceiver, path, model.Flags, " ", depth);
                            var secondInvoker = new Invoker(Context.State, secondCommand);
                            secondInvoker.SetCommand(secondCommand);
                            secondInvoker.Action(request);
                            secondCommand.Execute();
                            secondReceiver.TreeList(depth, " ", path);
                        }

                        break;
                    case "file show":
                        ILocalServices thirdReceiver = new LocalServices();
                        foreach (string path in model.Attributes)
                        {
                            thirdReceiver.Show(path, model.Flags);
                            ICommand thirdCommand = new ShowCommand(thirdReceiver, path, model.Flags);
                            var thirdInvoker = new Invoker(Context.State, thirdCommand);
                            thirdInvoker.SetCommand(thirdCommand);
                            thirdInvoker.Action(request);
                            thirdCommand.Execute();
                            thirdReceiver.Show(path, model.Flags);
                        }

                        break;
                    case "file move":
                        ILocalServices receiver4 = new LocalServices();
                        foreach (string path in model.Attributes)
                        {
                            foreach (string path2 in model.Attributes)
                            {
                                if (path != path2)
                                {
                                    receiver4.MoveToAnotherCatalog(path, path2);
                                    ICommand command4 = new MoveToAnotherCatalog(receiver4, path, path2);
                                    var invoker4 = new Invoker(Context.State, command4);
                                    invoker4.SetCommand(command4);
                                    invoker4.Action(request);
                                    command4.Execute();
                                    receiver4.MoveToAnotherCatalog(path, path2);
                                }
                            }
                        }

                        break;
                    case "file delete":
                        ILocalServices receiver5 = new LocalServices();
                        foreach (string path in model.Attributes)
                        {
                            ICommand command5 = new RemoveCommand(receiver5, path);
                            var invoker5 = new Invoker(Context.State, command5);
                            invoker5.SetCommand(command5);
                            invoker5.Action(request);
                            command5.Execute();
                            receiver5.Remove(path);
                        }

                        break;
                    case "file rename":
                        ILocalServices receiver6 = new LocalServices();
                        foreach (string path in model.Attributes)
                        {
                            foreach (string name in model.Attributes)
                            {
                                receiver6.Rename(path, name);
                                ICommand command6 = new RenameCommand(receiver6, path, name);
                                var invoker6 = new Invoker(Context.State, command6);
                                invoker6.SetCommand(command6);
                                invoker6.Action(request);
                                command6.Execute();
                                receiver6.Rename(path, name);
                            }
                        }

                        break;
                    case "file copy":
                        ILocalServices receiver7 = new LocalServices();
              
                        foreach (string path in model.Attributes)
                        {
                            foreach (string path2 in model.Attributes)
                            {
                                if (path != path2)
                                {
                                    receiver7.Copy(path, path2);
                                    ICommand command7 = new CopyCommand(receiver7, path, path2);
                                    var invoker7 = new Invoker(Context.State, command7);
                                    invoker7.SetCommand(command7);
                                    invoker7.Action(request);
                                    command7.Execute();
                                    receiver7.Copy(path, path2);
                                }
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Undefined command");
                        break;
                }
            }
            }
    }
}
