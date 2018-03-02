using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<IBuyer> buyers = new List<IBuyer>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            AddCitizensAndRebelsToList(buyers, tokens);
        }

        string inputName = Console.ReadLine();

        while (inputName != "End")
        {
            IBuyer buyer = buyers.FirstOrDefault(b => b.Name == inputName);
            if (buyer != null)
            {
                buyer.BuyFood();
            }

            inputName = Console.ReadLine();
        }

        Console.WriteLine(buyers.Sum(f => f.Food));
    }

    private static void AddCitizensAndRebelsToList(List<IBuyer> buyers, string[] tokens)
    {
        if (tokens.Length == 4)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string id = tokens[2];
            DateTime birthday = DateTime.ParseExact(tokens[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Citizen citizen = new Citizen(name, age, id, birthday);

            buyers.Add(citizen);
        }
        else if (tokens.Length == 3)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string group = tokens[2];

            Rebel rebel = new Rebel(name, age, group);

            buyers.Add(rebel);
        }
    }
}