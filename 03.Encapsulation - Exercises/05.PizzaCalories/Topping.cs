using System;

public class Topping
{
    private string type;
    private double weight;

    private string Type
    {
        get { return this.type; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }

    private double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public Topping()
    {
    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double GetCalories()
    {
        double baseModifier = 2d;
        double typeModifier = 0d;

        switch (this.Type.ToLower())
        {
            case "meat":
                typeModifier = 1.2d;
                break;
            case "veggies":
                typeModifier = 0.8d;
                break;
            case "cheese":
                typeModifier = 1.1d;
                break;
            case "sauce":
                typeModifier = 0.9d;
                break;
        }

        return this.Weight * baseModifier * typeModifier;
    }
}