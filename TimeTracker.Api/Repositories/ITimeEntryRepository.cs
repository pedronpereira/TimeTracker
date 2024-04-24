using TimeTracker.Shared.Entities;

namespace TimeTracker.Api.Repositories
{
    public interface ITimeEntryRepository
    {
        List<TimeEntry> GetAllTimeEntries();
        TimeEntry? GetTimeEntryById(Guid id);
        List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
        List<TimeEntry>? UpdateTimeEntry(Guid id, TimeEntry timeEntry);
        List<TimeEntry>? DeleteTimeEntry(Guid id);
    }
}
