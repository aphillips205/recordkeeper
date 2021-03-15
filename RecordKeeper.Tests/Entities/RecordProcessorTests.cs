using RecordKeeper.Entities;
using System;
using System.IO;
using Xunit;

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
            string input = "file.txt";

            RecordProcessor recordProcessor = new RecordProcessor();

            Assert.Throws<ArgumentException>(() => recordProcessor.Process(input));
        }

        [Fact]
        public void Process_Throws_FileNotFoundException_When_File_Is_Invalid()
        {
            string input = "file.txt email-desc";

            RecordProcessor recordProcessor = new RecordProcessor();

            Assert.Throws<FileNotFoundException>(() => recordProcessor.Process(input));
        }

        [Fact]
        public void Process_File_Success()
        {
            string input = "file1.txt email-desc";
            string expectedOutput = "Scott, Gerry, gerry.scott@gmail.com, green, 12/11/2001\r\n";

            RecordProcessor recordProcessor = new RecordProcessor();

            string output = recordProcessor.Process(input);

            Assert.Equal(expectedOutput, output);
        }
    }
}