using System;

public class CharacterFactory
{
    public Character CreateCharacter(string factionToString, string characterType, string name)
    {
        Faction faction;

        if (!Enum.TryParse(factionToString, out faction))
        {
            throw new ArgumentException($"Invalid faction \"{factionToString}\"!");
        }

        switch (characterType)
        {
            case "Warrior":
                return new Warrior(name, faction);
            case "Cleric":
                return new Cleric(name, faction);
            default:
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
        }
    }
}