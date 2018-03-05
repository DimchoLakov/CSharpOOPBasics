using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] carTokens = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string[] truckTokens = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string[] busTokens = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        IVehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
        IVehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]),
            double.Parse(truckTokens[3]));
        IVehicle bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

        List<IVehicle> vehicles = new List<IVehicle>
        {
            car,
            truck,
            bus
        };

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            string vehicleType = tokens[1];
            double param = double.Parse(tokens[2]);

            IVehicle vehicle = null;
            switch (vehicleType)
            {
                case "Car":
                    vehicle = car;
                    break;
                case "Truck":
                    vehicle = truck;
                    break;
                case "Bus":
                    vehicle = bus;
                    break;
            }

            if (vehicle == null)
            {
                continue;
            }
            switch (command)
            {
                case "Drive":
                    try
                    {
                        Console.WriteLine(vehicle.Drive(param));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(param);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;
                case "DriveEmpty":
                    try
                    {
                        Console.WriteLine(vehicle.DriveEmpty(param));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;
            }
        }

        vehicles.ForEach(Console.WriteLine);
    }
}