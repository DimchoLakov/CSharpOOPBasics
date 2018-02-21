using System;

public class Dough
{
    private string type;
    private string bakingTechnique;
    private double weight;

    private string Type
    {
        get { return this.type; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.type = value;
        }
    }

    private string BakingTechnique
    {
        get { return this.bakingTechnique; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    private double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public Dough()
    {
    }

    public Dough(string type, string bakingTechnique, double weight)
    {
        this.Type = type;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double GetCalories()
    {
        double baseModifier = 2d;
        double typeModifier = 0d;

        switch (this.Type.ToLower())
        {
            case "white":
                typeModifier = 1.5d;
                break;
            case "wholegrain":
                typeModifier = 1d;
                break;
        }

        double bakingTechniqueModifier = 0d;

        switch (this.BakingTechnique.ToLower())
        {
            case "crispy":
                bakingTechniqueModifier = 0.9d;
                break;
            case "chewy":
                bakingTechniqueModifier = 1.1d;
                break;
            case "homemade":
                bakingTechniqueModifier = 1d;
                break;
        }

        return this.Weight * baseModifier * typeModifier * bakingTechniqueModifier;
    }
}