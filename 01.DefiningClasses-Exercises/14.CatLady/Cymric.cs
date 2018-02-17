public class Cymric : Cat
{
    private double furLength;

    public double FurLength
    {
        get { return this.furLength; }
        set { this.furLength = value; }
    }

    public Cymric()
    {
    }

    public Cymric(string name, string breed, double furLength)
    {
        this.Name = name;
        this.Breed = breed;
        this.furLength = furLength;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.furLength:f2}";
    }
}