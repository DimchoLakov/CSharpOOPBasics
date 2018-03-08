using System;

namespace BashSoft.Exceptions
{
    public class DataAlreadyInitialisedException : Exception
    {
        public const string DataAlreadyInitialisedExc = "Data is already intialized!";

        public DataAlreadyInitialisedException() : base(DataAlreadyInitialisedExc)
        {
        }

        public DataAlreadyInitialisedException(string message) : base(message)
        {
        }
    }
}
