using System;
class StartUp
{
    static void Main()
    {
        string[] pizzaTokens = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string pizzaName = string.Empty;
        if (pizzaTokens.Length > 1)
        {
            pizzaName = pizzaTokens[1];
        }

        string[] doughTokens = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string doughType = doughTokens[1];
        string doughBakingTechnique = doughTokens[2];
        double doughWeight = double.Parse(doughTokens[3]);

        Pizza pizza;
        try
        {
            Dough dough = new Dough(doughType, doughBakingTechnique, doughWeight);
            pizza = new Pizza(pizzaName, dough);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return;
        }

        string inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            string[] tokens = inputLine
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string toppingType = tokens[1];
            double toppingWeight = double.Parse(tokens[2]);

            try
            {
                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            inputLine = Console.ReadLine();
        }

        Console.WriteLine(pizza);
    }
}