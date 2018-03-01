public class Citizen : IIdentifyable
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }
    public Citizen()
    {
    }

    public Citizen(string name, int age, string id) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }
}