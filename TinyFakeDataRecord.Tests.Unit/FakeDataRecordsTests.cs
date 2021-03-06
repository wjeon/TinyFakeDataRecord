﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using TinyFakeDataRecord.Tests.Unit.Extensions;

namespace TinyFakeDataRecord.Tests.Unit
{
    [TestFixture]
    public class FakeDataRecordsTests : FakeDataRecordsTestBase
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
            var fakeDataRecords = new FakeDataRecords(MetaData, FakeData);
            var records = fakeDataRecords.ToList();
            Assert.That(records, Is.EqualTo(FakeData));
        }

        [Test]
        public void ToArray_converts_the_object_array_list_data_to_2_dimensional_array_data()
        {
            var fakeDataRecords = new FakeDataRecords(MetaData, FakeData);
            var records = fakeDataRecords.ToArray();
            var fakeDataArray = new object[,]
                {
                    { 1, "First" },
                    { 2, "Second" }
                };
            Assert.That(records, Is.EqualTo(fakeDataArray));
        }

        [Test]
        public void AddRow_adds_single_fake_data_row()
        {
            var fakeDataRecords = new FakeDataRecords(MetaData);
            fakeDataRecords.AddRow(new object[] { 1, "First" });
            var records = fakeDataRecords.ToList();
            var fakeData = new List<object[]>
                {
                    new object[] { 1, "First" }
                };
            Assert.That(records, Is.EqualTo(fakeData));
        }

        [Test]
        public void When_number_of_fields_in_meta_data_and_number_of_fields_in_adding_row_not_matched_it_throws_DataValidationException()
        {
            var fakeDataRecords = new FakeDataRecords(MetaData);
            Assert.Throws<DataValidationException>(() => fakeDataRecords.AddRow(new object[] { 1 }));
        }

        [Test]
        public void When_type_of_field_in_meta_data_and_type_of_field_in_adding_row_not_matched_it_throws_DataValidationException()
        {
            var fakeDataRecords = new FakeDataRecords(MetaData);
            Assert.Throws<DataValidationException>(() => fakeDataRecords.AddRow(new object[] { 1, new DateTime(2015, 11, 25, 7, 37, 0) }));
        }

        [Test]
        public void When_construct_and_number_of_fields_in_meta_data_and_number_of_fields_in_passing_in_data_record_not_matched_it_throws_DataValidationException()
        {
            Assert.Throws<DataValidationException>(() => new FakeDataRecords(MetaData, new List<object[]> { new object[] { 1 } }));
        }

        [Test]
        public void When_construct_and_type_of_field_in_meta_data_and_type_of_field_in_passing_in_data_record_not_matched_it_throws_DataValidationException()
        {
            Assert.Throws<DataValidationException>(() => new FakeDataRecords(
                MetaData, new List<object[]> { new object[] { 1, new DateTime(2015, 11, 25, 7, 37, 0) } }
            ));
        }

        [Test]
        public void ToRecordSet_returns_adodb_recordset_of_the_fake_data_records()
        {
            var fakeDataRecords = new FakeDataRecords(MetaData, FakeData);
            var recordset = fakeDataRecords.ToRecordSet();

            var returnedData = new List<object[]>();

            do
            {
                returnedData.Add(new object[]
                    {
                        recordset.Fields["First_Field"].Value,
                        recordset.Fields["Second_Field"].Value
                    });

                recordset.MoveNext();

            } while (!recordset.EOF);

            Assert.That(returnedData, Is.EqualTo(FakeData));
        }

        [Test]
        public void ToDataReader_returns_DataReader_with_the_fake_data()
        {
            var fakeDataRecords = new FakeDataRecords(MetaData, FakeData);
            var result = new List<object[]>();

            using (var reader = fakeDataRecords.ToDataReader())
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
