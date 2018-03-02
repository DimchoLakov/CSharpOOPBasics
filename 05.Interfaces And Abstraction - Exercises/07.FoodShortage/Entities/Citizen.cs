using System;

public class Citizen : IIdentifyable, IBirthable, IBuyer
{
    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public DateTime Birthday { get; private set; }

    public Citizen()
    {
        this.Food = 0;
    }

    public Citizen(string name, int age, string id, DateTime birthday) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthday = birthday;
    }

    public void BuyFood()
    {
        this.Food += 10;
    }

    public int Food { get; private set; }
}