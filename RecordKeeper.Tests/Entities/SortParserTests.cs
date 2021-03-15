using RecordKeeper.Entities;
using System;
using Xunit;

namespace RecordKeeper.Tests.Entities
{
    public class SortParserTests
    {
        [Fact]
        public void Parse_Throws_ArgumentNullException_When_SortPattern_Is_Null()
        {
            string sortPattern = null;

            SortParser sortParser = new SortParser();

            Assert.Throws<ArgumentNullException>(() => sortParser.Parse(sortPattern));
        }

        [Fact]
        public void Parse_Throws_ArgumentException_When_SortPattern_Is_Invalid()
        {
            string sortPattern = "Email";

            SortParser sortParser = new SortParser();

            Assert.Throws<ArgumentException>(() => sortParser.Parse(sortPattern));
        }

        [Fact]
        public void Parse_Success()
        {
            string sortPattern = "Email-asc";

            SortParser sortParser = new SortParser();

            (string, string) result = sortParser.Parse(sortPattern);

            Assert.Equal("Email", result.Item1);
            Assert.Equal("asc", result.Item2);
        }
    }
}