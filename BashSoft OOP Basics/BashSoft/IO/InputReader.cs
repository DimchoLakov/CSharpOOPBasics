using System;
using BashSoft.Static_data;

namespace BashSoft.IO
{
    public class InputReader
    {
        private const string endCommand = "quit";

        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.interpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine().Trim();
                if (input.Equals(endCommand))
                {
                    break;
                }
                if (string.IsNullOrEmpty(input))
                {
                    input = Console.ReadLine().Trim();
                    continue;
                }
                this.interpreter.InterpredCommand(input);
            }
        }
    }
}
