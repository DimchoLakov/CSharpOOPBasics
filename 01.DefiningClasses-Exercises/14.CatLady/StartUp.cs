using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Cat> catList = new List<Cat>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string breed = tokens[0];
            string name = tokens[1];
            switch (breed)
            {
                case "Siamese":
                    Siamese siamCat = new Siamese(name, breed, int.Parse(tokens[2]));
                    catList.Add(siamCat);
                    break;
                case "Cymric":
                    Cymric cymCat = new Cymric(name, breed, double.Parse(tokens[2]));
                    catList.Add(cymCat);
                    break;
                case "StreetExtraordinaire":
                    StreetExtraordinaire streetCat = new StreetExtraordinaire(name, breed, int.Parse(tokens[2]));
                    catList.Add(streetCat);
                    break;
            }

            input = Console.ReadLine();
        }

        string catToPrint = Console.ReadLine();

        Cat cat = catList.FirstOrDefault(c => c.Name == catToPrint);
        Console.WriteLine(cat);
    }
}