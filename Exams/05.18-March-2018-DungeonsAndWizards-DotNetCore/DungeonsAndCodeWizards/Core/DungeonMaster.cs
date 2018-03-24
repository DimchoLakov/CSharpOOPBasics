using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private List<Character> partyList;
    private List<Item> itemsPool;
    private int rounds;

    public DungeonMaster()
    {
        this.partyList = new List<Character>();
        this.itemsPool = new List<Item>();
        this.rounds = 0;
    }

    public string JoinParty(string[] args)
    {
        string faction = args[0];
        string characterType = args[1];
        string name = args[2];

        CharacterFactory characterFactory = new CharacterFactory();
        Character character = characterFactory.CreateCharacter(faction, characterType, name);
        this.partyList.Add(character);

        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        string itemName = args[0];

        ItemFactory itemFactory = new ItemFactory();
        Item item = itemFactory.CreateItem(itemName);
        this.itemsPool.Add(item);

        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        string characterName = args[0];

        Character character = this.partyList.FirstOrDefault(c => c.Name == characterName);
        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        if (!this.itemsPool.Any())
        {
            throw new InvalidOperationException($"No items left in pool!");
        }

        Item item = this.itemsPool[this.itemsPool.Count - 1];

        character.ReceiveItem(item);
        this.itemsPool.RemoveAt(this.itemsPool.Count - 1);

        string itemName = item.GetType().Name;
        return $"{characterName} picked up {itemName}!";
    }

    public string UseItem(string[] args)
    {
        string characterName = args[0];
        string itemName = args[1];

        Character character = this.partyList.FirstOrDefault(c => c.Name == characterName);
        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        Item item = character.Bag.GetItem(itemName);
        character.UseItem(item);

        return $"{character.Name} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        Character giverCharacter = this.partyList.FirstOrDefault(c => c.Name == giverName);
        Character receiverCharacter = this.partyList.FirstOrDefault(c => c.Name == receiverName);

        if (giverCharacter == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }

        if (receiverCharacter == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        Item item = giverCharacter.Bag.GetItem(itemName);
        giverCharacter.UseItemOn(item, receiverCharacter);

        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        Character giverCharacter = this.partyList.FirstOrDefault(c => c.Name == giverName);
        Character receiverCharacter = this.partyList.FirstOrDefault(c => c.Name == receiverName);

        if (giverCharacter == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }

        if (receiverCharacter == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        Item item = giverCharacter.Bag.GetItem(itemName);
        giverCharacter.GiveCharacterItem(item, receiverCharacter);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        StringBuilder sb = new StringBuilder();

        var sortedPartyList = this.partyList
            .OrderByDescending(c => c.IsAlive)
            .ThenByDescending(c => c.Health)
            .ToList();

        foreach (Character character in sortedPartyList)
        {
            sb.AppendLine(character.ToString());
        }

        return sb.ToString().Trim();
    }

    public string Attack(string[] args)
    {
        string attackerName = args[0];
        string receiverName = args[1];

        Character attackerCharacter = this.partyList.FirstOrDefault(c => c.Name == attackerName);
        Character receiverCharacter = this.partyList.FirstOrDefault(c => c.Name == receiverName);

        if (attackerCharacter == null)
        {
            throw new ArgumentException($"Character {attackerName} not found!");
        }

        if (receiverCharacter == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        if (attackerCharacter is Cleric)
        {
            throw new ArgumentException($"{attackerName} cannot attack!");
        }

        Warrior attacker = (Warrior)attackerCharacter;
        attacker.Attack(receiverCharacter);

        string result = $"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! {receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!";

        if (!receiverCharacter.IsAlive)
        {
            result += Environment.NewLine + $"{receiverCharacter.Name} is dead!";
        }

        return result;
    }

    public string Heal(string[] args)
    {
        string healerName = args[0];
        string healingReceiverName = args[1];

        Character healer = this.partyList.FirstOrDefault(c => c.Name == healerName);
        Character healingReceiver = this.partyList.FirstOrDefault(c => c.Name == healingReceiverName);

        if (healer == null)
        {
            throw new ArgumentException($"Character {healerName} not found!");
        }

        if (healingReceiver == null)
        {
            throw new ArgumentException($"Character {healingReceiverName} not found!");
        }

        if (healer is Warrior)
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }

        Cleric cleric = (Cleric)healer;
        cleric.Heal(healingReceiver);

        return
            $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Character character in this.partyList.Where(c => c.IsAlive))
        {
            double healthBeforeRest = character.Health;
            character.Rest();
            sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
        }

        if (this.partyList.Count(c => c.IsAlive) <= 1)
        {
            this.rounds++;
        }

        if (this.rounds > 1)
        {
            this.IsGameOver();
        }

        return sb.ToString().Trim();
    }

    public bool IsGameOver()
    {
        if (this.rounds > 1)
        {
            return true;
        }

        return false;
    }
}