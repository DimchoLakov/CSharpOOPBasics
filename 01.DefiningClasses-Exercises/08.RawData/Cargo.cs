public class Cargo
{
    private string type;

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    private double weight;

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public Cargo()
    {
    }

    public Cargo(string type, double weight)
    {
        this.type = type;
        this.weight = weight;
    }
}
