using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private int numberOfPlayers;
    private string name;
    private int rating;
    private List<Player> players;

    private int NumberOfPlayers
    {
        get { return this.numberOfPlayers; }
        set { this.numberOfPlayers = value; }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public int Rating
    {
        get { return this.rating =
            (int)Math.Round((this.Players.Sum(p => p.Endurance) +
                   this.Players.Sum(p => p.Sprint) +
                   this.Players.Sum(p => p.Dribble) +
                   this.Players.Sum(p => p.Passing) +
                   this.Players.Sum(p => p.Shooting)) / 5.0);
        }
        private set { this.rating = value; }
    }

    private List<Player> Players
    {
        get { return this.players; }
        set { this.players = value; }
    }

    public Team()
    {
        this.Players = new List<Player>();
    }

    public Team(string name) : this()
    {
        this.Name = name;
    }

    public void RemovePlayer(string playerName)
    {
        Player player = this.Players.FirstOrDefault(p => p.Name == playerName);
        if (player == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        this.Players.Remove(player);
    }

    public void AddPlayer(Player player)
    {
        this.Players.Add(player);
    }
}