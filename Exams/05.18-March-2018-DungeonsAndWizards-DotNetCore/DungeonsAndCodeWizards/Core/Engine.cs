using System;
using System.Linq;

public class Engine
{
    private DungeonMaster dungeonMaster;

    public Engine(DungeonMaster dungeonMaster)
    {
        this.dungeonMaster = dungeonMaster;
    }

    public void Run()
    {
        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            string[] tokens = input.Split(' ');
            string command = tokens[0];

            tokens = tokens.Skip(1).ToArray();

            string result = string.Empty;

            try
            {
                result = ReadAndExecuteCommand(tokens, command, result);
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
            catch (InvalidOperationException invalidOperation)
            {
                Console.WriteLine("Invalid Operation: " + invalidOperation.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("Parameter Error: " + argumentException.Message);
            }

            if (dungeonMaster.IsGameOver())
            {
                break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine("Final stats:");
        Console.WriteLine(dungeonMaster.GetStats());
    }

    private string ReadAndExecuteCommand(string[] tokens, string command, string result)
    {
        switch (command)
        {
            case "JoinParty":
                result = dungeonMaster.JoinParty(tokens);
                break;
            case "AddItemToPool":
                result = dungeonMaster.AddItemToPool(tokens);
                break;
            case "PickUpItem":
                result = dungeonMaster.PickUpItem(tokens);
                break;
            case "UseItem":
                result = dungeonMaster.UseItem(tokens);
                break;
            case "UseItemOn":
                result = dungeonMaster.UseItemOn(tokens);
                break;
            case "GiveCharacterItem":
                result = dungeonMaster.GiveCharacterItem(tokens);
                break;
            case "GetStats":
                result = dungeonMaster.GetStats();
                break;
            case "Attack":
                result = dungeonMaster.Attack(tokens);
                break;
            case "Heal":
                result = dungeonMaster.Heal(tokens);
                break;
            case "EndTurn":
                result = dungeonMaster.EndTurn(tokens);
                break;
        }
        return result;
    }
}