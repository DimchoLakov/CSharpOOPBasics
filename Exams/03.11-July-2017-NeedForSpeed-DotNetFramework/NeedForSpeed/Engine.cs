using System;

public class Engine
{
    private CarManager carManager;

    public Engine(CarManager carManager)
    {
        this.carManager = carManager;
    }

    public void Start()
    {
        string input = Console.ReadLine();

        while (input != "Cops Are Here")
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];

            if (command == "open" && tokens.Length > 6)
            {
                this.carManager.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]), int.Parse(tokens[6]));
                input = Console.ReadLine();
                continue;
            }

            string result = string.Empty;

            switch (command)
            {
                case "register":
                    this.carManager.Register(int.Parse(tokens[1]), tokens[2], tokens[3], tokens[4], int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]), int.Parse(tokens[8]), int.Parse(tokens[9]));
                    break;
                case "check":
                    result = this.carManager.Check(int.Parse(tokens[1]));
                    break;
                case "open":
                    this.carManager.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]));
                    break;
                case "participate":
                    this.carManager.Participate(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "start":
                    result = this.carManager.Start(int.Parse(tokens[1]));
                    break;
                case "park":
                    this.carManager.Park(int.Parse(tokens[1]));
                    break;
                case "unpark":
                    this.carManager.Unpark(int.Parse(tokens[1]));
                    break;
                case "tune":
                    this.carManager.Tune(int.Parse(tokens[1]), tokens[2]);
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }

            input = Console.ReadLine();
        }
    }
}