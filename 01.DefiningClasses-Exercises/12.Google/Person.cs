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

    private Car car;

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    private Company company;

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    private List<Pokemon> pokemons;

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    private List<Parent> parents;

    public List<Parent> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    private List<Child> children;

    public List<Child> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public Person()
    {
        this.children = new List<Child>();
        this.parents = new List<Parent>();
        this.pokemons = new List<Pokemon>();
    }

    public Person(string name) : this()
    {
        this.name = name;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.name);
        sb.AppendLine($"Company:");
        if (this.company != null)
        {
            sb.AppendLine(this.company.ToString());
        }
        sb.AppendLine($"Car:");
        if (this.car != null)
        {
            sb.AppendLine(this.car.ToString());
        }
        sb.AppendLine($"Pokemon:");
        if (this.pokemons.Count != 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.pokemons));
        }
        sb.AppendLine($"Parents:");
        if (this.parents.Count != 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.parents));
        }
        if (this.children.Count != 0)
        {
            sb.AppendLine($"Children:");
            sb.Append(string.Join(Environment.NewLine, this.children));
        }
        else
        {
            sb.Append("Children:");
        }
        return sb.ToString();
    }
}