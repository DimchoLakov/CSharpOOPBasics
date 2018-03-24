using System;

public class Cleric : Character, IHealable
{
    private static double DefaultHealth = 50;
    private static double DefaultArmor = 25;
    private static double DefaultAbilityPoints = 40;
    public Cleric(string name, Faction faction) : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Backpack(), faction)
    {
    }
    
    public void Heal(Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (this.Faction != character.Faction)
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }

        character.Health += this.AbilityPoints;
    }

    public override double RestHealMultiplier => 0.5;
}