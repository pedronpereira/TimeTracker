using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.Api.Services
{
    public interface ITimeEntryService
    {
        public List<TimeEntryResponse> GetAllTimeEntries();

        public List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest);

        public List<TimeEntryResponse>? UpdateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryRequest);
        public List<TimeEntryResponse>? DeleteTimeEntry(Guid id);
        public TimeEntryResponse? GetTimeEntryById(Guid id);
    }
}
