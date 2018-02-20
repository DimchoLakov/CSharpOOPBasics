using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]));

            people.Add(person);
        }

        people.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}