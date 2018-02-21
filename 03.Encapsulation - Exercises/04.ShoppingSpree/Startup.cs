using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        string[] peopleInputTokens = Console.ReadLine()
            .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        string[] productsInputTokens = Console.ReadLine()
            .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        List<Person> allPeople = new List<Person>();
        List<Product> allProducts = new List<Product>();

        foreach (string peopleInputToken in peopleInputTokens)
        {
            try
            {
                AddPeopleToList(allPeople, peopleInputToken);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
        }

        foreach (string productsInputToken in productsInputTokens)
        {
            try
            {
                AddProductsToList(allProducts, productsInputToken);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(0);
            }
        }

        string input = Console.ReadLine();

        while (!input.Equals("END"))
        {
            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string personName = tokens[0];
            string productName = tokens[1];

            Person person = allPeople.FirstOrDefault(p => p.Name.Equals(personName));
            Product product = allProducts.FirstOrDefault(p => p.Name.Equals(productName));
            try
            {
                person.BuyProduct(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            input = Console.ReadLine();
        }

        PrintPeopleAndTheirProducts(allPeople);
    }

    private static void AddProductsToList(List<Product> allProducts, string productsInputToken)
    {
        int index = productsInputToken.IndexOf("=");
        string name = productsInputToken.Substring(0, productsInputToken.Length - (productsInputToken.Length - index));
        string moneyAsStr = productsInputToken.Substring(index + 1, productsInputToken.Length - (index + 1));
        decimal cost =
            decimal.Parse(moneyAsStr);
        Product product = new Product(name, cost);
        allProducts.Add(product);
    }

    private static void AddPeopleToList(List<Person> allPeople, string peopleInputToken)
    {
        int index = peopleInputToken.IndexOf("=");
        string name = peopleInputToken.Substring(0, peopleInputToken.Length - (peopleInputToken.Length - index));
        string moneyAsStr = peopleInputToken.Substring(index + 1, peopleInputToken.Length - (index + 1));
        decimal money =
            decimal.Parse(moneyAsStr);
        Person person = new Person(name, money);
        allPeople.Add(person);
    }

    private static void PrintPeopleAndTheirProducts(List<Person> allPeople)
    {
        foreach (Person person in allPeople)
        {
            Console.WriteLine(person);
        }
    }
}