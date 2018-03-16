using System;
using System.Collections.Generic;
using System.Linq;

public class Fight
{
    private NationsBuilder nationsBuilder;

    public Fight(NationsBuilder nationsBuilder)
    {
        this.nationsBuilder = nationsBuilder;
    }

    public void Begin()
    {
        string input = Console.ReadLine();

        while (input != "Quit")
        {
            List<string> tokens = input
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = tokens[0];

            List<string> avatarArgs = tokens.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(avatarArgs);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(avatarArgs);
                    break;
                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(avatarArgs[0]));
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(avatarArgs[0]);
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(this.nationsBuilder.GetWarsRecord());
    }
}
