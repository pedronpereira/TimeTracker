using Microsoft.AspNetCore.Mvc;
using TimeTracker.Api.Repositories;
using TimeTracker.Api.Services;
using TimeTracker.Shared.Models.TimeEntry;

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
        public ActionResult<List<TimeEntryResponse>> GetAllTimeEntries()
        {
            return Ok(_timeEntryService.GetAllTimeEntries());
        }

        [HttpPost]
        public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest)
        {
            return Ok(_timeEntryService.CreateTimeEntry(timeEntryRequest));
        }
    }
}
