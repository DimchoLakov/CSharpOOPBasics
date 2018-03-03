using System.Threading;

public class Animal
{
    public string Name { get; private set; }

    public string FavouriteFood { get; set; }

    public Animal()
    {
    }

    public Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    public virtual string ExplainSelf()
    {
        return null;
    }
}