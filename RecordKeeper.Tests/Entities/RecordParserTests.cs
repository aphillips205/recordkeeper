using RecordKeeper.Entities;
using System;
using Xunit;
using Record = RecordKeeper.Entities.Record;

namespace RecordKeeper.Tests.Entities
{
    public class RecordParserTests
    {
        [Fact]
        public void Parse_Throws_Exception_When_RecordLine_Is_Null()
        {
            string recordLine = null;

            RecordParser recordParser = new RecordParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.Parse(recordLine));
        }

        [Fact]
        public void Parse_Piped_File_Success()
        {
            string recordLine = "Givens | Mark | mark.givens@gmail.com | red | 3/12/2000";
            
            RecordParser recordParser = new RecordParser();

            Record record = recordParser.Parse(recordLine);

            Assert.Equal("Givens", record.LastName);
            Assert.Equal("Mark", record.FirstName);
            Assert.Equal("mark.givens@gmail.com", record.Email);
            Assert.Equal("red", record.FavoriteColor);
            Assert.Equal("3/12/2000", record.DateOfBirth.ToShortDateString());
        }

        [Fact]
        public void Parse_Comma_File_Success()
        {
            string recordLine = "Lewis, Pam, pam.lewis@gmail.com, blue, 4/21/1997";

            RecordParser recordParser = new RecordParser();

            Record record = recordParser.Parse(recordLine);

            Assert.Equal("Lewis", record.LastName);
            Assert.Equal("Pam", record.FirstName);
            Assert.Equal("pam.lewis@gmail.com", record.Email);
            Assert.Equal("blue", record.FavoriteColor);
            Assert.Equal("4/21/1997", record.DateOfBirth.ToShortDateString());
        }

        [Fact]
        public void Parse_Spaced_File_Success()
        {
            string recordLine = "Belle Kanisha kbelle@gmail.com green 6/12/1994";

            RecordParser recordParser = new RecordParser();

            Record record = recordParser.Parse(recordLine);

            Assert.Equal("Belle", record.LastName);
            Assert.Equal("Kanisha", record.FirstName);
            Assert.Equal("kbelle@gmail.com", record.Email);
            Assert.Equal("green", record.FavoriteColor);
            Assert.Equal("6/12/1994", record.DateOfBirth.ToShortDateString());
        }

        [Fact]
        public void Parse_Spaced_File_With_Empty_Field_Success()
        {
            string recordLine = "Belle Kanisha  green 6/12/1994";

            RecordParser recordParser = new RecordParser();

            Record record = recordParser.Parse(recordLine);

            Assert.Equal("Belle", record.LastName);
            Assert.Equal("Kanisha", record.FirstName);
            Assert.Equal(string.Empty, record.Email);
            Assert.Equal("green", record.FavoriteColor);
            Assert.Equal("6/12/1994", record.DateOfBirth.ToShortDateString());
        }
    }
}