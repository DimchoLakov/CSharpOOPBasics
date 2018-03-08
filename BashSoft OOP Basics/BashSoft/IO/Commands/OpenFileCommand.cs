using System.Diagnostics;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.Static_data;

namespace BashSoft.IO.Commands
{
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repo, IOManager ioManager) : base(input, data, judge, repo, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + @"\" + fileName);
        }
    }
}
