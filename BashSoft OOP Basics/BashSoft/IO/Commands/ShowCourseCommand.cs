using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class ShowCourseCommand : Command
    {
        public ShowCourseCommand(string input, string[] data, Tester judge, StudentsRepository repo, IOManager ioManager) : base(input, data, judge, repo, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.StudentsRepo.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string studentName = this.Data[2];
                this.StudentsRepo.GetStudentScoreFromCourse(courseName, studentName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
