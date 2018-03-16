using System.Text;

public abstract class Bender
{
    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; protected set; }

    public int Power { get; protected set; }

    public virtual double GetTotalPower()
    {
        return 0d;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string fullBenderType = this.GetType().Name;
        string type = fullBenderType.Substring(0, fullBenderType.LastIndexOf('B'));

        sb.AppendLine($"{type} Bender: {this.Name}, Power: {this.Power},");

        return sb.ToString().Trim();
    }
}