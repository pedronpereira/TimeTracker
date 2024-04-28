using Microsoft.EntityFrameworkCore;

namespace TimeTracker.Api.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly DataContext _context;

        public TimeEntryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
        {
            timeEntry.Id = Guid.NewGuid().ToString();
            _context.TimeEntries.Add(timeEntry);
            await _context.SaveChangesAsync();

            return await _context.TimeEntries.ToListAsync();
        }

        public async Task<List<TimeEntry>?> DeleteTimeEntry(Guid id)
        {
            var dbTimeEntry = await _context.TimeEntries.FindAsync(id.ToString());
            if (dbTimeEntry is null)
            {
                return null;
            }

            _context.TimeEntries.Remove(dbTimeEntry);

            await _context.SaveChangesAsync();
            return await GetAllTimeEntries();
        }

        public async Task<List<TimeEntry>> GetAllTimeEntries()
        {
            return await _context.TimeEntries.ToListAsync();
        }

        public async Task<List<TimeEntry>> UpdateTimeEntry(Guid id, TimeEntry timeEntry)
        {
            var dbTimeEntry = await _context.TimeEntries.FindAsync(id.ToString());
            if (dbTimeEntry is null)
            {
                return null;
            }

            dbTimeEntry.Project = timeEntry.Project;
            dbTimeEntry.Start = timeEntry.Start;
            dbTimeEntry.End =   timeEntry.End;
            dbTimeEntry.DateUpdated = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetAllTimeEntries();
        }

        public async Task<TimeEntry?> GetTimeEntryById(Guid id)
        {
            return await _context.TimeEntries.FindAsync(id.ToString());
        }
    }
}
