using System.Collections.Generic;
using System.Linq;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override List<Car> GetFirstThree()
    {
        List<Car> firstThree = this.Participants
            .Select(c => c.Value)
            .OrderByDescending(c => c.GetEnginePerformance())
            .Take(3)
            .ToList();

        return firstThree;
    }

    protected override int GetPP(Car car)
    {
        return car.GetEnginePerformance();
    }
}