using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Rectangle(3.5, 4.3),
            new Rectangle(2.5, 7.6),
            new Rectangle(7.1, 6.8),
            new Circle(5.5),
            new Circle(7.3),
            new Circle(8.4)
        };


        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
