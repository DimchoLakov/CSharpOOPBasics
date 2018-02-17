using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, Engine> enginesDict = new Dictionary<string, Engine>();

        int n = int.Parse(Console.ReadLine());
        ReadEngines(enginesDict, n);

        int m = int.Parse(Console.ReadLine());
        List<Car> carList = new List<Car>();
        ReadCars(enginesDict, m, carList);

        PrintCarsInfo(carList);
    }

    private static void PrintCarsInfo(List<Car> carList)
    {
        foreach (Car car in carList)
        {
            Console.WriteLine(car);
        }
    }

    private static void ReadCars(Dictionary<string, Engine> enginesDict, int m, List<Car> carList)
    {
        for (int i = 0; i < m; i++)
        {
            string[] carTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string carModel = carTokens[0];
            string engineModel = carTokens[1];

            Car car = new Car(carModel);

            if (enginesDict.ContainsKey(engineModel))
            {
                car.Engine = enginesDict[engineModel];
            }

            if (carTokens.Length > 2)
            {
                int carWeight;
                if (!int.TryParse(carTokens[2], out carWeight))
                {
                    car.Color = carTokens[2];
                }
                else
                {
                    car.Weight = carWeight.ToString();
                }
            }

            if (carTokens.Length > 3)
            {
                car.Color = carTokens[3];
            }

            carList.Add(car);
        }
    }

    private static void ReadEngines(Dictionary<string, Engine> enginesDict, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string[] engineTokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = engineTokens[0];
            int power = int.Parse(engineTokens[1]);

            Engine engine = new Engine(model, power);

            if (engineTokens.Length > 2)
            {
                int displacement;
                if (!int.TryParse(engineTokens[2], out displacement))
                {
                    engine.Efficiency = engineTokens[2];
                }
                else
                {
                    engine.Displacement = displacement.ToString();
                }
            }

            if (engineTokens.Length > 3)
            {
                string efficiency = engineTokens[3];
                engine.Efficiency = efficiency;
            }

            if (!enginesDict.ContainsKey(model))
            {
                enginesDict.Add(model, engine);
            }
            else
            {
                enginesDict[model] = engine;
            }
        }
    }
}