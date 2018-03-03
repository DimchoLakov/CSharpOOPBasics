using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps, List<IMission> missions) : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public List<IMission> Missions { get; private set; }
    public void CompleteMission()
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps}");
        sb.AppendLine("Missions:");
        foreach (var mission in this.Missions)
        {
            sb.AppendLine("  " + mission);
        }
        return sb.ToString().Trim();
    }
}