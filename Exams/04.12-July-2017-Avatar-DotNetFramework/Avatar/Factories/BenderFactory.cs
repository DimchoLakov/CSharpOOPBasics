using System;
using System.Collections.Generic;

public class BenderFactory
{
    public static Bender CreateBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParam = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secondaryParam);
            case "Water":
                return new WaterBender(name, power, secondaryParam);
            case "Fire":
                return new FireBender(name, power, secondaryParam);
            case "Earth":
                return new EarthBender(name, power, secondaryParam);
            default:
                throw new ArgumentException();
        }
    }
}