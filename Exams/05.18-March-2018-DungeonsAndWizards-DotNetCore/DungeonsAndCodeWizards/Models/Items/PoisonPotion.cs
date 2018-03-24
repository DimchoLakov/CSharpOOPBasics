using System;

public class PoisonPotion : Item
{
    private const int DefaultWeight = 5;
    public PoisonPotion() : base(DefaultWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        character.Health -= 20;
        if (character.Health <= 0)
        {
            character.IsAlive = false;
        }
    }
}