using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0] + "Provider";
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        switch (type)
        {
            case "SolarProvider":
                return new SolarProvider(id, energyOutput);
            case "PressureProvider":
                return new PressureProvider(id, energyOutput);
            default:
                throw new ArgumentException();
        }
    }
}