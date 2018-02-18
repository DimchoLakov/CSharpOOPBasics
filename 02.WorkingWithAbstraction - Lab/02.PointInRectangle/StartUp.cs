using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] coords = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        Point topLeft = new Point(coords[0], coords[1]);
        Point botRight = new Point(coords[2], coords[3]);

        Rectangle rectangle = new Rectangle(topLeft, botRight);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Point currentPoint = Point.ReadPoint(Console.ReadLine);
            Console.WriteLine(rectangle.Contains(currentPoint));
        }
    }
}