using System;

public class StartUp
{
    public static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        IPerson citizen = new Citizen(name, age);
        Console.WriteLine(citizen.ToString());
    }
}