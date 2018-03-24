using System;

public class ItemFactory
{
    public Item CreateItem(string itemName)
    {
        switch (itemName)
        {
            case nameof(HealthPotion):
                return new HealthPotion();
            case nameof(PoisonPotion):
                return new PoisonPotion();
            case nameof(ArmorRepairKit):
                return new ArmorRepairKit();
            default:
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
        }
    }
}