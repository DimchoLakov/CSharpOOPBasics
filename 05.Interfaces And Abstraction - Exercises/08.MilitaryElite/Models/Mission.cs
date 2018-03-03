using System.Text;

public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; private set; }
    public string State { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Code Name: {this.CodeName} State: {this.State}");
        return sb.ToString().Trim();
    }
}