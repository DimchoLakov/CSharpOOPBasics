using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Nation
{
    protected Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
        this.TotalPower = 0;
    }

    public virtual string Name { get; protected set; }

    public double TotalPower { get; protected set; }

    public List<Bender> Benders { get; set; }

    public List<Monument> Monuments { get; set; }

    public double GetNationTotalPower()
    {
        this.TotalPower = this.Benders.Sum(b => b.GetTotalPower());
        double bonusFromMonuments = this.Monuments.Sum(a => a.Affinity);
        this.TotalPower += (this.TotalPower / 100) * bonusFromMonuments;

        return this.TotalPower;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string fullNationType = this.GetType().Name;
        string type = fullNationType.Substring(0, fullNationType.LastIndexOf('N'));

        sb.AppendLine($"{type} Nation");

        if (this.Benders.Count != 0)
        {
            sb.AppendLine("Benders:");
            foreach (Bender bender in this.Benders)
            {
                sb.AppendLine($"###{bender.ToString()}");
            }
        }
        else
        {
            sb.AppendLine("Benders: None");
        }

        if (this.Monuments.Count != 0)
        {
            sb.AppendLine("Monuments:");
            foreach (Monument monument in this.Monuments)
            {
                sb.AppendLine($"###{monument.ToString()}");
            }
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }

        return sb.ToString().Trim();
    }
}