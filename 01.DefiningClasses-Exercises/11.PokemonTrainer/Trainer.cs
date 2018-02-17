using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int bagdes;
    private List<Pokemon> pokemons;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Bagdes
    {
        get { return this.bagdes; }
        set { this.bagdes = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public Trainer()
    {
        this.bagdes = 0;
        this.pokemons = new List<Pokemon>();
    }

    public Trainer(string name) : this()
    {
        this.name = name;
    }
}
