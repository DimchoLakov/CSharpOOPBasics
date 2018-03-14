using System;
using System.Collections.Generic;
using System.Linq;

public class Mine
{
    private DraftManager draftManager;

    public Mine(DraftManager draftManager)
    {
        this.draftManager = draftManager;
    }

    public void StartMining()
    {
        string input = Console.ReadLine();

        string result = string.Empty;

        while (!input.Equals("Shutdown"))
        {
            List<string> arguments = input
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Skip(1)
                                    .ToList();

            string command = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .First();

            switch (command)
            {
                case "RegisterHarvester":
                    result = draftManager.RegisterHarvester(arguments);
                    break;
                case "RegisterProvider":
                    result = draftManager.RegisterProvider(arguments);
                    break;
                case "Day":
                    result = draftManager.Day();
                    break;
                case "Mode":
                    result = draftManager.Mode(arguments);
                    break;
                case "Check":
                    result = draftManager.Check(arguments);
                    break;
                default:
                    throw new ArgumentException();
            }

            Console.WriteLine(result);

            input = Console.ReadLine();
        }

        result = draftManager.ShutDown();
        Console.WriteLine(result);
    }
}