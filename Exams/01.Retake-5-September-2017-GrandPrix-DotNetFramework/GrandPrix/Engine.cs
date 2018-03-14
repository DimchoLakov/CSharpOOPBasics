using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Start()
    {
        int trackLength = int.Parse(Console.ReadLine());
        int totalLaps = int.Parse(Console.ReadLine());

        this.raceTower.SetTrackInfo(trackLength, totalLaps);
        
        while (this.raceTower.HasRaceFinished == false)
        {
            string input = Console.ReadLine();

            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> arguments = tokens.Skip(1).ToList();

            string command = tokens[0];

            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(arguments);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string output = this.raceTower.CompleteLaps(arguments);
                    if (output != string.Empty)
                    {
                        Console.WriteLine(output);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(arguments);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(arguments);
                    break;
            }
        }
    }
}
