using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            Student student = ReadStudent(Console.ReadLine());
            Worker worker = ReadWorker(Console.ReadLine());
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static Worker ReadWorker(string input)
    {
        string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return new Worker(tokens[0], tokens[1], decimal.Parse(tokens[2]), decimal.Parse(tokens[3]));
    }

    private static Student ReadStudent(string input)
    {
        string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return new Student(tokens[0], tokens[1], tokens[2]);
    }
}