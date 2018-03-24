using System;

public class HealthPotion : Item
{
    private const int DefaultWeight = 5;
    public HealthPotion() : base(DefaultWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        character.Health += 20;
    }
}