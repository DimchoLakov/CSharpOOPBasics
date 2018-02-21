using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        private set
        {
            this.toppings = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name, Dough dough) : this()
    {
        this.Name = name;
        this.Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.Toppings.Add(topping);
    }

    public double GetTotalCalories()
    {
        double toppingsCalories = this.Toppings.Sum(t => t.GetCalories());
        double doughCalories = this.Dough.GetCalories();
        return toppingsCalories + doughCalories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.GetTotalCalories():f2} Calories.";
    }
}