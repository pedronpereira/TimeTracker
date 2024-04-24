using TimeTracker.Shared.Entities;

namespace TimeTracker.Api.Repositories
{
    public interface ITimeEntryRepository
    {
        List<TimeEntry> GetAllTimeEntries();
        List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
    }
}
