using System.Collections.Generic;
using NUnit.Framework;
using TinyFakeDataRecord.Tests.Unit.Extensions;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class FakeDataReaderTests : FakeDataRecordsTestBase
    {
        [Test]
        public void Reads_data_from_FakeDataReader_successfully()
        {
            var result = new List<object[]>();

            using (var reader = new FakeDataReader(MetaData, FakeData))
            {
                while (reader.Read())
                {
                    result.Add(new object[]
                    {
                        reader.GetInt32(reader.GetOrdinal("First_Field")),
                        reader.GetString(reader.GetOrdinal("Second_Field"))
                    });
                }
            }

            Assert.IsTrue(result.IsSequenceObjectEqualTo(FakeData));
        }
    }
}
