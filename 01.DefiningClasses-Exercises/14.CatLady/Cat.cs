public class Cat
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private string breed;

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }

    public Cat()
    {
    }

    public Cat(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }

    public override string ToString()
    {
        return $"{this.breed} {this.name}";
    }
}
