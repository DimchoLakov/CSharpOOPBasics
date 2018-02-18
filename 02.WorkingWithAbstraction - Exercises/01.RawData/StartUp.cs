using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());

        AddCarsToList(cars, lines);

        string command = Console.ReadLine();

        if (command.Equals("fragile"))
        {
            cars
                .Where(c => c.Cargo.CargoType.Equals(command))
                .Where(t => t.Tires.Any(ti => ti.Pressure < 1))
                .ToList()
                .ForEach(Console.WriteLine);
        }
        else if (command.Equals("flamable"))
        {
            cars
                .Where(c => c.Cargo.CargoType.Equals(command))
                .Where(e => e.Engine.EnginePower > 250)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }

    private static void AddCarsToList(List<Car> cars, int lines)
    {
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = parameters[0];
            Engine engine = GetEngine(parameters);
            Cargo cargo = GetCargo(parameters);
            List<Tire> tires = GetTires(parameters);

            cars.Add(new Car(model, engine, cargo, tires));
        }
    }

    private static List<Tire> GetTires(string[] parameters)
    {
        double tire1Pressure = double.Parse(parameters[5]);
        int tire1age = int.Parse(parameters[6]);
        double tire2Pressure = double.Parse(parameters[7]);
        int tire2age = int.Parse(parameters[8]);
        double tire3Pressure = double.Parse(parameters[9]);
        int tire3age = int.Parse(parameters[10]);
        double tire4Pressure = double.Parse(parameters[11]);
        int tire4age = int.Parse(parameters[12]);

        Tire tireOne = new Tire(tire1age, tire1Pressure);
        Tire tireTwo = new Tire(tire2age, tire2Pressure);
        Tire tireThree = new Tire(tire3age, tire3Pressure);
        Tire tireFour = new Tire(tire4age, tire4Pressure);

        return new List<Tire>
        {
            tireOne,
            tireTwo,
            tireThree,
            tireFour
        };
    }

    private static Cargo GetCargo(string[] parameters)
    {
        int cargoWeight = int.Parse(parameters[3]);
        string cargoType = parameters[4];

        return new Cargo(cargoWeight, cargoType);
    }

    private static Engine GetEngine(string[] parameters)
    {
        int engineSpeed = int.Parse(parameters[1]);
        int enginePower = int.Parse(parameters[2]);

        return new Engine(engineSpeed, enginePower);
    }
}
