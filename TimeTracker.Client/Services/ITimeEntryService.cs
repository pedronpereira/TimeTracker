using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.Client.Services
{
    public interface ITimeEntryService
    {
        event Action? OnChange;

        public List<TimeEntryResponse> TimeEntries { get; set; }
        Task GetTimeEntryiesByProject(string projectId);
        Task<TimeEntryResponse> GetTimeEntryById(string projectId);

    }
}
