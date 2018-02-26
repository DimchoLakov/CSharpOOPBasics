using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

public class StartUp
{
    public static void Main()
    {
        string[] foodsInput = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<Food> foods = new List<Food>();

        foreach (string foodInput in foodsInput)
        {
            Food food = FoodFactory.GetFood(foodInput);
            foods.Add(food);
        }

        int happinessValue = foods.Sum(f => f.FoodHappiness);
        Console.WriteLine(happinessValue);

        Mood mood = MoodFactory.GetMood(happinessValue);
        Console.WriteLine(mood.MoodType);
    }
}