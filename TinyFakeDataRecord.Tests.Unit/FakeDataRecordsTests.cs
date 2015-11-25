using System.Collections.Generic;
using NUnit.Framework;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class FakeDataRecordsTests
    {
        [Test]
        public void When_create_FakeDataRecords_it_constructs_with_meta_data_and_initializes_fake_data_records_with_object_arry_list()
        {
            var metaData = new MetaData(new Field[] {});
            var fakeDataRecords = new FakeDataRecords(metaData);
            var records = fakeDataRecords.ToList();
            Assert.That(records.GetType(), Is.EqualTo(typeof(List<object[]>)));
        }
    }
}
