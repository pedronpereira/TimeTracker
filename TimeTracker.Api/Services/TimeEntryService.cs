using Mapster;

namespace TimeTracker.Api.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly ITimeEntryRepository _timeEntryRepository;

        public TimeEntryService(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        public async Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest request)
        {
            var newEntry = request.Adapt<TimeEntry>();
            var result = await _timeEntryRepository.CreateTimeEntry(newEntry);
            return result.Adapt<List<TimeEntryResponse>>();
        }

        public List<TimeEntryResponse>? DeleteTimeEntry(Guid id)
        {
            var result = _timeEntryRepository.DeleteTimeEntry(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryResponse>>();
        }

        public async Task<List<TimeEntryResponse>> GetAllTimeEntries()
        {
            var result = await _timeEntryRepository.GetAllTimeEntries();
            return result.Adapt<List<TimeEntryResponse>>();
        }

        public async Task<TimeEntryResponse?> GetTimeEntryById(Guid id)
        {
            var result = await _timeEntryRepository.GetTimeEntryById(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<TimeEntryResponse>();
        }

        public List<TimeEntryResponse>? UpdateTimeEntry(Guid id, TimeEntryUpdateRequest request)
        {
            var updatedEntry = request.Adapt<TimeEntry>();
            var result = _timeEntryRepository.UpdateTimeEntry(id, updatedEntry);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryResponse>>();
        }
    }
}
