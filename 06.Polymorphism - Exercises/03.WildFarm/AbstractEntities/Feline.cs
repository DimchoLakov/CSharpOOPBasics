public abstract class Feline : Mammal
{
    protected Feline(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    private string breed;

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}