using System;

class StartUp
{
    static void Main()
    {
        decimal finalPrice = PriceCalculator.CalculatePrice(Console.ReadLine());
        Console.WriteLine($"{finalPrice:f2}");
    }
}