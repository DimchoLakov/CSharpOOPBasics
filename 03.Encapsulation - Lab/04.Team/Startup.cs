using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        Team myTeam = new Team("SoftUni");

        for (int i = 0; i < lines; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
            myTeam.AddPlayer(person);
        }

        Console.WriteLine(myTeam);
    }
}