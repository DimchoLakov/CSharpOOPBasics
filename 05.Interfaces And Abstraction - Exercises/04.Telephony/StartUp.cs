using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<string> numbers = Console.ReadLine()
		.Split()
		.ToList();

        List<string> urls = Console.ReadLine()
		.Split()
		.ToList();

        Smartphone smartphone = new Smartphone
        {
            Sites = urls,
            Numbers = numbers
        };

        foreach (string number in smartphone.Numbers)
        {
            try
            {
                Console.WriteLine(smartphone.Call(number));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        foreach (string site in smartphone.Sites)
        {
            try
            {
                Console.WriteLine(smartphone.Browse(site));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}