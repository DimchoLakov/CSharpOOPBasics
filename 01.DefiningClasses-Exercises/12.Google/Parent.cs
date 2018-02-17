using System;

public class Parent
{
    private string name;

    public string Name
    {
        get { return this.Name; }
        set { this.Name = value; }
    }

    private string dateOfBirth;

    public string DateOfBirth
    {
        get { return this.dateOfBirth; }
        set { this.dateOfBirth = value; }
    }

    public Parent()
    {
    }

    public Parent(string name, string dateOfBirth)
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
    }

    public override string ToString()
    {
        return $"{this.name} {this.dateOfBirth}";
    }
}