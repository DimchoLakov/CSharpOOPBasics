using System.Collections.Generic;
using System.Linq;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override List<Car> GetFirstThree()
    {
        List<Car> firstThree = this.Participants
            .Select(c => c.Value)
            .OrderByDescending(c => c.GetOverallPerformance())
            .Take(3)
            .ToList();

        return firstThree;
    }

    protected override int GetPP(Car car)
    {
        return car.GetOverallPerformance();
    }
}