using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override void Eat(Food food)
    {
        if (food.GetType().Name != typeof(Meat).ToString())
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.Weight += food.Quanity * 0.4;
        this.FoodEaten += food.Quanity;
    }
}