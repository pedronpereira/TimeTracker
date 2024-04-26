namespace TimeTracker.Api.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private static Dictionary<string, TimeEntry> _timeEntries = new List<TimeEntry>
        {
            new TimeEntry
            {
                Id = Guid.NewGuid().ToString(),
                Project = "Time Tracker App",
                End = DateTime.Now.AddHours(1),
            }
        }.ToDictionary(x => x.Id, x => x);

        public List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry)
        {
            timeEntry.Id = Guid.NewGuid().ToString();
            _timeEntries.Add(timeEntry.Id, timeEntry);
            return _timeEntries.Values.ToList();
        }

        public List<TimeEntry>? DeleteTimeEntry(Guid id)
        {
            if (!_timeEntries.ContainsKey(id.ToString()))
            {
                return null;
            }
            _timeEntries.Remove(id.ToString());
            return _timeEntries.Values.ToList();
        }

        public List<TimeEntry> GetAllTimeEntries()
        {
            return _timeEntries.Values.ToList();
        }

        public List<TimeEntry> UpdateTimeEntry(Guid id, TimeEntry timeEntry)
        {
            if (!_timeEntries.ContainsKey(id.ToString()))
            {
                return null;
            }
            _timeEntries[id.ToString()] = timeEntry;
            return _timeEntries.Values.ToList();
        }

        TimeEntry? ITimeEntryRepository.GetTimeEntryById(Guid id)
        {
            if (!_timeEntries.ContainsKey(id.ToString()))
            {
                return null;
            }
            return _timeEntries[id.ToString()];
        }
    }
}
