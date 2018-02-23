using System;
using System.Collections.Generic;
public class RandomList : List<string>
{
    private RandomList list;

    private RandomList List
    {
        get { return this.list; }
        set { this.list = value; }
    }

    public RandomList()
    {
    }

    public string RandomString(RandomList rndList)
    {
        Random rnd = new Random();

        int randomIndex = rnd.Next(0, rndList.Count);
        string str = rndList[randomIndex];
        rndList.Remove(str);
        return str;
    }
}