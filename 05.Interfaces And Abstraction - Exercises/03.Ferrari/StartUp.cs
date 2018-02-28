using System;
public class StartUp
{
    public static void Main()
    {
        string driverName = Console.ReadLine();
        Ferrari ferrari = new Ferrari(driverName);
        Console.WriteLine(ferrari);
    }
}