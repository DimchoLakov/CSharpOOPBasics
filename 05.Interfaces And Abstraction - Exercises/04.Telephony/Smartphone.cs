using System;
using System.Collections.Generic;
using System.Linq;

public class Smartphone : ICall, IBrowse
{
    private List<string> numbers;
    private List<string> sites;

    public List<string> Numbers
    {
        get { return this.numbers; }
        set { this.numbers = value; }
    }

    public List<string> Sites
    {
        get { return this.sites; }
        set { this.sites = value; }
    }

    public Smartphone()
    {
        this.Sites = new List<string>();
        this.Numbers = new List<string>();
    }

    public string Call(string number)
    {
        if (!IsNumberValid(number))
        {
            throw new ArgumentException("Invalid number!");
        }
        return $"Calling... {number}";
    }

    public string Browse(string url)
    {
        if (!IsUrlValid(url))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {url}!";
    }

    private bool IsNumberValid(string number)
    {
        return number.Any(n => char.IsDigit(n));
    }

    public bool IsUrlValid(string url)
    {
        return !url.Any(n => char.IsDigit(n));
    }
}