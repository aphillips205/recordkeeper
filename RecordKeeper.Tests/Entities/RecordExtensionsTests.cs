using RecordKeeper.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Record = RecordKeeper.Entities.Record;

namespace RecordKeeper.Tests.Entities
{
    public class RecordExtensionsTests
    {
        [Fact]
        public void SortBy_Throws_ArgumentNullException_When_SortPattern_Is_Null()
        {
            string sortPattern = null;
            List<Record> records = new List<Record>();           

            Assert.Throws<ArgumentNullException>(() => RecordExtensions.SortBy(records, sortPattern));
        }

        #region SortBy Tests

        [Fact]
        public void SortBy_LastName_Success()
        {
            string sortPattern = "lastName-desc";
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, sortPattern).ToList();

            Assert.Equal("Parker", orderedRecords[0].LastName);
        }

        [Fact]
        public void SortBy_FirstName_Success()
        {
            string sortPattern = "firstName-asc";
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, sortPattern).ToList();

            Assert.Equal("Brenda", orderedRecords[0].FirstName);
        }

        [Fact]
        public void SortBy_Email_Success()
        {
            string sortPattern = "email-desc";
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, sortPattern).ToList();

            Assert.Equal("tom.parker@gmail.com", orderedRecords[0].Email);
        }

        [Fact]
        public void SortBy_FavoriteColor_Success()
        {
            string sortPattern = "favoriteColor-asc";
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, sortPattern).ToList();

            Assert.Equal("blue", orderedRecords[0].FavoriteColor);
        }

        [Fact]
        public void SortBy_DateOfBirth_Success()
        {
            string sortPattern = "dateOfBirth-desc";
            List<Record> records = CreateRecords();
            DateTime expectedDateOfBirth = DateTime.Parse("4/1/2021");

            List<Record> orderedRecords = RecordExtensions.SortBy(records, sortPattern).ToList();

            Assert.Equal(expectedDateOfBirth, orderedRecords[0].DateOfBirth);
        }

        #endregion

        #region ThenSortBy Tests

        [Fact]
        public void ThenSortBy_LastName_Success()
        {
            string firstSortPattern = "email-desc";
            string[] remainingSortPatterns = new List<string>
            {
                "lastName-asc"
            }.ToArray();
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, firstSortPattern)
                                                          .ThenSortBy(remainingSortPatterns)
                                                          .ToList();

            Assert.Equal("Parker", orderedRecords[0].LastName);
        }

        [Fact]
        public void ThenSortBy_FirstName_Success()
        {
            string firstSortPattern = "email-desc";
            string[] remainingSortPatterns = new List<string>
            {
                "lastName-asc"
            }.ToArray();
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, firstSortPattern)
                                                          .ThenSortBy(remainingSortPatterns)
                                                          .ToList();

            Assert.Equal("Parker", orderedRecords[0].LastName);
        }

        [Fact]
        public void ThenSortBy_Email_Success()
        {
            string firstSortPattern = "email-desc";
            string[] remainingSortPatterns = new List<string>
            {
                "lastName-asc"
            }.ToArray();
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, firstSortPattern)
                                                          .ThenSortBy(remainingSortPatterns)
                                                          .ToList();

            Assert.Equal("Parker", orderedRecords[0].LastName);
        }

        [Fact]
        public void ThenSortBy_FavoriteColor_Success()
        {
            string firstSortPattern = "email-desc";
            string[] remainingSortPatterns = new List<string>
            {
                "lastName-asc"
            }.ToArray();
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, firstSortPattern)
                                                          .ThenSortBy(remainingSortPatterns)
                                                          .ToList();

            Assert.Equal("Parker", orderedRecords[0].LastName);
        }

        [Fact]
        public void ThenSortBy_DateOfBirth_Success()
        {
            string firstSortPattern = "email-desc";
            string[] remainingSortPatterns = new List<string>
            {
                "lastName-asc"
            }.ToArray();
            List<Record> records = CreateRecords();

            List<Record> orderedRecords = RecordExtensions.SortBy(records, firstSortPattern)
                                                          .ThenSortBy(remainingSortPatterns)
                                                          .ToList();

            Assert.Equal("Parker", orderedRecords[0].LastName);
        }

        #endregion 

        #region Helpers

        private List<Record> CreateRecords()
        {
            List<Record> records = new List<Record>
            {
                new Record
                {
                    LastName = "Parker",
                    FirstName = "Tom",
                    Email = "tom.parker@gmail.com",
                    FavoriteColor = "red",
                    DateOfBirth = DateTime.Parse("3/12/2020")
                },
                new Record
                {
                    LastName = "Adams",
                    FirstName = "Brenda",
                    Email = "brenda.adams@gmail.com",
                    FavoriteColor = "blue",
                    DateOfBirth = DateTime.Parse("4/1/2021")
                },
            };

            return records;
        }

        #endregion
    }
}