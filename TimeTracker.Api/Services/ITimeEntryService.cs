using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.Api.Services
{
    public interface ITimeEntryService
    {
        public List<TimeEntryResponse> GetAllTimeEntries();

        public List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest);
    }
}
