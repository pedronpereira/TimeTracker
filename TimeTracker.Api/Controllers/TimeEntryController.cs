﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Entities;

namespace TimeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private static List<TimeEntry> _timeEntries = new List<TimeEntry>
        {
            new TimeEntry
            {
                Id = Guid.NewGuid().ToString(),
                Project = "Time Tracker App",
                End = DateTime.Now.AddHours(1),
            }
        };

        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAllTimeEntries()
        {
            return Ok(_timeEntries);
        }

        [HttpPost]
        public ActionResult<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
        {
            _timeEntries.Add(timeEntry);
            return Ok(_timeEntries);
        }
    }
}
