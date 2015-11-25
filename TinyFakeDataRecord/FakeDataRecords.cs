using System.Collections.Generic;

namespace TinyFakeDataRecord
{
    public class FakeDataRecords
    {
        private readonly IList<object[]> _records;
        private readonly MetaData _metaData;

        public FakeDataRecords(MetaData metaData)
        {
            _metaData = metaData;
            _records = new List<object[]>();
        }

        public FakeDataRecords(MetaData metaData, IList<object[]> records)
        {
            _metaData = metaData;
            _records = records;
        }

        public IList<object[]> ToList()
        {
            return _records;
        }
    }
}