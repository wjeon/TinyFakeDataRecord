using System;

namespace TinyFakeDataRecord
{
    public class DataTypeNotMappedException : Exception
    {
        public DataTypeNotMappedException(DataType dataType)
            : base(string.Format("The data type {0} is not mapped to any type", dataType))
        {
        }
    }
}