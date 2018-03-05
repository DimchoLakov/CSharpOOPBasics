using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }

    public override void Eat(Food food)
    {
        this.Weight += food.Quanity * 0.35;
        this.FoodEaten += food.Quanity;
    }
}