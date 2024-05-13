namespace TimeTracker.Shared.Models.TimeEntry
{
    public record struct TimeEntryUpdateRequest(string ProjectId, DateTime Start, DateTime? End);
}
