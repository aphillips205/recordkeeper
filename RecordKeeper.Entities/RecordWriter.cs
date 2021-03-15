using System;
using System.Collections.Generic;
using System.IO;

namespace RecordKeeper.Entities
{
    public class RecordWriter
    {
        public bool Write(Record record, string filePath)
        {
            if(record == null)
            {
                throw new ArgumentNullException("record", "Record is required.");
            }

            if(string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath", "File path is required.");
            }

            string recordLine = CreateRecordLine(record);
            List<string> contents = new List<string> { recordLine };

            try
            {
                File.AppendAllLines(filePath, contents);
            }
            catch(Exception ex)
            {
                throw new Exception("Writing record to the file failed.", ex);
            }            

            return true;
        }

        private string CreateRecordLine(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record", "Record is required.");
            }

            return $"{record.LastName} | {record.FirstName} | {record.Email} | {record.FavoriteColor} | {record.DateOfBirth.ToShortDateString()}";
        }
    }
}