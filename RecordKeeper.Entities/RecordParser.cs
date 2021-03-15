using System;
using System.Collections.Generic;

namespace RecordKeeper.Entities
{
    public class RecordParser
    {
        public Record Parse(string recordLine)
        {
            if (string.IsNullOrWhiteSpace(recordLine))
            {
                throw new ArgumentNullException("recordLine", "Recordline is required.");
            }

            string[] fields;
            if(recordLine.Contains("|"))
            {
                fields = recordLine.Split('|');
            }
            else if(recordLine.Contains(","))
            {
                fields = recordLine.Split(',');
            }
            else
            {
                fields = recordLine.Split(' ');
            }

            return new Record
            {
                LastName = CleanField(fields[0]),
                FirstName = CleanField(fields[1]),
                Email = CleanField(fields[2]),
                FavoriteColor = CleanField(fields[3]),
                DateOfBirth = DateTime.Parse(CleanField(fields[4]))
            };
        }

        private string CleanField(string field)
        {
            return string.IsNullOrWhiteSpace(field) ? string.Empty : field.Trim();
        }
    } 
}