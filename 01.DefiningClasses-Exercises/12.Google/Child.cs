using System;
using System.Collections.Generic;

public class Child
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private string dateOfBirth;

    public string DateOfBirth
    {
        get { return this.dateOfBirth; }
        set { this.dateOfBirth = value; }
    }

    public Child()
    {
    }

    public Child(string name, string dateOfBirth)
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
    }
    public override string ToString()
    {
        return $"{this.name} {this.dateOfBirth}";
    }
}