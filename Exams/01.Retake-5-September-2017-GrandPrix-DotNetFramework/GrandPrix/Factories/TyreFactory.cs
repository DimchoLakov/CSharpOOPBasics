using System;
using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateTyre(List<string> arguments)
    {
        string type = arguments[4];
        double hardness = double.Parse(arguments[5]);

        switch (type)
        {
            case "Ultrasoft":
                double grip = double.Parse(arguments[6]);
                return new UltrasoftTyre(hardness, grip);
            case "Hard":
                return new HardTyre(hardness);
            default:
                throw new ArgumentException();
        }
    }
}