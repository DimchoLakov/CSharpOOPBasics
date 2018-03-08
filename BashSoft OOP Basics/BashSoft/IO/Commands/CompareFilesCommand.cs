using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester judge, StudentsRepository repo, IOManager ioManager) : base(input, data, judge, repo, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 3)
            {
                string firstPath = this.Data[1];
                string secondPath = this.Data[2];

                this.Judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
