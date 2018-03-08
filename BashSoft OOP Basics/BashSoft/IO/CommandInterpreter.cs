using System;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO
{
    public class CommandInterpreter
    {
        private Tester tester;
        private StudentsRepository studentsRepository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repo, IOManager ioManager)
        {
            this.tester = judge;
            this.studentsRepository = repo;
            this.inputOutputManager = ioManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = data[0];

            try
            {
                Command command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception exception)
            {
                OutputWriter.DisplayException(exception.Message);
            }

        }

        private Command ParseCommand(string input, string[] data, string command)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "cdRel":
                    return new ChangeRelativePathCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "cdAbs":
                    return new ChangeAbsolutePathCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "readDb":
                    return new ReadDatabaseCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "show":
                    return new ShowCourseCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.tester, this.studentsRepository, this.inputOutputManager);
                //case "decOrder":
                //    break;
                //case "download":
                //    break;
                //case "downloadAsynch":
                //break;
                default:
                    throw new InvalidCommandException(command);
            }
        }

        /*private void TryDropbDb(string input, string[] data)
        {
            if (data.Length != 1)
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }

            this.studentsRepository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }*/

        /*private void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(courseName, filter, takeCommand, takeQuantity);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*private void TryParseParametersForOrderAndTake(string courseName, string filter, string takeCommand, string takeQuantity)
        {
            if (takeCommand.Equals("take"))
            {
                if (takeQuantity.Equals("all"))
                {
                    this.studentsRepository.OrderAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.studentsRepository.OrderAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }*/

        /*private void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(courseName, filter, takeCommand, takeQuantity);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*private void TryParseParametersForFilterAndTake(string courseName, string filter, string takeCommand, string takeQuantity)
        {
            if (takeCommand.Equals("take"))
            {
                if (takeQuantity.Equals("all"))
                {
                    this.studentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        this.studentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }*/

        /*void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                this.studentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string studentName = data[2];
                this.studentsRepository.GetStudentScoreFromCourse(courseName, studentName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*void TryGetHelp()
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdRel:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdAbs:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "drop students data base - dropdb"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }*/

        /*private void TryReadDatabaseFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                this.studentsRepository.LoadData(fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*private void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }*/

        /*private void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*private void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*private void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                this.tester.CompareContent(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }*/

        /*private void TryTraverseFolders(string input, string[] data)
        //{
        //    if (data.Length == 1)
        //    {
        //        this.inputOutputManager.TraverseDirectory(0);
        //    }
        //    else if (data.Length == 2)
        //    {
        //        int depth;
        //        bool hasParsed = int.TryParse(data[1], out depth);

        //        if (hasParsed)
        //        {
        //            this.inputOutputManager.TraverseDirectory(depth);
        //        }
        //        else
        //        {
        //            OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
        //        }
        //    }
        //    else
        //    {
        //        DisplayInvalidCommandMessage(input);
        //    }
        }*/

        /*private void TryCreateDirectory(string input, string[] data)
        //{
        //    if (data.Length == 2)
        //    {
        //        string folderName = data[1];
        //        this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        //    }
        //    else
        //    {
        //        DisplayInvalidCommandMessage(input);
        //    }
        }*/

        /*private void TryOpenFile(string input, string[] data)
        //{
        //    if (data.Length == 2)
        //    {
        //        string fileName = data[1];
        //        Process.Start(SessionData.currentPath + @"\" + fileName);
        //    }
        //    else
        //    {
        //        DisplayInvalidCommandMessage(input);
        //    }
        }*/
    }
}
