using Microsoft.AspNetCore.Mvc;
using RecordKeeper.Entities;
using System;
using System.Collections.Generic;

namespace RecordKeeper.API.Controllers
{
    [Route("records")]
    public class RecordController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]Record record)
        {
            string filePath = @"C:\RecordFiles\file1.txt";

            RecordWriter recordWriter = new RecordWriter();
            bool success = recordWriter.Write(record, filePath);
            
            if(success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("email")]
        public IActionResult GetSortByEmail()
        {
            string input = @"C:\records-comma.txt,C:\records-piped.txt,C:\records-spaced.txt email-desc";
            return BuildRecordResponse(input);
        }

        [HttpGet]
        [Route("birthdate")]
        public IActionResult GetSortByBirthDate()
        {
            string input = @"C:\records-comma.txt,C:\records-piped.txt,C:\records-spaced.txt dateOfBirth-desc";
            return BuildRecordResponse(input);
        }

        [HttpGet]
        [Route("name")]
        public IActionResult GetSortByName()
        {
            string input = @"C:\records-comma.txt,C:\records-piped.txt,C:\records-spaced.txt lastName-desc,firstName-desc";
            return BuildRecordResponse(input);
        }

        #region Helper

        [NonAction]
        public IActionResult BuildRecordResponse(string input)
        {
            try
            {
                RecordProcessor recordProcessor = new RecordProcessor();
                List<Record> records = recordProcessor.Process(input);

                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}