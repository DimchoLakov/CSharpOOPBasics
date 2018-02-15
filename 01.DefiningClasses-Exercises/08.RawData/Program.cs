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

            int engineSpeed = int.Parse(tokens[1]);
            int engingePower = int.Parse(tokens[2]);

            int cargoWeight = int.Parse(tokens[3]);
            string cargoType = tokens[4];

            double tireOnePressure = double.Parse(tokens[5]);
            int tireOneAge = int.Parse(tokens[6]);

            double tireTwoPressure = double.Parse(tokens[7]);
            int tireTwoAge = int.Parse(tokens[8]);

            double tireThreePressure = double.Parse(tokens[9]);
            int tireThreeAge = int.Parse(tokens[10]);

            double tireFourPressure = double.Parse(tokens[11]);
            int tireFourAge = int.Parse(tokens[12]);
            
            Tire firstTire = new Tire(tireOneAge, tireOnePressure);
            Tire secondTire = new Tire(tireTwoAge, tireTwoPressure);
            Tire thirdTire = new Tire(tireThreeAge, tireThreePressure);
            Tire fourthTire = new Tire(tireFourAge, tireFourPressure);

            List<Tire> tiresList = new List<Tire>
            {
                firstTire,
                secondTire,
                thirdTire,
                fourthTire
            };

            Car car = new Car(model, new Cargo(cargoType, cargoWeight), new Engine(engingePower, engineSpeed), tiresList);

            carList.Add(car);
        }

        string command = Console.ReadLine();

        if (command.Equals("fragile"))
        {
            List<Car> carsWithFragileCargo = carList
                .Where(x => x.Cargo.Type == "fragile" && x.Tires.Exists(p => p.Pressure < 1))
                .ToList();

            foreach (Car car in carsWithFragileCargo)
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (command.Equals("flamable"))
        {
            List<Car> carsWithFlamableCargo = carList
                .Where(ct => ct.Cargo.Type == "flamable" && ct.Engine.Power > 250)
                .ToList();

            foreach (Car car in carsWithFlamableCargo)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}