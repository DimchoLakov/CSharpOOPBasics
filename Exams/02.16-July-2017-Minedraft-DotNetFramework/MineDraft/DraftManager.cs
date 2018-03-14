using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public Dictionary<string, Harvester> Harvesters { get; private set; }

    public Dictionary<string, Provider> Providers { get; private set; }

    public string ModeType
    {
        get { return this.mode; }
        set { this.mode = value; }
    }

    public double TotalStoredEnergy
    {
        get { return this.totalStoredEnergy; }
        private set { this.totalStoredEnergy = value; }
    }

    public double TotalMinedOre
    {
        get { return this.totalMinedOre; }
        private set { this.totalMinedOre = value; }
    }

    public DraftManager()
    {
        this.Harvesters = new Dictionary<string, Harvester>();
        this.Providers = new Dictionary<string, Provider>();
        this.TotalStoredEnergy = 0;
        this.TotalMinedOre = 0;
        this.ModeType = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);

            this.Harvesters[harvester.Id] = harvester;

            string fullType = harvester.GetType().Name;
            string type = fullType.Substring(0, fullType.LastIndexOf('H'));

            return $"Successfully registered {type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException argumentException)
        {
            return argumentException.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = ProviderFactory.CreateProvider(arguments);

            this.Providers[provider.Id] = provider;

            string fullType = provider.GetType().Name;
            string type = fullType.Substring(0, fullType.LastIndexOf('P'));

            return $"Successfully registered {type} Provider - {provider.Id}";
        }
        catch (ArgumentException argumentException)
        {
            return argumentException.Message;
        }
    }

    public string Day()
    {
        double dailyProvidedEnergy = 0d;
        dailyProvidedEnergy = this.Providers.Sum(e => e.Value.EnergyOutput);
        this.TotalStoredEnergy += dailyProvidedEnergy;

        double requiredEnergyByHarvesters = 0d;
        requiredEnergyByHarvesters = this.Harvesters.Sum(e => e.Value.EnergyRequirement);

        double dailyProducedOre = 0d;

        if (requiredEnergyByHarvesters <= this.TotalStoredEnergy)
        {
            if (this.ModeType == "Full")
            {
                this.TotalStoredEnergy -= requiredEnergyByHarvesters;

                dailyProducedOre += this.Harvesters.Sum(o => o.Value.OreOutput);
                this.TotalMinedOre += dailyProducedOre;
            }
            else if (this.ModeType == "Half")
            {
                this.TotalStoredEnergy -= requiredEnergyByHarvesters * 0.6d;

                dailyProducedOre += this.Harvesters.Sum(o => o.Value.OreOutput) * 0.5d;
                this.TotalMinedOre += dailyProducedOre;
            }
        }

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("A day has passed.")
          .AppendLine($"Energy Provided: {dailyProvidedEnergy}")
          .AppendLine($"Plumbus Ore Mined: {dailyProducedOre}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string newMode = arguments[0];

        this.ModeType = newMode;

        return $"Successfully changed working mode to {this.ModeType} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (this.Providers.ContainsKey(id))
        {
            return this.Providers[id].ToString();
        }

        if (this.Harvesters.ContainsKey(id))
        {
            return this.Harvesters[id].ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown")
          .AppendLine($"Total Energy Stored: {this.TotalStoredEnergy}")
          .AppendLine($"Total Mined Plumbus Ore: {this.TotalMinedOre}");

        return sb.ToString().Trim();
    }
}
