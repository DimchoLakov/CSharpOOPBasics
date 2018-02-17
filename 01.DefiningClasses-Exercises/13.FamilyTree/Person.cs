using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private DateTime dateOfBirth;

    public DateTime DateOfBirth
    {
        get { return this.dateOfBirth; }
        set { this.dateOfBirth = value; }
    }
    
    public Person()
    {
        
    }

    public Person(string name) : this()
    {
        this.name = name;
    }

    public Person(DateTime dob) : this()
    {
        this.dateOfBirth = dob;
    }

    public Person(string name, DateTime dob) : this()
    {
        this.name = name;
        this.dateOfBirth = dob;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{this.name} {this.dateOfBirth.ToString("d/M/yyyy")}");
        return sb.ToString();
    }
}