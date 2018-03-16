public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override string ToString()
    {
        return base.ToString() + this.FireAffinity;
    }
}