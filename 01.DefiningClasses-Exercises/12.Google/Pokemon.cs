using System.Collections.Generic;

public class Pokemon
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private string type;

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public Pokemon()
    {
    }

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{this.name} {this.type}";
    }
}