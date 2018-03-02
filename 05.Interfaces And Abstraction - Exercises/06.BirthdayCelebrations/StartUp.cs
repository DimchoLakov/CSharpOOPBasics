using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<IBirthable> list = new List<IBirthable>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            AddCitizenAndPetsToList(list, tokens);

            input = Console.ReadLine();
        }

        string year = Console.ReadLine();
        List<IBirthable> filteredList = list
            .Where(c => c.Birthday.ToString("yyyy") == year)
            .ToList();

        filteredList.ForEach(p => Console.WriteLine(p.Birthday.ToString("dd/MM/yyyy")));
    }

    private static void AddCitizenAndPetsToList(List<IBirthable> list, string[] tokens)
    {
        string type = tokens[0];

        if (type.Equals("Citizen"))
        {
            DateTime citizenBirthday = DateTime
                .ParseExact(tokens[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], citizenBirthday);
            list.Add(citizen);
        }
        else if (type.Equals("Pet"))
        {
            DateTime petBirthday = DateTime
                .ParseExact(tokens[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Pet pet = new Pet(tokens[1], petBirthday);
            list.Add(pet);
        }
    }
}