using NUnit.Framework;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class MetaDataTests
    {
        [Test]
        public void Construct_MetaData_with_Field_array()
        {
            var fields = new []
                {
                    new Field("Test_Field_1", DataType.adInteger),
                    new Field("Test_Field_2", DataType.adVarChar)
                };
            var metaData = new MetaData(fields);

            Assert.That(metaData.Fields, Is.EqualTo(fields));
        }
    }
}
