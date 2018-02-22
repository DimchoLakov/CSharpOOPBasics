using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] tokens = input
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];

            switch (command)
            {
                case "Team":
                    AddTeam(teams, tokens);
                    break;
                case "Add":
                    AddPlayerToTeam(teams, tokens);
                    break;
                case "Remove":
                    RemovePlayerFromTeam(teams, tokens);
                    break;
                case "Rating":
                    RateTeam(teams, tokens);
                    break;
            }

            input = Console.ReadLine();
        }
    }

    private static void RateTeam(List<Team> teams, string[] tokens)
    {
        Team t = teams.FirstOrDefault(p => p.Name == tokens[1]);
        if (t == null)
        {
            Console.WriteLine($"Team {tokens[1]} does not exist.");
        }
        else
        {
            Console.WriteLine($"{t.Name} - {t.Rating}");
        }
    }

    private static void RemovePlayerFromTeam(List<Team> teams, string[] tokens)
    {
        try
        {
            Team teamToRemoveFrom = teams.First(p => p.Name == tokens[1]);
            teamToRemoveFrom.RemovePlayer(tokens[2]);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void AddTeam(List<Team> teams, string[] tokens)
    {
        try
        {
            string teamName = tokens[1];
            teams.Add(new Team(teamName));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void AddPlayerToTeam(List<Team> teams, string[] tokens)
    {
        Team teamToAddTo = teams.FirstOrDefault(p => p.Name == tokens[1]);
        if (teamToAddTo == null)
        {
            Console.WriteLine($"Team {tokens[1]} does not exist.");
        }
        else
        {
            try
            {
                string playerName = tokens[2];
                int endurance = int.Parse(tokens[3]);
                int sprint = int.Parse(tokens[4]);
                int dribble = int.Parse(tokens[5]);
                int passing = int.Parse(tokens[6]);
                int shooting = int.Parse(tokens[7]);
                Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                teamToAddTo.AddPlayer(newPlayer);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
