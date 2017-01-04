using System;

namespace TinyFakeDataRecord
{
    public class ReaderClosedException : Exception
    {
        public ReaderClosedException(string message) : base(message)
        {
        }
    }
}