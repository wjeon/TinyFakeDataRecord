using System.Collections.Generic;
using NUnit.Framework;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class FakeDataRecordsTests
    {
        [Test]
        public void When_create_FakeDataRecords_it_initializes_fake_data_records_with_object_arry_list()
        {
            var fakeDataRecords = new FakeDataRecords();
            var records = fakeDataRecords.ToList();
            Assert.That(records.GetType(), Is.EqualTo(typeof(List<object[]>)));
        }
    }
}
