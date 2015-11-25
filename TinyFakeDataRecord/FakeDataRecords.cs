using System.Collections.Generic;
using ADODB;

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
            ValidateData(records);
            _records = records;
        }

        public Recordset ToRecordSet()
        {
            var recordSet = new Recordset();
            return recordSet;
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
            ValidateData(row);

            _records.Add(row);
        }

        private void ValidateData(IEnumerable<object[]> records)
        {
            foreach (var row in records)
            {
                ValidateData(row);
            }
        }

        private void ValidateData(object[] row)
        {
            if (_metaData.Fields.Length != row.Length)
                throw new DataValidationException(string.Format(
                    "The number of fields ({0}) in the row not matched with the number of fields ({1}) in meta data",
                    row.Length, _metaData.Fields.Length
                ));

            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] != null && _metaData.Fields[i].Type != row[i].GetType())
                    throw new DataValidationException(string.Format(
                        "The type of the field ({0}) in the row not matched with the type of the field ({1}) in meta data",
                        row[i].GetType(), _metaData.Fields[i].Type
                    ));
            }
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