using System;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthdate { get; set; }

    public override string ToString()
    {
        return $"{this.Name}{Environment.NewLine}{this.Age}";
    }
}