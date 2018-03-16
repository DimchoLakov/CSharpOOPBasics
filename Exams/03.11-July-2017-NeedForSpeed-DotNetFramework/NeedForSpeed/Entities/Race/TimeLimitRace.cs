using System;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; set; }

    public int TimePerformance => this.Length * ((GetFirstParticipant().HorsePower / 100) * GetFirstParticipant().Acceleration);

    public Car GetFirstParticipant()
    {
        Car car = this.Participants.First().Value;
        return car;
    }

    public string TimeStatus
    {
        get
        {
            if (this.TimePerformance <= this.GoldTime)
            {
                return "Gold";
            }
            if (this.TimePerformance <= this.GoldTime + 15)
            {
                return "Silver";
            }
            if (this.TimePerformance > this.GoldTime + 15)
            {
                return "Bronze";
            }
            return string.Empty;
        }
    }

    public void AddParticipant(int carId, Car car)
    {
        if (this.Participants.Count == 0)
        {
            this.Participants.Add(carId, car);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        Car car = GetFirstParticipant();

        int prize = GetPrize(car, this.TimeStatus);

        sb
            .AppendLine($"{this.Route} - {this.Length}")
            .AppendLine($"{car.Brand} {car.Model} - {this.TimePerformance} s.")
            .AppendLine($"{this.TimeStatus} Time, ${prize}.");

        return sb.ToString();
    }

    private int GetPrize(Car car, string timeStatus)
    {
        switch (timeStatus)
        {
            case "Gold":
                return this.PrizePool;
            case "Silver":
                return this.PrizePool * 50 / 100;
            case "Bronze":
                return this.PrizePool * 30 / 100;
            default:
                throw new ArgumentException();
        }
    }
}