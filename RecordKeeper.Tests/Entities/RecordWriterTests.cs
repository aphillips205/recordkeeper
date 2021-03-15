using RecordKeeper.Entities;
using System;
using Xunit;
using Record = RecordKeeper.Entities.Record;

namespace RecordKeeper.Tests.Entities
{
    public class RecordWriterTests
    {
        [Fact]
        public void Write_Throws_ArgumentNullException_When_Record_Is_Null()
        {
            Record record = null;
            string filePath = null;

            RecordWriter recordWriter = new RecordWriter();

            Assert.Throws<ArgumentNullException>(() => recordWriter.Write(record, filePath));
        }

        [Fact]
        public void Write_Throws_ArgumentNullException_When_FilePath_Is_Null()
        {
            Record record = new Record();
            string filePath = null;

            RecordWriter recordWriter = new RecordWriter();

            Assert.Throws<ArgumentNullException>(() => recordWriter.Write(record, filePath));
        }

        [Fact]
        public void Write_Record_To_File1_Success()
        {
            Record record = new Record
            {
                LastName = "Ford",
                FirstName = "Kim",
                Email = "kim.ford@gmail.com",
                FavoriteColor = "blue",
                DateOfBirth = DateTime.Parse("11/11/2021")
            };
            string filePath = @"file1.txt";

            RecordWriter recordWriter = new RecordWriter();

            bool success = recordWriter.Write(record, filePath);

            Assert.True(success);
        }
    }
}