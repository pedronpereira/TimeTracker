namespace TimeTracker.Api.Repositories
{
    public interface ITimeEntryRepository
    {
        Task<List<TimeEntry>> GetAllTimeEntries();
        Task<TimeEntry?> GetTimeEntryById(Guid id);
        Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
        List<TimeEntry>? UpdateTimeEntry(Guid id, TimeEntry timeEntry);
        List<TimeEntry>? DeleteTimeEntry(Guid id);
    }
}
