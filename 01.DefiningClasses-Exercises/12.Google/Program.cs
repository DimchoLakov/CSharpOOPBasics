using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();

        string input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];

            if (!people.ContainsKey(name))
            {
                Person person = new Person(name);

                people.Add(name, person);
            }

            string classType = tokens[1];

            List<string> tokensToTake = tokens.Skip(2).Take(tokens.Length).ToList();

            switch (classType)
            {
                case "company":
                    AddCompanyDetails(people[name], tokensToTake);
                    break;
                case "car":
                    AddCarDetails(people[name], tokensToTake);
                    break;
                case "pokemon":
                    AddPokemonDetails(people[name], tokensToTake);
                    break;
                case "children":
                    AddChildrenDetails(people[name], tokensToTake);
                    break;
                case "parents":
                    AddParentsDetails(people[name], tokensToTake);
                    break;
            }

            input = Console.ReadLine();
        }

        string personToPrint = Console.ReadLine();

        Console.WriteLine(people[personToPrint]);
    }

    private static void AddParentsDetails(Person person, List<string> tokensToTake)
    {
        string name = tokensToTake[0];
        string dateOfBirth = tokensToTake[1];
        Parent parent = new Parent(name, dateOfBirth);
        person.Parents.Add(parent);
    }

    private static void AddChildrenDetails(Person person, List<string> tokensToTake)
    {
        string name = tokensToTake[0];
        string dateOfBirth = tokensToTake[1];
        Child child = new Child(name, dateOfBirth);
        person.Children.Add(child);
    }

    private static void AddPokemonDetails(Person person, List<string> tokensToTake)
    {
        string name = tokensToTake[0];
        string type = tokensToTake[1];
        Pokemon pokemon = new Pokemon(name, type);
        person.Pokemons.Add(pokemon);
    }

    private static void AddCarDetails(Person person, List<string> tokensToTake)
    {
        string model = tokensToTake[0];
        int speed = int.Parse(tokensToTake[1]);
        Car car = new Car(model, speed);
        person.Car = car;
    }

    private static void AddCompanyDetails(Person person, List<string> tokensToTake)
    {
        decimal salary = decimal.Parse(tokensToTake[tokensToTake.Count - 1]);
        string companyName = tokensToTake[0];
        string department = tokensToTake[1];
        Company company = new Company(companyName, department, salary);
        person.Company = company;
    }
}