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

        [TestCase(DataType.adInteger, DataTypeEnum.adInteger)]
        [TestCase(DataType.adBigInt, DataTypeEnum.adBigInt)]
        [TestCase(DataType.adDouble, DataTypeEnum.adDouble)]
        [TestCase(DataType.adVarChar, DataTypeEnum.adVarChar)]
        [TestCase(DataType.adDate, DataTypeEnum.adDate)]
        public void AdodbDataType_property_returns_adodb_data_type_that_is_converted_from_field_data_type(DataType dataType, DataTypeEnum adodbDataType)
        {
            var field = new Field("Test_Field", dataType);

            Assert.That(field.AdodbDataType, Is.EqualTo(adodbDataType));
        }
    }
}
