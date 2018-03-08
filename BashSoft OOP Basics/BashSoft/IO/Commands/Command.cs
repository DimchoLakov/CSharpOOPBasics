using System;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository studentRepo;
        private IOManager ioManager;

        public string Input
        {
            get { return this.input; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public Tester Judge
        {
            get { return this.judge; }
        }

        public StudentsRepository StudentsRepo
        {
            get { return this.studentRepo; }
        }

        public IOManager IOManager
        {
            get { return this.ioManager; }
        }

        public Command(string input, string[] data, Tester judge, StudentsRepository repo, IOManager ioManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.studentRepo = repo;
            this.ioManager = ioManager;
        }

        public abstract void Execute();
    }
}
