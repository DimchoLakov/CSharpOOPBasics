using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != typeof(Meat).ToString())
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.Weight += food.Quanity * 1;
        this.FoodEaten += food.Quanity;
    }
}