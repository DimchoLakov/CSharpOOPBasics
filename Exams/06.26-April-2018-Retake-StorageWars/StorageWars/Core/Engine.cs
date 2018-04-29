using System;
using System.Linq;

public class Engine
{
    private StorageMaster.Core.StorageMaster storageMaster;

    public Engine(StorageMaster.Core.StorageMaster storageMaster)
    {
        this.storageMaster = storageMaster;
    }

    public void Run()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            try
            {
                string result = ProcessCommand(input);
                Console.WriteLine(result);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine($"Error: {ioe.Message}");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(this.storageMaster.GetSummary());
    }

    private string ProcessCommand(string input)
    {
        string[] tokens = input.Split();

        string command = tokens[0];

        tokens = tokens.Skip(1).ToArray();

        string result = string.Empty;

        switch (command)
        {
            case "AddProduct":
                result = this.storageMaster.AddProduct(tokens[0], double.Parse(tokens[1]));
                break;
            case "RegisterStorage":
                result = this.storageMaster.RegisterStorage(tokens[0], tokens[1]);
                break;
            case "SelectVehicle":
                result = this.storageMaster.SelectVehicle(tokens[0], int.Parse(tokens[1]));
                break;
            case "LoadVehicle":
                result = this.storageMaster.LoadVehicle(tokens);
                break;
            case "SendVehicleTo":
                result = this.storageMaster.SendVehicleTo(tokens[0], int.Parse(tokens[1]), tokens[2]);
                break;
            case "UnloadVehicle":
                result = this.storageMaster.UnloadVehicle(tokens[0], int.Parse(tokens[1]));
                break;
            case "GetStorageStatus":
                result = this.storageMaster.GetStorageStatus(tokens[0]);
                break;
        }

        return result;
    }
}