using System;

public class StartUp
{
    public static void Main()
    {
        int radius = int.Parse(Console.ReadLine());
        Circle circle = new Circle(radius);
        circle.Draw();

        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        Rectangle rectangle = new Rectangle(width, height);
        rectangle.Draw();
    }
}