using System;
using System.Collections.Generic;

public class CarFactory
{
    public static Car CreateCar(string type, string brand, string model, int year, int hp, int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                return new PerformanceCar(brand, model, year, hp, acceleration, suspension, durability);
            case "Show":
                return new ShowCar(brand, model, year, hp, acceleration, suspension, durability);
            default:
                throw new ArgumentException();
        }
    }
}