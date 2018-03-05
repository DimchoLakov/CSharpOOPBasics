public abstract class Food
{
    private int quantity;

    public int Quanity
    {
        get { return this.quantity; }
        set { this.quantity = value; }
    }

    public Food(int quantity)
    {
        this.Quanity = quantity;
    }
}