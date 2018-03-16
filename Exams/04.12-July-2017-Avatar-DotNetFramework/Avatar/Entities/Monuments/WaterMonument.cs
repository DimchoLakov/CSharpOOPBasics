public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override string ToString()
    {
        return base.ToString() + this.WaterAffinity;
    }
}