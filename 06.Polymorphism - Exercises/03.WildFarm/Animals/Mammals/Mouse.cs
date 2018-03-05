using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != typeof(Vegetable).ToString() && food.GetType().Name != typeof(Fruit).ToString())
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.Weight += food.Quanity * 0.1;
        this.FoodEaten += food.Quanity;
    }
}