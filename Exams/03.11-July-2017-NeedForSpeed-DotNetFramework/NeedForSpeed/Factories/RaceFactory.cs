using System;

public class RaceFactory
{
    public static Race CreateRace(string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);
            case "Drift":
                return new DriftRace(length, route, prizePool);
            case "Drag":
                return new DragRace(length, route, prizePool);
            default:
                throw new ArgumentException();
        }
    }

    public static Race CreateRace(string type, int length, string route, int prizePool, int lastParameter)
    {
        switch (type)
        {
            case "Circuit":
                return new CircuitRace(length, route, prizePool, lastParameter);
            case "TimeLimit":
                return new TimeLimitRace(length, route, prizePool, lastParameter);
            default:
                throw new ArgumentException();
        }
    }
}