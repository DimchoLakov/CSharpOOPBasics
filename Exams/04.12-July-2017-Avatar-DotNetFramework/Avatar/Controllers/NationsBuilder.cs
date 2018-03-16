using System.Collections.Generic;
using System.Linq;

public class NationsBuilder
{
    private Dictionary<string, Nation> Nations { get; set; }
    private readonly War war;
    
    public NationsBuilder()
    {
        this.Nations = new Dictionary<string, Nation>
        {
            ["Air"] = new AirNation(),
            ["Water"] = new WaterNation(),
            ["Fire"] = new FireNation(),
            ["Earth"] = new EarthNation()
        };
        this.war = new War();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        switch (type)
        {
            case "Air":
                this.Nations[type].Benders.Add(BenderFactory.CreateBender(benderArgs));
                //this.AirNation.Benders.Add(BenderFactory.CreateBender(benderArgs));
                break;
            case "Water":
                this.Nations[type].Benders.Add(BenderFactory.CreateBender(benderArgs));
                //this.WaterNation.Benders.Add(BenderFactory.CreateBender(benderArgs));
                break;
            case "Fire":
                this.Nations[type].Benders.Add(BenderFactory.CreateBender(benderArgs));
                //this.FireNation.Benders.Add(BenderFactory.CreateBender(benderArgs));
                break;
            case "Earth":
                this.Nations[type].Benders.Add(BenderFactory.CreateBender(benderArgs));
                //this.EarthNation.Benders.Add(BenderFactory.CreateBender(benderArgs));
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        switch (type)
        {
            case "Air":
                this.Nations[type].Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                //this.AirNation.Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                break;
            case "Water":
                this.Nations[type].Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                //this.WaterNation.Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                break;
            case "Fire":
                this.Nations[type].Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                //this.FireNation.Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                break;
            case "Earth":
                this.Nations[type].Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                //this.EarthNation.Monuments.Add(MonumentFactory.CreateMonument(monumentArgs));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        return this.Nations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        this.war.WarRecords.Add(nationsType);

        Nation winnerNation = this.Nations.Select(n => n.Value).OrderByDescending(p => p.GetNationTotalPower()).First();

        foreach (var nameNation in this.Nations.Where(n => n.Key != winnerNation.Name))
        {
            nameNation.Value.Benders = new List<Bender>();
            nameNation.Value.Monuments = new List<Monument>();
        }
    }

    public string GetWarsRecord()
    {
        return war.ToString();
    }
}