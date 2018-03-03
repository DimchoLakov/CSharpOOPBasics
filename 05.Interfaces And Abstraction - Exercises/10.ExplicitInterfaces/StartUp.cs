using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Citizen> citizens = new List<Citizen>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            citizens.Add(new Citizen(tokens[0], tokens[1], int.Parse(tokens[2])));

            input = Console.ReadLine();
        }

        foreach (Citizen citizen in citizens)
        {
            //IPerson iPerson = (IPerson)citizen;
            //IResident iResident = (IResident)citizen;
            //Console.WriteLine(iPerson.GetName());
            //Console.WriteLine(iResident.GetName());

            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}