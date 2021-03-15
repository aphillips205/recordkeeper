using Microsoft.AspNetCore.Mvc;
using RecordKeeper.API.Controllers;
using System;
using System.Collections.Generic;
using Xunit;
using Record = RecordKeeper.Entities.Record;

namespace RecordKeeper.Tests.API
{
    public class RecordControllerTests
    {
        [Fact]
        public void Post_Throws_Exception_When_Record_Is_Null()
        {
            Record record = null;

            var controller = new RecordController();
            Assert.Throws<ArgumentNullException>(() => controller.Post(record));
        }

        [Fact]
        public void Post_Success()
        {
            Record record = new Record
            {
                LastName = "Ford",
                FirstName = "Kim",
                Email = "kim.ford@gmail.com",
                FavoriteColor = "blue",
                DateOfBirth = DateTime.Parse("11/11/2021")
            };

            var controller = new RecordController();
            var result = controller.Post(record) as OkResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetSortByEmail_Success()
        {
            var controller = new RecordController();
            var result = controller.GetSortByEmail() as OkObjectResult;
            var records = result.Value as List<Record>;

            Assert.Equal(200, result.StatusCode);
            Assert.True(records.Count > 0);
        }

        [Fact]
        public void GetSortByBirthDate_Success()
        {
            var controller = new RecordController();
            var result = controller.GetSortByBirthDate() as OkObjectResult;
            var records = result.Value as List<Record>;

            Assert.Equal(200, result.StatusCode);
            Assert.True(records.Count > 0);
        }

        [Fact]
        public void GetSortByName_Success()
        {
            var controller = new RecordController();
            var result = controller.GetSortByName() as OkObjectResult;
            var records = result.Value as List<Record>;

            Assert.Equal(200, result.StatusCode);
            Assert.True(records.Count > 0);
        }
    }
}