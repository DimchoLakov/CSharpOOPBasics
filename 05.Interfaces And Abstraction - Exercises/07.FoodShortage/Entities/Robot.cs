public class Robot : IIdentifyable
{
    public string Model { get; private set; }

    public string Id { get; private set; }

    public Robot()
    {
    }

    public Robot(string model, string id) : this()
    {
        this.Model = model;
        this.Id = id;
    }
}