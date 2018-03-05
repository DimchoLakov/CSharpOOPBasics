public abstract class Animal
{
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private double weight;

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    private int foodEaten;

    public int FoodEaten
    {
        get { return this.foodEaten; }
        set { this.foodEaten = value; }
    }

    public virtual string ProduceSound()
    {
        return "Animal sound";
    }

    public virtual void Eat(Food food)
    {
        this.Weight += food.Quanity;
    }
}