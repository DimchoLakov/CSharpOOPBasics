using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> members;

    public List<Person> Members
    {
        get { return this.members; }
    }

    public Family()
    {
        this.members = new List<Person>();
    }

    public void AddMember(Person person)
    {
        this.members.Add(person);
    }

    public Person GetOldestMember()
    {
        return Members.OrderByDescending(a => a.Age).First();
    }
}
