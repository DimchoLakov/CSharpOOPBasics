using System.Text;

public class Engine
{
    private string model;
    private int power;
    private string displacement;
    private string efficiency;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public string Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

    public Engine()
    {
        this.displacement = "n/a";
        this.efficiency = "n/a";
    }

    public Engine(string model, int power) : this()
    {
        this.model = model;
        this.power = power;
    }

    public Engine(string model, int power, string displacement, string efficiency) : this(model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"    Power: {this.power}");
        sb.AppendLine($"    Displacement: {this.displacement}");
        sb.Append($"    Efficiency: {this.efficiency}");
        return sb.ToString();
    }
}
