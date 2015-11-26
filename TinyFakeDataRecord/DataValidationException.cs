using System;

namespace TinyFakeDataRecord
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string message) : base(message)
        {
        }
    }
}