using System;

class Startup
{
    static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box;
        try
        {
            box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurface():f2}");
            Console.WriteLine($"Volume - {box.CalculateVolume():f2}");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}