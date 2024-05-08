namespace TimeTracker.Shared.Models.TimeEntry
{
    public record struct TimeEntryResponse (string Id, string Project, DateTime Start, DateTime? End);
}
