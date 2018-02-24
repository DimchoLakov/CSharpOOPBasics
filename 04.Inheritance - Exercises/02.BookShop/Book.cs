using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public string Title
    {
        get { return this.title; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get { return this.author; }
        private set
        {
            if (!IsAuthorLastNameValid(value))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public Book()
    {
    }

    public Book(string title, string author, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    private bool IsAuthorLastNameValid(string fullName)
    {
        string[] tokens = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
       
        if (tokens.Length > 1)
        {
            string lastName = tokens[1];
            if (char.IsDigit(lastName[0]))
            {
                return false;
            }
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        return sb.ToString().TrimEnd();
    }
}