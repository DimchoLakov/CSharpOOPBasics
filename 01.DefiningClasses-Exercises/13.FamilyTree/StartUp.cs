using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Person> children = new List<Person>();
        List<Person> parents = new List<Person>();

        List<Person> allPeople = new List<Person>();

        List<string[]> tokenList = new List<string[]>();

        string input = Console.ReadLine();
        DateTime personDOB;

        if (IsDate(input, out personDOB))
        {
            
        }

        string inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            string[] tokens = inputLine.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 1)
            {
                string[] nameDateArr = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                DateTime date = DateTime.ParseExact(nameDateArr[nameDateArr.Length - 1], "d/M/yyyy",
                    CultureInfo.InvariantCulture);
                string name = string.Join(" ", nameDateArr.Take(nameDateArr.Length - 1));
                allPeople.Add(new Person(name, date));
            }
            else
            {
                tokenList.Add(tokens);
            }

            inputLine = Console.ReadLine();
        }

        Person mainPerson = allPeople.First(p => p.Name == input || p.DateOfBirth == personDOB);
        allPeople.Remove(mainPerson);

        foreach (string[] t in tokenList)
        {
            string firstName = t[0];
            string secondName = t[1];

            DateTime firstDate;
            DateTime secondDate;

            if (IsDate(t[0], out firstDate) && IsDate(t[1], out secondDate))
            {
                Person parent = allPeople.FirstOrDefault(p => p.DateOfBirth == firstDate);
                Person child = allPeople.FirstOrDefault(p => p.DateOfBirth == secondDate);
                if (parent != null && secondDate == mainPerson.DateOfBirth)
                {
                    parents.Add(parent);
                }
                else if (child != null && firstDate == mainPerson.DateOfBirth)
                {
                    children.Add(child);
                }
            }
            else if (!IsDate(t[0], out firstDate) && IsDate(t[1], out secondDate))
            {
                Person parent = allPeople.FirstOrDefault(p => p.Name == firstName);
                Person child = allPeople.FirstOrDefault(p => p.DateOfBirth == secondDate);
                if (parent != null && secondDate == mainPerson.DateOfBirth)
                {
                    parents.Add(parent);
                }
                else if (child != null && mainPerson.Name == firstName)
                {
                    children.Add(child);
                }
            }
            else if (IsDate(t[0], out firstDate) && !IsDate(t[1], out secondDate))
            {
                Person parent = allPeople.FirstOrDefault(p => p.DateOfBirth == firstDate);
                Person child = allPeople.FirstOrDefault(p => p.Name == secondName);
                if (parent != null && secondName == mainPerson.Name)
                {
                    parents.Add(parent);
                }
                else if (child != null && firstDate == mainPerson.DateOfBirth)
                {
                    children.Add(child);
                }
            }
            else if (!IsDate(t[0], out firstDate) && !IsDate(t[1], out secondDate))
            {
                Person parent = allPeople.FirstOrDefault(p => p.Name == firstName);
                Person child = allPeople.FirstOrDefault(p => p.Name == secondName);
                if (parent != null && mainPerson.Name == secondName)
                {
                    parents.Add(parent);
                }
                else if (child != null && mainPerson.Name == firstName)
                {
                    children.Add(child);
                }
            }
        }

        Console.WriteLine(mainPerson.ToString());
        Console.WriteLine("Parents:");
        if (parents.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, parents));
        }
        Console.WriteLine("Children:");
        if (children.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, children));
        }
    }

    private static bool IsDate(string str, out DateTime date)
    {
        return DateTime.TryParseExact
                                 (str, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }
}