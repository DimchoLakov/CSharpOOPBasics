using System;
using System.Text;

public class Rectangle
{
    private int width;
    private int height;

    public int Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public int Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public Rectangle()
    {
    }

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        int width = this.width;
        int height = this.height;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"|{new string('-', width)}|");
        for (int i = 0; i < height - 2; i++)
        {
            sb.AppendLine($"|{new string(' ', width)}|");
        }
        sb.Append($"|{new string('-', width)}|");
        Console.WriteLine(sb.ToString());
    }
}