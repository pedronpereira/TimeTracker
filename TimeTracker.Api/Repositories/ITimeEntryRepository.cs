namespace TimeTracker.Api.Repositories
{
    public interface ITimeEntryRepository
    {
        Task<List<TimeEntry>> GetAllTimeEntries();
        Task<TimeEntry?> GetTimeEntryById(Guid id);
        Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
        Task<List<TimeEntry>?> UpdateTimeEntry(Guid id, TimeEntry timeEntry);
        Task<List<TimeEntry>?> DeleteTimeEntry(Guid id);
    }
}
