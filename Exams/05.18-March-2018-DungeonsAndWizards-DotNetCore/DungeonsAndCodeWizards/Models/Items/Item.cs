public abstract class Item
{
    public int Weight { get; protected set; }

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public abstract void AffectCharacter(Character character);
}