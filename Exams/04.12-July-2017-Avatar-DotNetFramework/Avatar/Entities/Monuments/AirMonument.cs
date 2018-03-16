public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override string ToString()
    {
        return base.ToString() + this.AirAffinity;
    }
}