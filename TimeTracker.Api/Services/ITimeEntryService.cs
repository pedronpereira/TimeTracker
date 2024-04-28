namespace TimeTracker.Api.Services
{
    public interface ITimeEntryService
    {
        Task<List<TimeEntryResponse>> GetAllTimeEntries();

        Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest);

        Task<List<TimeEntryResponse>?> UpdateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryRequest);
        Task<List<TimeEntryResponse>?> DeleteTimeEntry(Guid id);
        Task<TimeEntryResponse?> GetTimeEntryById(Guid id);
    }
}
