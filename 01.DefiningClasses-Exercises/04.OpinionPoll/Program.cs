using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            people.Add(new Person(name, age));
        }

        people.Where(a => a.Age > 30).OrderBy(na => na.Name).ToList().ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
    }
}