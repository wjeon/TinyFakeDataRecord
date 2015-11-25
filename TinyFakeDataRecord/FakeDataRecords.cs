using System.Collections.Generic;

namespace TinyFakeDataRecord
{
    public class FakeDataRecords
    {
        private readonly List<object[]> _records;
        private readonly MetaData _metaData;

        public FakeDataRecords(MetaData metaData)
        {
            _metaData = metaData;
            _records = new List<object[]>();
        }

        public List<object[]> ToList()
        {
            return _records;
        }
    }
}