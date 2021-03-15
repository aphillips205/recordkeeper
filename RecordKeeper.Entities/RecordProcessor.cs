using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecordKeeper.Entities
{
    public class RecordProcessor
    {
        const string BothInputsRequired = "Both file path(s) and sort order(s) are required.";

        public List<Record> Process(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("input", BothInputsRequired);
            }

            string[] inputParts = input.Split(" ");

            if(inputParts.Length < 2)
            {
                throw new ArgumentException("input", BothInputsRequired);
            }

            string[] filePaths = inputParts[0].Split(",");
            string[] sortPatterns = inputParts[1].Split(",");

            List<Record> records = new List<Record>();
            foreach(string filePath in filePaths)
            {
                if(File.Exists(filePath))
                {
                    List<string> recordLines = File.ReadLines(filePath).ToList();
                    foreach (string recordLine in recordLines)
                    {
                        RecordParser recordParser = new RecordParser();
                        Record record = recordParser.Parse(recordLine);
                        records.Add(record);
                    }
                }
                else
                {
                    throw new FileNotFoundException($"File {filePath} was not found.");
                }
            }

            string firstSortPattern = sortPatterns.First();
            string[] remainingSortPatterns = sortPatterns.Where(pattern => pattern != sortPatterns.First()).ToArray();

            List<Record> orderedRecords = records.SortBy(firstSortPattern)
                                                 .ThenSortBy(remainingSortPatterns).ToList();

            return orderedRecords;
        }
    }
}