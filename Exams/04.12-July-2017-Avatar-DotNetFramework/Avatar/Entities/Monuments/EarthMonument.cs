public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; set; }

    public override string ToString()
    {
        return base.ToString() + this.EarthAffinity;
    }
}