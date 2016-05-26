using System.Collections.Generic;
using NUnit.Framework;

namespace TinyFakeDataRecord.Tests.Unit
{
    public class FakeDataRecordsTestBase
    {
        protected MetaData MetaData;
        protected List<object[]> FakeData;

        [SetUp]
        public void SetUp()
        {
            MetaData = new MetaData(new[]
                {
                    new Field("First_Field", DataType.adInteger), 
                    new Field("Second_Field", DataType.adVarChar, 2014) 
                });

            FakeData = new List<object[]>
                {
                    new object[] { 1, "First" },
                    new object[] { 2, "Second" }
                };
        }
    }
}