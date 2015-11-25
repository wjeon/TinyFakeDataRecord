using System;
using ADODB;
using NUnit.Framework;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class FieldTests
    {
        [TestCase(DataType.adInteger, typeof(int))]
        [TestCase(DataType.adBigInt, typeof(long))]
        [TestCase(DataType.adDouble, typeof(double))]
        [TestCase(DataType.adVarChar, typeof(string))]
        [TestCase(DataType.adDate, typeof(DateTime))]
        public void Type_property_returns_dot_net_type_that_is_mapped_from_field_data_type(DataType dataType, Type type)
        {
            var field = new Field("Test_Field", dataType, 0, FieldAttributeEnum.adFldUnspecified);

            Assert.That(field.Type, Is.EqualTo(type));
        }
    }
}
