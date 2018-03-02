using System;

public class Pet : IBirthable
{
    public string Name { get; set; }
    public DateTime Birthday { get; private set; }

    public Pet()
    {
    }

    public Pet(string name, DateTime birthday) : this()
    {
        this.Name = name;
        this.Birthday = birthday;
    }
}