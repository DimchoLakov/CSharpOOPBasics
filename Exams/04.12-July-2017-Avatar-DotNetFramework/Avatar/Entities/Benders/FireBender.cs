public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override double GetTotalPower()
    {
        return this.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return base.ToString() + $" Heat Aggression: {this.HeatAggression:f2}";
    }
}