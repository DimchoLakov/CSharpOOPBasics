using System;

public class ArmorRepairKit : Item
{
    private const int DefaultWeight = 10;

    public ArmorRepairKit() : base(DefaultWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        character.Armor = character.BaseArmor;
    }
}