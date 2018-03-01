using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<IIdentifyable> rebelions = new List<IIdentifyable>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 2)
            {
                string model = tokens[0];
                string id = tokens[1];

                Robot robot = new Robot(model, id);
                rebelions.Add(robot);
            }
            else if (tokens.Length == 3)
            {
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string id = tokens[2];

                Citizen citizen = new Citizen(name, age, id);
                rebelions.Add(citizen);
            }

            input = Console.ReadLine();
        }

        string lastDigitsOfFakeId = Console.ReadLine();

        List<string> citizensFakeIds = rebelions
            .Where(c => c.Id.EndsWith(lastDigitsOfFakeId))
            .Select(c => c.Id)
            .ToList();

        citizensFakeIds.ForEach(Console.WriteLine);
    }
}