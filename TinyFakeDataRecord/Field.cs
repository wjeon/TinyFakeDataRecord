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
    }
}