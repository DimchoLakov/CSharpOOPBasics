using System;
using System.Linq;

public class Point
{
    private int x;
    private int y;

    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public Point()
    {
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point ReadPoint(Func<string> point)
    {

        int[] pointCoords = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int x = pointCoords[0];
        int y = pointCoords[1];

        return new Point(x, y);
    }
}