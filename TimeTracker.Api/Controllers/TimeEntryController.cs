﻿using Microsoft.AspNetCore.Mvc;


namespace TimeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryService _timeEntryService;

        public TimeEntryController(ITimeEntryService service)
        {
            _timeEntryService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeEntryResponse>>> GetAllTimeEntries()
        {
            return Ok(await _timeEntryService.GetAllTimeEntries());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntryResponse>> GetTimeEntry(Guid id)
        {
            var result = await _timeEntryService.GetTimeEntryById(id);
            if (result is null)
            {
                return NotFound("TimeEntry with the given ID was not found");
            }
            return Ok(result);
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<TimeEntryByProjectResponse>>> GetTimeEntriesByProject(Guid projectId)
        {
            return Ok(await _timeEntryService.GetTimeEntriesByProject(projectId));
        }

        [HttpPost]
        public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest)
        {
            return Ok(await _timeEntryService.CreateTimeEntry(timeEntryRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TimeEntryResponse>>> UpdateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryRequest)
        {
            var result = await _timeEntryService.UpdateTimeEntry(id, timeEntryRequest);
            if (result is null)
            {
                return NotFound("TimeEntry with the given ID was not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TimeEntryResponse>>> DeleteTimeEntry(Guid id)
        {
            var result = await _timeEntryService.DeleteTimeEntry(id);
            if (result is null)
            {
                return NotFound("TimeEntry with the given ID was not found");
            }
            return Ok(result);
        }
    }
}
