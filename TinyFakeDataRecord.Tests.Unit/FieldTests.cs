using ADODB;
using NUnit.Framework;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void Type_property_returns_dot_net_type_that_is_mapped_from_field_data_type()
        {
            var field = new Field("Test_Field", DataType.adInteger, 0, FieldAttributeEnum.adFldUnspecified);
        }
    }
}
