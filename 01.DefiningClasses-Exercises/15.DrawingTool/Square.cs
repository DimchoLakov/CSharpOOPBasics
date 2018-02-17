using System;
using System.Text;

public class Square
{
    private int side;

    public int Side
    {
        get { return this.side; }
        set { this.side = value; }
    }

    public Square()
    {
    }

    public Square(int a) : this()
    {
        this.side = a;
    }

    public void Draw()
    {
        StringBuilder sb = new StringBuilder();

        int a = this.side;

        sb.AppendLine($"|{new string('-', a)}|");
        for (int i = 0; i < a - 2; i++)
        {
            sb.AppendLine($"|{new string(' ', a)}|");
        }
        sb.Append($"|{new string('-', a)}|");
        Console.WriteLine(sb.ToString());
    }
}