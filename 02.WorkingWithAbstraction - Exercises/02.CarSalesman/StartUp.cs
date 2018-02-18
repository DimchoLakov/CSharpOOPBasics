using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        int enginesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < enginesCount; i++)
        {
            AddEnginesToList(engines);
        }

        int carsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsCount; i++)
        {
            AddCarsToList(cars, engines);
        }

        cars.ForEach(Console.WriteLine);
    }

    private static void AddCarsToList(List<Car> cars, List<Engine> engines)
    {
        string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string model = parameters[0];
        string engineModel = parameters[1];
        Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
        Car car = new Car(model, engine);
        
        if (parameters.Length > 2)
        {
            if (!int.TryParse(parameters[2], out int carWeight))
            {
                car.Color = parameters[2];
            }
            else
            {
                car.Weigh = carWeight.ToString();
            }
        }
        if (parameters.Length > 3)
        {
            car.Color = parameters[3];
        }
        
        cars.Add(car);
    }

    private static void AddEnginesToList(List<Engine> engines)
    {
        string[] parameters = 
            Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string model = parameters[0];
        int power = int.Parse(parameters[1]);

        Engine engine = new Engine(model, power);
        
        if (parameters.Length > 2)
        {
            if (!int.TryParse(parameters[2], out int displacement))
            {
                engine.Efficiency = parameters[2];
            }
            else
            {
                engine.Displacement = displacement.ToString();
            }
        }
        if (parameters.Length > 3)
        {
            string efficiency = parameters[3];
            engine.Efficiency = efficiency;
        }

        engines.Add(engine);
    }
}