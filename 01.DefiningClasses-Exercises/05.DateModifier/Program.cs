using System;

class Program
{
    static void Main()
    {
        string firstInput = Console.ReadLine();
        string secondInput = Console.ReadLine();

        DateModifier dm = new DateModifier();
        int difference = dm.CalculateDaysBetweenDates(firstInput, secondInput);

        Console.WriteLine(difference);
    }
}