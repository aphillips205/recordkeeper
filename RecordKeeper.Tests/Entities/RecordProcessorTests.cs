using RecordKeeper.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Record = RecordKeeper.Entities.Record;

namespace RecordKeeper.Tests.Entities
{
    public class RecordProcessorTests
    {
        [Fact]
        public void Process_Throws_ArgumentNullException_When_Input_Is_Null()
        {
            string input = null;

            RecordProcessor recordProcessor = new RecordProcessor();

            Assert.Throws<ArgumentNullException>(() => recordProcessor.Process(input));
        }

        [Fact]
        public void Process_Throws_ArgumentException_When_Input_Is_Invalid()
        {
            string input = @"C:\file.txt";

            RecordProcessor recordProcessor = new RecordProcessor();

            Assert.Throws<ArgumentException>(() => recordProcessor.Process(input));
        }

        [Fact]
        public void Process_Throws_FileNotFoundException_When_File_Is_Invalid()
        {
            string input = @"C:\file.txt email-desc";

            RecordProcessor recordProcessor = new RecordProcessor();

            Assert.Throws<FileNotFoundException>(() => recordProcessor.Process(input));
        }

        [Fact]
        public void Process_File_Success()
        {
            string input = @"C:\file1.txt email-desc";
            DateTime expectedDate = DateTime.Parse("12/11/2001");

            RecordProcessor recordProcessor = new RecordProcessor();

            List<Record> records = recordProcessor.Process(input);

            Assert.Equal("Scott", records[0].LastName);
            Assert.Equal("Gerry", records[0].FirstName);
            Assert.Equal("gerry.scott@gmail.com", records[0].Email);
            Assert.Equal("green", records[0].FavoriteColor);
            Assert.Equal(expectedDate, records[0].DateOfBirth);
        }
    }
}