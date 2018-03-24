using System;

public class Warrior : Character, IAttackable
{
    private static double DefaultHealth = 100;
    private static double DefaultArmor = 50;
    private static double DefaultAbilityPoints = 40;
    public Warrior(string name, Faction faction) : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Satchel(), faction)
    {
    }
    public void Attack(Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (this.Name == character.Name)
        {
            throw new InvalidOperationException("Cannot attack self!");
        }

        if (this.Faction == character.Faction)
        {
            throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
        }

        character.TakeDamage(this.AbilityPoints);
    }
}