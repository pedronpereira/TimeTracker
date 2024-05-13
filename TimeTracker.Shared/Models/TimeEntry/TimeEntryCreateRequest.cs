namespace TimeTracker.Shared.Models.TimeEntry
{
    public record struct TimeEntryCreateRequest(string ProjectId, DateTime Start, DateTime? End);
}
