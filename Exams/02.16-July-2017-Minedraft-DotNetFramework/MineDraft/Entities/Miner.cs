public abstract class Miner
{
    private string id;

    public string Id
    {
        get { return this.id; }
        protected set { this.id = value; }
    }

    protected Miner(string id)
    {
        this.Id = id;
    }
}
