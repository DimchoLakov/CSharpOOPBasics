public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += this.OreOutput * 2; //increase by 200%
        this.EnergyRequirement *= 2; //increase by 100%
    }
}