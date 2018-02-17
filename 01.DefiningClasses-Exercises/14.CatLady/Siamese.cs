public class Siamese : Cat
{
    private int earSize;

    public int EarSize
    {
        get { return this.earSize;}
        set { this.earSize = value; }
    }

    public Siamese()
    {
    }

    public Siamese(string name, string breed, int earSize) : this()
    {
        this.Name = name;
        this.Breed = breed;
        this.earSize = earSize;
    }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name} {this.earSize}";
    }
}