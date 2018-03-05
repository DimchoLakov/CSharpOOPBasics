public class FoodFactory
{
    public static Food GetFood(string[] foodTokens)
    {
        string foodType = foodTokens[0];
        int quantity = int.Parse(foodTokens[1]);

        switch (foodType)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Meat":
                return new Meat(quantity);
            case "Seeds":
                return new Seeds(quantity);
        }

        return null;
    }
}