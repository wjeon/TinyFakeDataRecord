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

        public object[,] ToArray()
        {
            return ConvertToArray(_records);
        }

        public IList<object[]> ToList()
        {
            return _records;
        }

        public void AddRow(object[] row)
        {
            _records.Add(row);
        }

        private object[,] ConvertToArray(IList<object[]> records)
        {
            var convertedRecords = new object[records.Count, _metaData.Fields.Length];

            for (var i = 0; i < records.Count; i++)
            {
                for (var j = 0; j < _metaData.Fields.Length; j++)
                {
                    convertedRecords[i, j] = records[i][j];
                }
            }

            return convertedRecords;
        }
    }
}