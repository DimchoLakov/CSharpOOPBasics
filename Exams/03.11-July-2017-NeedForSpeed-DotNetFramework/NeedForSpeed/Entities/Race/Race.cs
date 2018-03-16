using System.Collections.Generic;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    public int Length
    {
        get => this.length;
        protected set => this.length = value;
    }

    public string Route
    {
        get => this.route;
        protected set => this.route = value;
    }

    public int PrizePool
    {
        get => this.prizePool;
        protected set => this.prizePool = value;
    }

    public Dictionary<int, Car> Participants
    {
        get => this.participants;
        protected set => this.participants = value;
    }

    public virtual List<Car> GetFirstThree()
    {
        return new List<Car>();
    }

    protected virtual int GetMoney(int position, int prizePool)
    {
        switch (position)
        {
            case 1:
                return prizePool * 50 / 100;
            case 2:
                return prizePool * 30 / 100;
            case 3:
                return prizePool * 20 / 100;
            default:
                return prizePool * 50 / 100;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        List<Car> firstThree = GetFirstThree();

        int position = 1;
        int pp = 0;
        int money = 0;

        foreach (Car car in firstThree)
        {
            pp = GetPP(car);
            money = GetMoney(position, this.PrizePool);
            sb.AppendLine($"{position}. {car.Brand} {car.Model} {pp}PP - ${money}");
            position++;
        }

        return sb.ToString().Trim();
    }

    protected virtual int GetPP(Car car)
    {
        return 0;
    }
}
