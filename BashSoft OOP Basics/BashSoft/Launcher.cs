using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.Static_data;

namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository studentsRepository = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            CommandInterpreter interpreter = new CommandInterpreter(tester, studentsRepository, ioManager);
            InputReader reader = new InputReader(interpreter);
            
            reader.StartReadingCommands();  // type 'help' to get help
        }
    }
}
