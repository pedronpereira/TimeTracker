namespace TimeTracker.Api.Services
{
    public interface ITimeEntryService
    {
        Task<List<TimeEntryResponse>> GetAllTimeEntries();

        Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntryRequest);

        List<TimeEntryResponse>? UpdateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryRequest);
        List<TimeEntryResponse>? DeleteTimeEntry(Guid id);
        Task<TimeEntryResponse?> GetTimeEntryById(Guid id);
    }
}
