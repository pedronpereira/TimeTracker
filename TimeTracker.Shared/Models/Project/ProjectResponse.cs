namespace TimeTracker.Shared.Models.Project
{
    // Complex DTO, combines multiple entities
    public record struct ProjectResponse(
        string Id,
        string Name,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate);
}
