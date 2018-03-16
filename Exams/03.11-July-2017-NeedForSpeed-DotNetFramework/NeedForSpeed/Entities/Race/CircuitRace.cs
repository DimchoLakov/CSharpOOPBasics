using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; set; }

    public List<Car> GetFirstFour()
    {
        var firstFour = this.Participants
            .Select(c => c.Value)
            .OrderByDescending(p => p.GetOverallPerformance())
            .Take(4)
            .ToList();

        return firstFour;
    }

    protected override int GetPP(Car car)
    {
        return car.GetOverallPerformance();
    }

    protected override int GetMoney(int position, int prizePool)
    {
        switch (position)
        {
            case 1:
                return prizePool * 40 / 100;
            case 2:
                return prizePool * 30 / 100;
            case 3:
                return prizePool * 20 / 100;
            case 4:
                return prizePool * 10 / 100;
            default:
                return 0;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb
            .AppendLine($"{this.Route} - {this.Length * this.Laps}");

        var firstFour = this.GetFirstFour();

        int position = 1;
        int pp = 0;
        int money = 0;

        for (int i = 0; i < this.Laps; i++)
        {
            foreach (Car car in firstFour)
            {
                car.Durability -= this.Length * this.Length;
            }
        }

        foreach (Car car in firstFour)
        {
            money = GetMoney(position, this.PrizePool);
            pp = GetPP(car);
            sb.AppendLine($"{position}. {car.Brand} {car.Model} {pp}PP - ${money}");
            position++;
        }

        return sb.ToString().Trim();
    }
}