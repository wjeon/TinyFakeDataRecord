using System;
using System.Collections.Generic;
using System.Data;
using TinyFakeDataRecord.Extensions;

namespace TinyFakeDataRecord
{
    public class FakeDataReader : IDataReader
    {
        private readonly MetaData _metaData;
        private readonly IList<object[]> _records;
        private int _row = -1;
        private bool _isOpen = true;

        public FakeDataReader(MetaData metaData, IList<object[]> records)
        {
            _metaData = metaData;
            _records = records;
        }

        public int Depth
        {
            get { return 0; }
        }

        public bool IsClosed
        {
            get { return !_isOpen; }
        }

        public int RecordsAffected
        {
            get { return -1; }
        }

        public void Close()
        {
            _isOpen = false;
        }

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            return ++_row < _records.Count / _metaData.Fields.Length;
        }

        public DataTable GetSchemaTable()
        {
            throw new NotSupportedException();
        }

        public int FieldCount
        {
            get { return _metaData.Fields.Length; }
        }

        public string GetName(int i)
        {
            return _metaData.Fields[i].Name;
        }

        public string GetDataTypeName(int i)
        {
            return _metaData.Fields[i].DataType.ToString();
        }

        public Type GetFieldType(int i)
        {
            return _metaData.Fields[i].Type;
        }

        public object GetValue(int i)
        {
            return _records[_row][i];
        }

        public int GetValues(object[] values)
        {
            int i = 0, j = 0;
            for (; i < values.Length && j < _metaData.Fields.Length; i++, j++)
            {
                values[i] = _records[_row][j];
            }

            return i;
        }

        public int GetOrdinal(string name)
        {
            for (var i = 0; i < _metaData.Fields.Length; i++)
            {
                if (name.IsEqualTo(_metaData.Fields[i].Name))
                {
                    return i;
                }
            }

            throw new IndexOutOfRangeException("Could not find specified column in results");
        }

        public object this[int i]
        {
            get { return _records[_row][i]; }
        }

        public object this[string name]
        {
            get { return this[GetOrdinal(name)]; }
        }

        public bool GetBoolean(int i)
        {
            return (bool)_records[_row][i];
        }

        public byte GetByte(int i)
        {
            return (byte)_records[_row][i];
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException("GetBytes not supported.");
        }

        public char GetChar(int i)
        {
            return (char)_records[_row][i];
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException("GetChars not supported.");
        }

        public Guid GetGuid(int i)
        {
            return (Guid)_records[_row][i];
        }

        public short GetInt16(int i)
        {
            return (short)_records[_row][i];
        }

        public int GetInt32(int i)
        {
            return (int)_records[_row][i];
        }

        public long GetInt64(int i)
        {
            return (long)_records[_row][i];
        }

        public float GetFloat(int i)
        {
            return (float)_records[_row][i];
        }

        public double GetDouble(int i)
        {
            return (double)_records[_row][i];
        }

        public string GetString(int i)
        {
            return (string)_records[_row][i];
        }

        public decimal GetDecimal(int i)
        {
            return (decimal)_records[_row][i];
        }

        public DateTime GetDateTime(int i)
        {
            return (DateTime)_records[_row][i];
        }

        public IDataReader GetData(int i)
        {
            throw new NotSupportedException("GetData not supported.");
        }

        public bool IsDBNull(int i)
        {
            return _records[_row][i] == null || _records[_row][i] == DBNull.Value;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            try
            {
                Close();
            }
            catch (Exception e)
            {
                throw new SystemException("An exception of type " + e.GetType() +
                                          " was encountered while closing the TemplateDataReader.");
            }
        }
    }
}
