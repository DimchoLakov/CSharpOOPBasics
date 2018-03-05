using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ProduceSound()
    {
        return "Meow";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != typeof(Meat).ToString() && food.GetType().Name != typeof(Vegetable).ToString())
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.Weight += food.Quanity * 0.3;
        this.FoodEaten += food.Quanity;
    }
}