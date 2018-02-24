public class GoldenEditionBook : Book
{
    public override decimal Price
    {
        get { return base.Price * 1.3m; }
    }

    public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
    {
    }
}