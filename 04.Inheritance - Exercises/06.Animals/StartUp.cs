using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string input = Console.ReadLine();

        while (input != "Beast!")
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                AddAnimal(animals, input, tokens);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            input = Console.ReadLine();
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
            animal.ProduceSound();
        }
    }

    private static void AddAnimal(List<Animal> animals, string input, string[] tokens)
    {
        if (tokens.Length < 3)
        {
            throw new ArgumentException("Invalid input!");
        }
        string animalType = input;

        string name = tokens[0];
        int age = int.Parse(tokens[1]);
        string gender = tokens[2];

        Animal animal;
        switch (animalType)
        {
            case "Cat":
                animal = new Cat(name, age, gender);
                break;
            case "Dog":
                animal = new Dog(name, age, gender);
                break;
            case "Frog":
                animal = new Frog(name, age, gender);
                break;
            case "Kitten":
                animal = new Kitten(name, age);
                break;
            case "Tomcat":
                animal = new Tomcat(name, age);
                break;
            default:
                throw new ArgumentException("Invalid input!");
                break;
        }
        animals.Add(animal);
    }
}