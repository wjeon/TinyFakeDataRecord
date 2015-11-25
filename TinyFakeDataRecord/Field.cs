using System;
using ADODB;

namespace TinyFakeDataRecord
{
    public class Field
    {
        public Field(string name, DataType dataType, int defiendSize = 0, FieldAttributeEnum attribute = FieldAttributeEnum.adFldUnspecified)
        {
            Name = name;
            DataType = dataType;
            DefinedSize = defiendSize;
            Attribute = attribute;
        }

        public string Name { get; private set; }
        public DataType DataType { get; private set; }
        public int DefinedSize { get; private set; }
        public FieldAttributeEnum Attribute { get; private set; }

        public Type Type
        {
            get { return MapToType(DataType); }
        }

        public DataTypeEnum AdodbDataType
        {
            get { return ConvertToAdodbDataType(DataType); }
        }

        private static Type MapToType(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.adInteger:
                    return typeof(int);
                case DataType.adBigInt:
                    return typeof(long);
                case DataType.adDouble:
                    return typeof(double);
                case DataType.adVarChar:
                    return typeof(string);
                case DataType.adDate:
                    return typeof(DateTime);
                default:
                    throw new DataTypeNotMappedException(dataType);
            }
        }

        private static DataTypeEnum ConvertToAdodbDataType(DataType dataType)
        {
            return (DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), dataType.ToString());
        }
    }
}