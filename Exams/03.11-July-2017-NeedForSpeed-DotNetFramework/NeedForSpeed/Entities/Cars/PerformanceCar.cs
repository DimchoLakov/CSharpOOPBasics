using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.HorsePower += this.HorsePower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;
    }

    public List<string> AddOns
    {
        get => this.addOns;
        set => this.addOns = value;
    }

    public void IncreaseHorsePowerAndSuspension(int tuneIndex)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string addOns = string.Join(", ", this.AddOns) == string.Empty ? "None" : string.Join(", ", this.AddOns);

        sb
            .AppendLine(base.ToString())
            .AppendLine($"Add-ons: {addOns}");

        return sb.ToString().Trim();
    }
}