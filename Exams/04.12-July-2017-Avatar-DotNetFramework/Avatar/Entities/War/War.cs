using System.Collections.Generic;
using System.Text;

public class War
{
    public War()
    {
        this.WarRecords = new List<string>();
    }

    public List<string> WarRecords { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        int warNumber = 1;

        foreach (string warRecord in this.WarRecords)
        {
            sb.AppendLine($"War {warNumber} issued by {warRecord}");
            warNumber++;
        }

        return sb.ToString().Trim();
    }
}