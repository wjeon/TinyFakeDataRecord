using System.Collections.Generic;

namespace TinyFakeDataRecord
{
    public class FakeDataRecords
    {
        private readonly List<object[]> _records;

        public FakeDataRecords()
        {
            _records = new List<object[]>();
        }

        public List<object[]> ToList()
        {
            return _records;
        }
    }
}