using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("{id}")]
        public ActionResult<TimeEntryResponse> GetTimeEntry(Guid id)
        {
            var result = _timeEntryService.GetTimeEntryById(id);
            if (result is null)
            {
                return NotFound("TimeEntry with the given ID was not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest)
        {
            return Ok(_timeEntryService.CreateTimeEntry(timeEntryRequest));
        }

        [HttpPut("{id}")]
        public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryRequest)
        {
            var result = _timeEntryService.UpdateTimeEntry(id, timeEntryRequest);
            if (result is null)
            {
                return NotFound("TimeEntry with the given ID was not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TimeEntryResponse>> DeleteTimeEntry(Guid id)
        {
            var result = _timeEntryService.DeleteTimeEntry(id);
            if (result is null)
            {
                return NotFound("TimeEntry with the given ID was not found");
            }
            return Ok(result);
        }
    }
}
