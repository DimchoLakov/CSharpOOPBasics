using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }

    public override void Eat(Food food)
    {
        this.Weight += food.Quanity * 0.25;
        this.FoodEaten += food.Quanity;
    }
}