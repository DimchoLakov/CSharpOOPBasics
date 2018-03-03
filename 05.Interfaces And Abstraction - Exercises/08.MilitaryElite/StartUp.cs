using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        ICollection<ISoldier> allSoldiers = new List<ISoldier>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            AddSoldiers(allSoldiers, tokens);

            input = Console.ReadLine();
        }

        PrintSoldiers(allSoldiers);
    }

    private static void PrintSoldiers(ICollection<ISoldier> allSoldiers)
    {
        foreach (ISoldier soldier in allSoldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void AddSoldiers(ICollection<ISoldier> allSoldiers, string[] tokens)
    {
        string type = tokens[0];
        int id = int.Parse(tokens[1]);
        string firstName = tokens[2];
        string lastName = tokens[3];
        double salary = double.Parse(tokens[4]);

        switch (type)
        {
            case "Private":

                Private privateSoldier = new Private(id, firstName, lastName, salary);
                allSoldiers.Add(privateSoldier);
                break;
            case "LeutenantGeneral":
                List<Private> privates = GetPrivateSoldiers(allSoldiers, tokens);
                LeutenantGeneral leutenant = new LeutenantGeneral(id, firstName, lastName, salary, privates);
                if (leutenant != null)
                {
                    allSoldiers.Add(leutenant);
                }
                break;
            case "Engineer":
                if (AreCorpsValid(tokens))
                {
                    string corps = tokens[5];
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, GetRepairs(tokens));
                    allSoldiers.Add(engineer);
                }
                break;
            case "Commando":
                if (AreCorpsValid(tokens))
                {
                    string corps = tokens[5];
                    Commando commando = new Commando(id, firstName, lastName, salary, corps, GetMissions(tokens));
                    allSoldiers.Add(commando);
                }
                break;
            case "Spy":
                int codeNumber = int.Parse(tokens[4]);
                Spy spy = new Spy(id, firstName, lastName, codeNumber);
                allSoldiers.Add(spy);
                break;
        }
    }

    private static List<Private> GetPrivateSoldiers(ICollection<ISoldier> allSoldiers, string[] tokens)
    {
        List<Private> privates = new List<Private>();
        for (int i = 5; i < tokens.Length; i++)
        {
            Private prSoldier = (Private)allSoldiers.FirstOrDefault(s => s.Id == int.Parse(tokens[i]));
            privates.Add(prSoldier);
        }

        return privates;
    }

    private static List<IMission> GetMissions(string[] tokens)
    {
        List<IMission> missions = new List<IMission>();
        for (int i = 6; i < tokens.Length; i += 2)
        {
            string missionCode = tokens[i];
            string missionState = tokens[i + 1];
            if (missionState == "inProgress" || missionState == "Finished")
            {
                Mission mission = new Mission(missionCode, missionState);
                missions.Add(mission);
            }
        }

        return missions;
    }

    private static bool AreCorpsValid(string[] corpsParams)
    {
        if (corpsParams.Any(c => c == "Airforces" || c == "Marines"))
        {
            return true;
        }

        return false;
    }

    private static List<IRepair> GetRepairs(string[] tokens)
    {
        List<IRepair> repairs = new List<IRepair>();
        for (int i = 6; i < tokens.Length; i += 2)
        {
            string partName = tokens[i];
            int hours = int.Parse(tokens[i + 1]);
            Repair repair = new Repair(partName, hours);
            repairs.Add(repair);
        }
        return repairs;
    }
}