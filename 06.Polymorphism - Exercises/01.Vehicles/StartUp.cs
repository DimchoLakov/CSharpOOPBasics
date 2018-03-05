using System;

public class StartUp
{
    public static void Main()
    {
        string[] carTokens = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        string[] truckTokens = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));
        Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            string vehicleType = tokens[1];
            double distanceOrFuel = double.Parse(tokens[2]);
            
            IVehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = car;
            }
            else if (vehicleType == "Truck")
            {
                vehicle = truck;
            }

            if (vehicle != null)
            {
                if (command == "Drive")
                {
                    Console.WriteLine(vehicle.Drive(distanceOrFuel));
                }
                else if (command == "Refuel")
                {
                    vehicle.Refuel(distanceOrFuel);
                }
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}