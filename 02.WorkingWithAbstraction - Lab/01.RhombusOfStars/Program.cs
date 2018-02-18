using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        for (int row = 1; row <= size; row++)
        {
            PrintRow(size, row);
        }

        for (int row = size - 1; row > 0; row--)
        {
            PrintRow(size, row);
        }
    }

    private static void PrintRow(int size, int row)
    {
        for (int i = 0; i < size - row; i++)
        {
            Console.Write(" ");
        }
        for (int i = 1; i < row; i++)
        {
            Console.Write("* ");
        }
        Console.WriteLine("*");
    }
}