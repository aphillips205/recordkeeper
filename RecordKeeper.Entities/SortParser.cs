using System;
using System.Collections.Generic;

namespace RecordKeeper.Entities
{
    public class SortParser
    {
        public (string, string) Parse(string sortPattern)
        {
            if(string.IsNullOrWhiteSpace(sortPattern))
            {
                throw new ArgumentNullException("sorterPattern", "Sort pattern is required.");
            }

            Dictionary<string, string> sortPatterns = new Dictionary<string, string>();
            string[] parts = sortPattern.Split('-');
            if(parts.Length != 2)
            {
                throw new ArgumentException("Sort pattern is invalid");
            }

            string columnName = parts[0];
            string sortOrder = parts[1];
    
            return (columnName, sortOrder);
        }
    }
}