using System.Net.Http.Json;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.Client.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly HttpClient _http;
        public List<TimeEntryResponse> TimeEntries { get; set; } = new List<TimeEntryResponse>();

        public event Action? OnChange;

        public TimeEntryService(HttpClient httpClient)
        {
            _http = httpClient;
        }
        public async Task GetTimeEntryiesByProject(string projectId)
        {
            List<TimeEntryResponse>? result = null;
            if(string.IsNullOrWhiteSpace(projectId))
            {
                result = await _http.GetFromJsonAsync<List<TimeEntryResponse>>("api/timeentry");
            }
        else
            {
                result = await _http.GetFromJsonAsync<List<TimeEntryResponse>>($"api/timeentry/project/{projectId}");
            }

            if (result != null)
            {
                TimeEntries = result;
                OnChange?.Invoke();
            }
        }

        public async Task<TimeEntryResponse> GetTimeEntryById(string projectId)
        {
            return await _http.GetFromJsonAsync<TimeEntryResponse>($"api/timeentry/{projectId}");
        }
    }
}
