using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Car> carList = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            double fuelAmount = double.Parse(tokens[1]);
            double fuelConsumptionFor1Km = double.Parse(tokens[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km);
            carList.Add(car);
        }

        string input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            string model = tokens[1];
            double amountOfKm = double.Parse(tokens[2]);

            if (command.Equals("Drive"))
            {
                carList.Where(m => m.Model == model).First().Drive(amountOfKm);
            }

            input = Console.ReadLine();
        }

        foreach (Car car in carList)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}
