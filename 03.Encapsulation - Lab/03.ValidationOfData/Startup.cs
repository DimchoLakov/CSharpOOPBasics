using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' });

            try
            {
                Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
                people.Add(person);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        decimal percentage = decimal.Parse(Console.ReadLine());

        people.ForEach(p => p.IncreaseSalary(percentage));
        people.ForEach(Console.WriteLine);
    }
}