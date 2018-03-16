using System.Text;

public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; protected set; }

    public abstract int Affinity { get; set; }

    public override string ToString()
    {
        string monumentFullType = this.GetType().Name;
        string type = monumentFullType.Substring(0, monumentFullType.LastIndexOf('M'));

        return $"{type} Monument: {this.Name}, {type} Affinity: ";
    }
}