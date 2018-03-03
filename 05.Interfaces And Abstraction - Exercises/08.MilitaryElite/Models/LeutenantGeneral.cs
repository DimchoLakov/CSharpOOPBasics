using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<Private> privates) :
        base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public List<Private> Privates { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Privates:");
        foreach (var privateSoldier in this.Privates)
        {
            sb.AppendLine("  " + privateSoldier);
        }

        return sb.ToString().Trim();
    }
}