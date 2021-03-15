using System;
using System.Collections.Generic;
using System.Linq;

namespace RecordKeeper.Entities
{
    public static class RecordExtensions
    {
        public static IOrderedEnumerable<Record> SortBy(this List<Record> records, string sortPattern)
        {
            if(string.IsNullOrWhiteSpace(sortPattern))
            {
                throw new ArgumentNullException("sortPattern", "Sort pattern is required.");
            }

            IOrderedEnumerable<Record> orderedRecords = null;
            SortParser sortParser = new SortParser();
            (string, string) sortPatternItems = sortParser.Parse(sortPattern);
            string column = sortPatternItems.Item1;
            string sortOrder = sortPatternItems.Item2;
            if (column == "lastName")
            {
                orderedRecords = AddOrderByString(records, sortOrder, r => r.LastName);
            }
            if (column == "firstName")
            {
                orderedRecords = AddOrderByString(records, sortOrder, r => r.FirstName);
            }
            if (column == "email")
            {
                orderedRecords = AddOrderByString(records, sortOrder, r => r.Email);
            }
            if (column == "favoriteColor")
            {
                orderedRecords = AddOrderByString(records, sortOrder, r => r.FavoriteColor);
            }
            if (column == "dateOfBirth")
            {
                orderedRecords = AddOrderByDate(records, sortOrder, r => r.DateOfBirth);
            }

            return orderedRecords;
        }

        public static IOrderedEnumerable<Record> ThenSortBy(this IOrderedEnumerable<Record> orderedRecords, string[] sortPatterns)
        {
            for (var i = 0; i < sortPatterns.Length; i++)
            {
                SortParser sortParser = new SortParser();
                (string, string) sortOrder = sortParser.Parse(sortPatterns[i]);
                if (sortOrder.Item1 == "lastName")
                {
                    orderedRecords = AddThenByString(orderedRecords, sortOrder.Item1, r => r.LastName);
                }
                if (sortOrder.Item1 == "firstName")
                {
                    orderedRecords = AddThenByString(orderedRecords, sortOrder.Item1, r => r.FirstName);
                }
                if (sortOrder.Item1 == "email")
                {
                    orderedRecords = AddThenByString(orderedRecords, sortOrder.Item1, r => r.Email);
                }
                if (sortOrder.Item2 == "favoriteColor")
                {
                    orderedRecords = AddThenByString(orderedRecords, sortOrder.Item1, r => r.FavoriteColor);
                }
                if (sortOrder.Item2 == "dateOfBirth")
                {
                    orderedRecords = AddThenByDate(orderedRecords, sortOrder.Item1, r => r.DateOfBirth);
                }
            }

            return orderedRecords;
        }

        private static IOrderedEnumerable<Record> AddOrderByDate(List<Record> records, string sortOrder, Func<Record, DateTime> selector)
        {
            IOrderedEnumerable<Record> orderedRecords = null;
            if (sortOrder == "asc")
            {
                orderedRecords = records.OrderBy(selector);
            }
            else
            {
                orderedRecords = records.OrderByDescending(selector);
            }

            return orderedRecords;
        }

        private static IOrderedEnumerable<Record> AddOrderByString(List<Record> records, string sortOrder, Func<Record, string> selector)
        {
            IOrderedEnumerable<Record> orderedRecords = null;
            if (sortOrder == "asc")
            {
                orderedRecords = records.OrderBy(selector);
            }
            else
            {
                orderedRecords = records.OrderByDescending(selector);
            }

            return orderedRecords;
        }

        private static IOrderedEnumerable<Record> AddThenByString(IOrderedEnumerable<Record> orderedRecords, string sortOrder, Func<Record, string> selector)
        {
            if (sortOrder == "asc")
            {
                orderedRecords = orderedRecords.ThenBy(selector);
            }
            else
            {
                orderedRecords = orderedRecords.ThenByDescending(selector);
            }

            return orderedRecords;
        }

        private static IOrderedEnumerable<Record> AddThenByDate(IOrderedEnumerable<Record> orderedRecords, string sortOrder, Func<Record, DateTime> selector)
        {
            if (sortOrder == "asc")
            {
                orderedRecords = orderedRecords.ThenBy(selector);
            }
            else
            {
                orderedRecords = orderedRecords.ThenByDescending(selector);
            }

            return orderedRecords;
        }

    }
}