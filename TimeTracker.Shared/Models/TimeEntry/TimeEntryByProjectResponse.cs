using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Shared.Models.TimeEntry
{
    public record struct TimeEntryByProjectResponse(string Id, DateTime Start, DateTime? End);
}
