using System;

public class PriceCalculator
{
    public static decimal CalculatePrice(string entry)
    {
        string[] tokens = entry.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        decimal pricePerDay = decimal.Parse(tokens[0]);
        int numberOfDays = int.Parse(tokens[1]);
        var season = Enum.Parse<SeasonEnum>(tokens[2]);
        DiscountEnum discount = DiscountEnum.None;
        if (tokens.Length > 3)
        {
            discount = Enum.Parse<DiscountEnum>(tokens[3]);
        }

        decimal discountPrice = (pricePerDay * numberOfDays * (int) season * (decimal)discount) / 100m;
        decimal finalPrice = (pricePerDay * (int)season) * numberOfDays - discountPrice;

        return finalPrice;
    }
}