public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; set; }

    public override double GetTotalPower()
    {
        return this.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return base.ToString() + $" Ground Saturation: {this.GroundSaturation:f2}";
    }
}