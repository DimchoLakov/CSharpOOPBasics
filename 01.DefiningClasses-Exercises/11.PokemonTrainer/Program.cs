using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Trainer> trainersDict = new Dictionary<string, Trainer>();

        string input = Console.ReadLine();

        while (!input.Equals("Tournament"))
        {
            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth = int.Parse(tokens[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainersDict.ContainsKey(trainerName))
            {
                Trainer trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);
                trainersDict.Add(trainerName, trainer);
            }
            else
            {
                trainersDict[trainerName].Pokemons.Add(pokemon);
            }

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            switch (input)
            {
                case "Fire":
                    CheckTrainersPokemons(trainersDict, input);
                    break;
                case "Electricity":
                    CheckTrainersPokemons(trainersDict, input);
                    break;
                case "Water":
                    CheckTrainersPokemons(trainersDict, input);
                    break;
            }
            input = Console.ReadLine();
        }

        Dictionary<string, Trainer> sortedDict = trainersDict
            .OrderByDescending(t => t.Value.Bagdes)
            .ToDictionary(k => k.Key, v => v.Value);

        foreach (KeyValuePair<string, Trainer> kvp in sortedDict)
        {
            Console.WriteLine($"{kvp.Key} {kvp.Value.Bagdes} {kvp.Value.Pokemons.Count}");
        }
    }

    private static void CheckTrainersPokemons(Dictionary<string, Trainer> trainersDict, string input)
    {
        foreach (KeyValuePair<string, Trainer> kvp in trainersDict)
        {
            if (trainersDict[kvp.Key].Pokemons.Any(p => p.Element == input))
            {
                trainersDict[kvp.Key].Bagdes++;
            }
            else
            {
                trainersDict[kvp.Key].Pokemons.Select(p => p.Health -= 10).ToList();
            }
        }

        trainersDict.Select(t => t.Value.Pokemons.RemoveAll(p => p.Health <= 0)).ToList();
    }
}
