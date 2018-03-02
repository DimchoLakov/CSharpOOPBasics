public class Rebel : IBuyer
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public string Group { get; private set; }

    public Rebel()
    {
        this.Food = 0;
    }

    public Rebel(string name, int age, string group) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }

    public int Food { get; private set; }
}