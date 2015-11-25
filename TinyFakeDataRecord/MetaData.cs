namespace TinyFakeDataRecord
{
    public class MetaData
    {
        public MetaData(Field[] fields)
        {
            Fields = fields;
        }
        public Field[] Fields { get; private set; }
    }
}