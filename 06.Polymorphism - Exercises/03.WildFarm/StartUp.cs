using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] animalTokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] foodTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var animal = AnimalFactory.GetAnimal(animalTokens);
            var food = FoodFactory.GetFood(foodTokens);

            Console.WriteLine(animal.ProduceSound());
            try
            {
                animal.Eat(food);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            animals.Add(animal);

            input = Console.ReadLine();
        }

        animals.ForEach(Console.WriteLine);
    }
}