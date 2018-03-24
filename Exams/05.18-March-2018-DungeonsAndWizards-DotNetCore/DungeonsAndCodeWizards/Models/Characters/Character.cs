using System;

public abstract class Character
{
    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
    }

    private string name;
    public string Name
    {
        get { return this.name; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            this.name = value;
        }
    }

    private double baseHealth;
    public double BaseHealth
    {
        get { return this.baseHealth; }
        protected set { this.baseHealth = value; }
    }

    private double health;
    public double Health
    {
        get { return this.health; }
        set
        {
            //this.health = Math.Min(value, this.BaseHealth);
            if (value <= 0)
            {
                this.health = 0;
            }
            else if (value > this.BaseHealth)
            {
                this.health = this.BaseHealth;
            }
            else
            {
                this.health = value;
            }
        }
    }

    private double baseArmor;
    public double BaseArmor
    {
        get { return this.baseArmor; }
        protected set { this.baseArmor = value; }
    }

    private double armor;
    public double Armor
    {
        get { return this.armor; }
        set
        {
            //this.armor = Math.Min(value, this.BaseArmor);
            if (value <= 0)
            {
                this.armor = 0;
            }
            else if (value > this.BaseArmor)
            {
                this.armor = this.BaseArmor;
            }
            else
            {
                this.armor = value;
            }
        }
    }

    public double AbilityPoints { get; protected set; }

    public Bag Bag { get; protected set; }

    public Faction Faction { get; protected set; }

    public bool IsAlive { get; set; }

    public virtual double RestHealMultiplier => 0.2;

    public void TakeDamage(double hitPoints)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        double diff = hitPoints - this.Armor;

        this.Armor -= hitPoints;
        if (this.Armor <= 0)
        {
            if (diff > 0)
            {
                this.Health -= diff;
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }
    }

    public void Rest()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        this.Health += this.BaseHealth * this.RestHealMultiplier;
    }

    public void UseItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        
        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        this.Bag.AddItem(item);
    }

    public override string ToString()
    {
        string status = this.IsAlive == true ? "Alive" : "Dead";
        return
            $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
    }
}