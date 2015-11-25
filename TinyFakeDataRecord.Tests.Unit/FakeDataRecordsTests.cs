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

        [Test]
        public void When_pass_the_object_array_list_fake_data_in_the_constructor_it_creates_FakeDataRecords_with_the_passed_in_fake_data()
        {
            var metaData = new MetaData(new Field[] {});
            var fakeData = new List<object[]>
                {
                    new object[] { 1, "First" },
                    new object[] { 2, "Second" }
                };
            var fakeDataRecords = new FakeDataRecords(metaData, fakeData);
            var records = fakeDataRecords.ToList();
            Assert.That(records, Is.EqualTo(fakeData));
        }

        [Test]
        public void ToArray_converts_the_object_array_list_data_to_2_dimensional_array_data()
        {
            var metaData = new MetaData(new []
                {
                    new Field("First_Field", DataType.adInteger), 
                    new Field("Second_Field", DataType.adVarChar) 
                });
            var fakeData = new List<object[]>
                {
                    new object[] { 1, "First" },
                    new object[] { 2, "Second" }
                };
            var fakeDataRecords = new FakeDataRecords(metaData, fakeData);
            var records = fakeDataRecords.ToArray();
            var fakeDataArray = new object[,]
                {
                    { 1, "First" },
                    { 2, "Second" }
                };
            Assert.That(records, Is.EqualTo(fakeDataArray));
        }
    }
}
