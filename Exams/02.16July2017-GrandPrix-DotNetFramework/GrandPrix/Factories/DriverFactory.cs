using System;
using System.Collections.Generic;

public class DriverFactory
{
    public static Driver CreateDriver(List<string> arguments)
    {
        string type = arguments[0];
        string name = arguments[1];

        Tyre tyre = TyreFactory.CreateTyre(arguments);

        Car car = new Car(int.Parse(arguments[2]), double.Parse(arguments[3]), tyre);

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                throw new ArgumentException();
        }
    }
}